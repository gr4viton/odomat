/**
 ******************************************************************************
 * @file      ODOM.c
 * @author    Daniel Davidek
 * @version   V1.0
 * @date      31/12/2012
 * @brief     This file contains all the functions for odometry calculations
 *
 ******************************************************************************
 */
#include "ODOM.h"

/**
 ******************************************************************************
 * Function definitions
 ******************************************************************************
 */

/*
 * @brief  Initializes default values to the "robot"
 * 		all the distances are in [mud]
 * @param  pointer to the robot structure
 * @retval None
 */
void ODOM_INIT_robot_def(ODOM_robot* r) {
	r->unit = 'm';

	r->b = 0.675;
	r->rL = 0.1;
	r->rR = 0.1;

	r->pL = 0;
	r->pR = 0;
	r->dth = 0;
	r->pC = 0;

	r->tL = 0;
	r->tR = 0;
	r->TL = 8582;
	r->TR = 8581;

	r->eL = 3;
	r->eR = 4;
/*
	r->EL = r->eL / r->TL;
	r->ER = r->eR / r->TR;
*/

	r->aL = 2 * M_PI * r->rL / r->TL;
	r->aR = 2 * M_PI * r->rR / r->TR;

	r->EL = r->eL / r->TL;
	r->ER = r->eR / r->TR;


	r->tLbuf = 0;
	r->tRbuf = 0;

	r->START_x = 0;
	r->START_y = 0;
	r->START_th = 0;
	ODOM_SET_rob_start(r);

	r->eqn_type = 1;
	r->calc_prob = 1;// funguje
	r->iter_type = 'n'; //funguje

	r->position_store_type = 'r'; //r relative a absolute
	r->iter_sum = 0;
	r->step_sum = 0;
	r->DEBUG_SIM_PPS_IN_LOOP = 0;
	r->DEBUG_SIM_PPS_IN_LOOP_DELAY = 1000;
	r->DEBUG_SIM_ENC_IN_LOOP = 0;


	// %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
	// probability

	r->sigmax = 0.01;
	r->sigmay = 0.01;
	r->sigmath = (0.5) * M_PI / 180;
	r->Q11 = r->sigmax * r->sigmax;
	r->Q22 = r->sigmay * r->sigmay;
	r->Q33 = r->sigmath* r->sigmath;


	// P = Q
	r->P11 = r->Q11;
	r->P12 = 0;
	r->P13 = 0;
	r->P22 = r->Q22;
	r->P23 = 0;
	r->P33 = r->Q33;

	//r->iter_type = ODOM_ITER_TYPE_SUM_TICKS_TRESHOLD;
	//r->iter_trig.sum_treshold = 2000;

}

void ODOM_PPS_came(ODOM_robot* rob, char from){

	ODOM_CALC_ticks_and_reset(currob);
	ODOM_iteration(currob);
	if( curmsg->parse_pcmsg){
		ODOM_PARSE_pcmsg(currob,curmsg);
	}
	ODOM_SEND_odomsg(currob,curmsg,from);

	if(curmsg->send_actualmsg){
		ODOM_SEND_actualmsg(currob,curmsg);
	}
	if(currob->position_store_type == 'r'){
		currob->x = 0;
		currob->y = 0;
	}
	currob->iter_sum = 0;
	currob->step_sum++;

}

/*
 * @brief  Read out the sum of ticks from the quadrature encoder timers
 * @param  pointer to the robot structure
 * @retval None
 */
void ODOM_CALC_ticks_and_reset(ODOM_robot* rob) {
	currob->tL = (signed int) TIM_GetCounter(TIM1) - HALF_TIM;
	TIM1->CNT = HALF_TIM;
	currob->tR = (signed int) TIM_GetCounter(TIM8) - HALF_TIM;
	TIM8->CNT = HALF_TIM;
}

/**
 * @brief  Calculates all odometry for one iteration
 *         iteration calculations can be calculated every
 *          - time period
 *          - number of ticks
 *          - number of ticks / time = velocity
 * @param  pointer to the robot structure
 * @retval None
 */
void ODOM_iteration(ODOM_robot* r) {
//%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
// measure
	// store and reset the accumulated ticks
	r->tLbuf = r->tL;
	r->tRbuf = r->tR;
	r->tL = 0;
	r->tR = 0;

//%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
// paths
	r->pL = r->aL * r->tLbuf;
	r->pR = r->aR * r->tRbuf * (-1);

//%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
// auxilary
	r->pC = (r->pL + r->pR) / 2;
	r->dth = (r->pR - r->pL) / r->b;


	if (r->dth != 0) {
//%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
// odom - not straight
		r->arg = r->th + r->dth / 2;
		r->arg2 = r->th + r->dth;

		//if (r->eqn_type == 0) {
			// ******************************
			r->C2 = 2 * r->pC / r->dth;
			r->dth2 = r->dth / 2;
			r->sin_dth2 = sin(r->dth2);
			r->sin_arg = sin(r->arg);
			r->cos_arg = cos(r->arg);
		//} else {
			// ++++++++++++++++++++++++++++++
			r->C = r->pC / r->dth;
			r->sin_th = sin(r->th);
			r->cos_th = cos(r->th);
			r->sin_arg2 = sin(r->arg2);
			r->cos_arg2 = cos(r->arg2);
		//}

		if(r->calc_prob == 1){

			// system matrix A
			if(r->eqn_type==0){
				// ******************************
				//// wolfram
				// dFx/d(th) = dFx/d(t)
				// d/dt (2* p / D * sin(D/2) * cos(t + D/2))
				r->A13 = -r->C2*r->sin_dth2*r->sin_arg;

				// dFy/d(th) = dFy/d(t)
				// d/dt (2* p / D * sin(D/2) * sin(t + D/2))
				r->A23 = r->C2*r->sin_dth2*r->cos_arg ;
			}

			else{
				// ++++++++++++++++++++++++++++++
				// dFx/d(th)
				// d/dt (p / D * (sin(t + D) - sin(t))
				r->A13 = r->C*( r->cos_arg2 - r->cos_th );
				// dFy/d(th)
				// d/dt ( - p / D * (cos(t + D) - cos(t))
				r->A23 = r->C*( r->sin_arg2 - r->sin_th );
			}


			// input matrix B
			// dFx/dL
			r->B11 = r->aL/r->b*((-r->C*r->cos_arg2) + (r->pR*(r->sin_arg2 - r->sin_th))/(r->dth*r->dth));

			// dFx/dR
			r->B12 = (r->aR/r->b)* ( r->C*r->cos_arg2 + r->pL*(r->sin_th-r->sin_arg2) / (r->dth*r->dth) );

			// dFy/dL
			r->B21 = r->aL/r->b*((-r->sin_arg2)*r->C + (r->pR*(-r->cos_arg2 + r->cos_th)) / (r->dth*r->dth)) ;

			// dFy/dR
			r->B22 = r->aL/r->b*((r->sin_arg2)*r->C + (r->pL*(+r->cos_arg2 - r->cos_th)) / (r->dth*r->dth)) ;

			// dFth/dL
			r->B31 = -r->aL/r->b;
			// dFth/dR
			r->B32 = r->aR/r->b;

			r->VL2 = r->tLbuf * r->EL; // = VL
			r->VL2 = r->VL2  * r->VL2 ; // = VL*VL
			r->VR2 = r->tRbuf * r->ER; // = VR
			r->VR2 = r->VR2 * r->VR2; // = VR*VR
			// it must be in one step -> or there would be each P variable twice = (k, k-1)
			//( A*P*A' ) + ( B*inVAR*B' ) + ( Q )
			//matrix([A13*(A13*P33+P31)+A13*P13+P11,A13*(A23*P33+P32)+A23*P13+P12,A13*P33+P13],[A23*(A13*P33+P31)+A13*P23+P21,A23*(A23*P33+P32)+A23*P23+P22,A23*P33+P23],[A13*P33+P31,A23*P33+P32,P33])
			//matrix([B12^2*VR2+B11^2*VL2,B12*B22*VR2+B11*B21*VL2,B12*B32*VR2+B11*B31*VL2],[B12*B22*VR2+B11*B21*VL2,B22^2*VR2+B21^2*VL2,B22*B32*VR2+B21*B31*VL2],[B12*B32*VR2+B11*B31*VL2,B22*B32*VR2+B21*B31*VL2,B32^2*VR2+B31^2*VL2])
			// P is symetric
			r->P11 = (r->A13*(r->A13*r->P33+r->P13)+r->A13*r->P13+r->P11) 	+ ((r->B12*r->B12)*r->VR2+(r->B11*r->B11)*r->VL2) 		;
			r->P12 = (r->A13*(r->A23*r->P33+r->P23)+r->A23*r->P13+r->P12) 	+ (r->B12*r->B22*r->VR2+r->B11*r->B21*r->VL2)					;
			r->P13 = (r->A13*r->P33+r->P13)									+ (r->B12*r->B32*r->VR2+r->B11*r->B31*r->VL2)					;
			r->P22 = (r->A23*(r->A23*r->P33+r->P23)+r->A23*r->P23+r->P22) 	+ ((r->B22*r->B22)*r->VR2+(r->B21*r->B21)*r->VL2) 		;
			r->P23 = (r->A23*r->P33+r->P23) 								+ (r->B22*r->B32*r->VR2+r->B21*r->B31*r->VL2)					;
			r->P33 = (r->P33)												+ ((r->B32*r->B32)*r->VR2+(r->B31*r->B31)*r->VL2) 		;

		}
		//%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
		// odometric geometry calculations
		if (r->eqn_type == 0) {
			// ******************************
			// Fx
			r->x = r->x + r->C2 * r->sin_dth2 * r->cos_arg;
			// Fy
			r->y = r->y + r->C2 * r->sin_dth2 * r->sin_arg;
			// Fth
			r->th = r->th + r->dth;
		} else {
			// ++++++++++++++++++++++++++++++
			// Fx
			r->x = r->x + r->C * (r->sin_arg2 - r->sin_th);
			// Fy
			r->y = r->y - r->C * (r->cos_arg2 - r->cos_th);
			// Fth
			r->th = r->th + r->dth;
		}

	} else {
//%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
// odom - straight

		r->sin_th = sin(r->th);
		r->cos_th = cos(r->th);

		if(r->calc_prob == 1){
			//%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
			// system matrix A

			//// wolfram
			// dFx/d(th)
			r->A13 = - r->pC * r->sin_th;
			// dFy/d(th)
			r->A23 = + r->pC * r->cos_th;

			//%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
			// input matrix B

			// dFx/dL
			r->B11 = r->aL / 2 * r->cos_th ;
			// dFx/dR
			r->B12 = r->aR / 2 * r->cos_th;

			// dFy/dL
			r->B21 = r->aL / 2 * r->sin_th ;
			// dFy/dR
			r->B22 = r->aR / 2 * r->sin_th;

			// dFth/dL
			r->B31 = 0;
			// dFth/dR
			r->B32 = 0;


			//%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
			// probability counting
			r->VL2 = r->tLbuf * r->EL; // = VL
			r->VL2 = r->VL2  * r->VL2 ; // = VL*VL
			r->VR2 = r->tRbuf * r->ER; // = VR
			r->VR2 = r->VR2 * r->VR2; // = VR*VR
			// it must be in one step -> or there would be each P variable twice = (k, k-1)
			//( A*P*A' ) + ( B*inVAR*B' ) + ( Q )
			// P is symetric and the same as in not straight trajectory
			r->P11 = (r->A13*(r->A13*r->P33+r->P13)+r->A13*r->P13+r->P11) 	+ ((r->B12*r->B12)*r->VR2+(r->B11*r->B11)*r->VL2) 	+ (r->Q11)	;
			r->P12 = (r->A13*(r->A23*r->P33+r->P23)+r->A23*r->P13+r->P12) 	+ (r->B12*r->B22*r->VR2+r->B11*r->B21*r->VL2)					;
			r->P13 = (r->A13*r->P33+r->P13)									+ (r->B12*r->B32*r->VR2+r->B11*r->B31*r->VL2)					;
			r->P22 = (r->A23*(r->A23*r->P33+r->P23)+r->A23*r->P23+r->P22) 	+ ((r->B22*r->B22)*r->VR2+(r->B21*r->B21)*r->VL2) 	+ (r->Q22)	;
			r->P23 = (r->A23*r->P33+r->P23) 								+ (r->B22*r->B32*r->VR2+r->B21*r->B31*r->VL2)					;
			r->P33 = (r->P33)												+ ((r->B32*r->B32)*r->VR2+(r->B31*r->B31)*r->VL2) 	+ (r->Q33)	;

		} // prob


		//%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
		// odometric geometry calculations
		 r->x = r->x + r->pC * r->cos_th;
		 r->y = r->y + r->pC * r->sin_th;
		 //r->th = r->th;


	}

//%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%


 // fix th into <0,2pi>
        if (r->th > M_PI2 || r->th < -M_PI2)
        	r->th = fmod( r->th, M_PI2 );
        if (r->th < 0)
        	r->th += M_PI2;


	// increment the iteration counter
	r->iter_sum++;
}

/**
 * @brief  Sets the x y and th to their START equivalents
 * 		which can be altered i.e to get correction
 * @param  pointer to the robot structure
 * @retval None
 */
void ODOM_SET_rob_start(ODOM_robot* rob) {
	rob->x = rob->START_x;
	rob->y = rob->START_y;
	rob->th = rob->START_th;
}
char ODOM_isNOTnumber(char* ch){
	int zero = (int)'0';
	if(*ch>=zero && *ch<=zero+9) return 0;
	else return 1;
}
char* ODOM_GET_double(char* ch, double* write_here){
	int c = 1;
	int minus = 1;
	int zero = (int)'0';
	double whole = 0;
	double decim = 0;
	c = 1;
	if(*ch=='-') minus = -1;
	else minus = 1;
	while(*ch!='_' && *ch!='$' && *ch!='\0' && *ch!='.' && *ch!=','){
		whole = whole * 10 + ((int)(*ch) - zero);
		ch++;
		if(ODOM_isNOTnumber(ch)) break;
	}
	if(*ch==',' || *ch=='.'){
		ch++;
		c=0;
		while(*ch!='_' && *ch!='$' && *ch!='\0'){
			decim = decim  + ((int)(*ch) - zero) / pow(10,c);
			c=c+1;
			ch++;
		}
	}
	*write_here = (whole+decim/10)*minus;
	return ch;
}

void ODOM_PARSE_pcmsg(ODOM_robot* rob, ODOM_communication* msg) {
	char *ch = msg->pcmsg;
	long int del = 0;
	double whole = 0;
	double decim = 0;
	int c = 1;
	int minus = 1;
	int zero = (int)'0';
	while( *ch != '\0' && *ch != '$' )
	{
		switch(*ch)
		{
//GET
			case('G'):
					ch++;

				switch(*ch)
				{
					case('C'): // GC = get config
						msg->send_actualmsg = 1;
							break;
					case('O'): // GO = get odomsg
							break;
				}
				break;
//WRITE
			case('W'):
					ch++;

				switch(*ch)
				{
					case('S'): // WS = Simulate PPS in SIM_LOOP
						rob->DEBUG_SIM_PPS_IN_LOOP = 1;
							break;
					case('E'): // WE = Simulate ENC in SIM_LOOP
						rob->DEBUG_SIM_ENC_IN_LOOP = 1;
							break;
				}
				break;
//HIDE
			case('H'):
					ch++;
				switch(*ch)
				{
					case('S'): // HS = Do not Simulate PPS in SIM_LOOP
						rob->DEBUG_SIM_PPS_IN_LOOP = 0;
							break;
					case('E'): // HE = Do not Simulate ENC in SIM_LOOP
						rob->DEBUG_SIM_ENC_IN_LOOP = 0;
							break;
				}
				break;
//SET
			case('S'):
					ch++;

				switch(*ch)
				{
		//CHARS
					case('U'): // SU_u
							ch++;
							rob->unit = *ch;
								break;
		//INTS


		//DOUBLES
					case('E'): // SE_eL_eR
								ch++;
								ch = ODOM_GET_double(++ch, &(rob->eL));
								ch = ODOM_GET_double(++ch, &(rob->eR));
									break;
					case('T'): // ST_TL_TR
								ch++;
								ch = ODOM_GET_double(++ch, &(rob->TL));
								ch = ODOM_GET_double(++ch, &(rob->TR));
									break;
					case('B'): // SB_base_rL_rR
						ch++;
						ch = ODOM_GET_double(++ch, &(rob->b));
						ch = ODOM_GET_double(++ch, &(rob->rL));
						ch = ODOM_GET_double(++ch, &(rob->rR));
							break;
					case('Q'): // SQ_Q11_Q22_Q33
						ch++;
						ch = ODOM_GET_double(++ch, &(rob->Q11));
						ch = ODOM_GET_double(++ch, &(rob->Q22));
						ch = ODOM_GET_double(++ch, &(rob->Q33));
							break;
					case('X'): // SX_x_y_th
						ch++;
						ch = ODOM_GET_double(++ch, &(rob->x));
						ch = ODOM_GET_double(++ch, &(rob->y));
						ch = ODOM_GET_double(++ch, &(rob->th));
							break;
					case('S'): // SS_x_y_th
						ch++;
						ch = ODOM_GET_double(++ch, &(rob->START_x));
						ch = ODOM_GET_double(++ch, &(rob->START_y));
						ch = ODOM_GET_double(++ch, &(rob->START_th));
							break;

				}
				break;
//DEBUG
			case('D'):
					ch++;

				switch(*ch)
				{
					case('S'): // DS = Set Simulate PPS in SIM_LOOP _ delay
						ch+=2; // after the _
						del = 0;
						c = 1;
						while(*ch!='_' && *ch!='$' && *ch!='\0'){
							del = del * 10 + (int)(*ch) - zero;
							ch++;
						}

						rob->DEBUG_SIM_PPS_IN_LOOP_DELAY = del;
							break;
				}
				break;
		}

		ch++;
	}
	msg->pcmsg[0] = 0;
}

void ODOM_SEND_actualmsg(ODOM_robot* rob, ODOM_communication* msg) {
		//printf(msg->pcmsg);



		printf("%c%.*s%c%.*e%c%.*e%c%.*g%c%.*e%c%.*e%c%.*e%c%.*e%c%.*e%c%.*e%c%.*e%c%.*e%c%.*e%c%.*e%c%i%c%i%c\r\n",
						'_', 									// %c
						ATT_LEN, msg->ATT, 						// %.*s
						'X', 									// %c
						DBL_DIG, rob->START_x, 					// %.*e
						'Y', 									// %c
						DBL_DIG, rob->START_y,					// %.*e
						'A', 									// %c
						DBL_DIG, rob->START_th,					// %.*g
						'P', 									// %c
						DBL_DIG, rob->Q11, 						// %.*e
						':', 									// %c
						DBL_DIG, rob->Q22, 						// %.*e
						';', 									// %c
						DBL_DIG, rob->Q33, 						// %.*e
						'<', 									// %c
						DBL_DIG, rob->rL, 						// %.*e
						'=', 									// %c
						DBL_DIG, rob->b, 						// %.*e
						'>', 									// %c
						DBL_DIG, rob->rR, 						// %.*e
						'M', 									// %c
						DBL_DIG, rob->TL, 						// %.*e
						'N', 									// %c
						DBL_DIG, rob->TR, 						// %.*e
						'E', 									// %c
						DBL_DIG, rob->eL, 						// %.*e
						'F', 									// %c
						DBL_DIG, rob->eR, 						// %.*e
						'I', 									// %c
						rob->iter_type, 						// %i
						'T', 									// %c
						rob->iter_trig.sum_treshold,			// %i
						'$' 									// %c
						);



		msg->send_actualmsg = 0;
}

/**
 * @brief  Sends the odomsg by the printf which is defaultly send to USART2
 * 		stores the currently send odomsg last_odomsg
 *			and if the position_store_type is set to relative, calls the ODOM_SET_rob_start function
 * @param  pointer to a structure of odomsg
 * @retval None
 */
void ODOM_SEND_odomsg(ODOM_robot* rob, ODOM_communication* msg, char from) {
	//spravny 1.1
		printf("%c%c%.*s%c%i%c%i%c%c%c%c%i%c%i%c"
				"%.*e%c%.*e%c%.*g%c%.*e%c%.*e%c%.*e%c%.*e%c%.*e%c%.*e%c\r\n",
				'^', 									// %c
				from,									// %c
				ATT_LEN, msg->ATT, 						// %.*s
				'S', 									// %c
				rob->step_sum, 							// %i
				'I', 									// %c
				rob->iter_sum, 							// %i
				'%', 									// %c
				rob->unit, rob->position_store_type,  	// %c%c
				'L', 									// %c
				rob->tLbuf,								// %i
				'R', 									// %c
				rob->tRbuf,								// %i
				'X', 									// %c
				DBL_DIG, rob->x, 						// %.*e
				'Y', 									// %c
				DBL_DIG, rob->y, 						// %.*e
				'A', 									// %c
				DBL_DIG, rob->th, 						// %.*g
				'P', 									// %c
				DBL_DIG, rob->P11, 						// %.*e
				':', 									// %c
				DBL_DIG, rob->P12, 						// %.*e
				';', 									// %c
				DBL_DIG, rob->P13, 						// %.*e
				'<', 									// %c
				DBL_DIG, rob->P22, 						// %.*e
				'=', 									// %c
				DBL_DIG, rob->P23, 						// %.*e
				'>', 									// %c
				DBL_DIG, rob->P33, 						// %.*e
				'$' 									// %c
				);
}

/**
 * @brief  Initializes default values to the odomsg configuration
 * @param  pointer to a structure of odomsg
 * @retval None
 */
void ODOM_INIT_communication(ODOM_communication* msg) {
	msg->pcmsg[0] = (char) 0;
	msg->ATT[0] = (char) 0;
	msg->parse_pcmsg = 0;
	msg->send_actualmsg = 0;
	msg->recieving_pcmsg = 0;
	msg->recieving_ATT = 0;

	//msg->last_odomsg[0] = (char) 0;

	sprintf(msg->ATT, "UTC 80.01.01 00:00:00 ??\n");
}
