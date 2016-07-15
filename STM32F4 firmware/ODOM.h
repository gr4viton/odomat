#ifndef DEF_ODOM_h
#define DEF_ODOM_h

//\\ = means not implemented yet

/**
  ******************************************************************************
  * Macro definitions
  ******************************************************************************
  */
// data types
#define data_type double
#define tick_type signed int
#define byte_type unsigned short int
#define char_type char
//typedef precision_type double

// length of message strings
//#define ATT_LEN 24+1
#define ATT_LEN 24
#define ODOMSG_LEN 200
#define PCMSG_LEN 400

// digits of printf double
#define DBL_DIG 16-1

// common baud-rates
#define BAUDRATE_LOW	 	9600
//300
//1200
//2400
//4800
//9600
//14400
//19200
//28800
//38400
//57600
//115200
//230400
#define BAUDRATE_NORMAL 	19200
#define BAUDRATE_HIGH 		115200

#define BAUDRATE_GPS		9600
#define BAUDRATE_ODOMSG		9600
//19200

// iter-type macros
#define ODOM_ITER_TYPE_OVERFLOW_ONLY 		('n')
#define ODOM_ITER_TYPE_PERIOD 				('t')
#define ODOM_ITER_TYPE_SUM_TICKS_TRESHOLD 	('s')
#define ODOM_ITER_TYPE_TICKS_TRESHOLD		('x')

/* Example on setting up the TIM2_real_freq = frequency of ODOM_iteration triggering
 * TIM2_counter_clock = TIM2CLK / (TIM_Prescaler + 1) = 2 kHz = 2000 Hz
 * TIM_Period = 2000 - 1
 * TIM2_real_freq = TIM2_counter_clock / (TIM_Period + 1) = 1 Hz
*/
// macro definitions of common periods
#define ODOM_TIM2_PERIOD_2HZ  1000 - 1
#define ODOM_TIM2_PERIOD_10HZ  200 - 1
#define ODOM_TIM2_PERIOD_100HZ 20 - 1

// setting of tim2 period = frequency of ODOM_iteration triggering
//#define ODOM_TIM2_PERIOD ODOM_TIM2_PERIOD_100HZ
//#define ODOM_TIM2_PERIOD 16000 -1
#define ODOM_TIM2_PERIOD ODOM_TIM2_PERIOD_2HZ


/**
  ******************************************************************************
  * Include
  ******************************************************************************
  */
#include "INIT.h"

/**
  ******************************************************************************
  * Structures & Unions type definitions
  ******************************************************************************
  */
union  ODOM_iter_trigger_;
struct ODOM_robot_;
struct ODOM_communication_;

/*
 * @brief Union for storing the iteration trigger value
 */
typedef union ODOM_iter_trigger_{
	// threshold on sum of ticks
	tick_type sum_treshold;
	// threshold on number of ticks in any encoder
	tick_type tick_treshold;
} ODOM_iter_trigger;

/*
 * @brief Main structure for storing the odometry data
 */
typedef struct ODOM_robot_{
	/***************************************************************************
	 * [mud] = main unit of distance = millimeters
	 * [mua] = main unit of angle = radians
	 */

	/***************************************************************************
	 * Which [mud] and [mua] is used, those in curly brackets are implemented
	 * [mua]
	 * {lower-case letter} - radians
	 * upper-case letter - degrees
	 *
	 * [mud]
	 * m,M - meters
	 * {c},C - centimeters
	 * l,L - millimeters
	 * k,K - kilometers
	 * i,I - inches
	 * y,Y - yards
	 */
	char_type unit;

	/***************************************************************************
	 * After every odomsg the currently calculated position and angle (x,y,th)
	 * can be deleted and reseted to the default value
	 * r - relative = after each odomsg send the position and angle is reseted
	 * a - absolute = the position and angle is never deleted
	 */
	char_type position_store_type;

	/***************************************************************************
	 * Configuration of the iteration trigger
	 * One can utilize the predefined macros ODOM_ITER_TYPE_
	 * n - none = only on encoder counter overflow which is treated every time anyway
	 * t - time = every period start new iteration
	 * s - sum = each time period compare sum of counted ticks with threshold
	 * x - any = each time period compare each encoder tick count with threshold
	 *\\ v - velocity
	 */
	char_type iter_type;

	/***************************************************************************
	 * Union storing the iteration trigger value */
	ODOM_iter_trigger iter_trig;

	/***************************************************************************
	 * Number of iterations which took place before the 1PPS signal came */
	tick_type iter_sum;
	//%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
	// Number of odomsg sended
	//long int step_sum;
	tick_type  step_sum;

	/***************************************************************************
	 * Physical parameters of the robot in [mud] and [mua]
	 *   [b] = base = distance between ground touch point of both wheels
	 *   [rL, rR] = radius of left, right wheel
    'pR', 0,... %path
    'pL', 0,...
    'tR', 0,... %ticks
    'tL', 0,...
    'TR', 8580,... %ticks per wheel revolution [ticks]
    'TL', 8580,...
    'eR', 10,... %error per wheel revolution [ticks]
    'eL', 10,...
    'rR', 0.10,... %radius of wheels [m]
    'rL', 0.10,...
    'aR', 0,... % tR*aR = pR --> aR = 2*pi*rR/TR
    'aL', 0,...
	 */
	data_type b;
	data_type rL;
	data_type rR;

	//Path traveled by each wheel (so far)
	data_type pL;
	data_type pR;
	// Difference in direction (dth) and path traveled by the center of robot (pC)
	data_type dth;
	data_type pC;

	// Ticks counted so far from each wheel ("counted for a time")
	volatile tick_type tL;
	volatile tick_type tR;


	//Ticks per wheel revolution
	data_type TL;
	data_type TR;

	//Ticks buffer, to avoid data lost
	tick_type tLbuf;
	tick_type tRbuf;


	// tL*aL = pL
	data_type aL;
	data_type aR;


	// equation type 0=sin*cos.., 1=sin+cos..
	char_type eqn_type;

	// calc_prob? 0=no 1=yes
	char_type calc_prob;

	// %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
	// auxilary
	data_type C;
	data_type C2;
	data_type dth2;
	data_type arg;
	data_type arg2;

	data_type sin_dth2;
	data_type sin_arg;
	data_type cos_arg;

	data_type sin_th;
	data_type cos_th;
	data_type sin_arg2;
	data_type cos_arg2;

	// %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
	// probability

	// state covariance matrix P
	//data_type P[9];

	data_type P11;
	data_type P12;
	data_type P13;
	//data_type P21;
	data_type P22;
	data_type P23;
	//data_type P31;
	//data_type P32;
	data_type P33;


	// system matrix A
	data_type A13;
	data_type A23;

	//errors
	data_type eL;
	data_type eR;


	// vL = tL * EL = tL * eL/TL
	data_type EL;
	data_type ER;
	/*
	// vL^2 = tL^2 * EL^2 = tL*tL * EL2
	data_type EL2;
	data_type ER2;*/

	/*
	// vL = tL * EL = tL * eL/TL
	data_type vL;
	data_type vR;
	*/
	// VL2 = vL^2 = tL*tL * EL2
	data_type VL2;
	data_type VR2;
	// input variance matrix inVar
	//(VL2, VR2)*eye(2,2)

	// variance
	// input variance
	data_type sigmax;
	data_type sigmay;
	data_type sigmath;

	// system covariance matrix Q
	data_type Q11;
	data_type Q22;
	data_type Q33;

	// input covariance matrix B
	//data_type B[6];

	data_type B11;
	data_type B12;
	data_type B21;
	data_type B22;
	data_type B31;
	data_type B32;

	// %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
	// Direction (th) and position (x,y) of robot in global Cartesian coordinate system
	data_type x;
	data_type y;
	data_type th;

	/***************************************************************************
	 * STARTING direction (START_th) and position (START_x, START_y)
	 * if the position_store_type is set to relative
	 * xyth are set to START_xyth on every send of the odomsg
	 */
	data_type START_x;
	data_type START_y;
	data_type START_th;

	//%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

	//%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
	// simulate various inputs
	char DEBUG_SIM_PPS_IN_LOOP;
	char DEBUG_SIM_ENC_IN_LOOP;
	long int DEBUG_SIM_PPS_IN_LOOP_DELAY;


} ODOM_robot;



/*
 * @brief Main structure for storing the communication data
 */
typedef struct ODOM_communication_{

	/* settings for odomsg communication - USART2 */
	/* settings for GPS communication - USART3 */

	/***************************************************************************
	 * Communication from the upper level
	 * for later use, to configure odomsg
	 *  - i.e to change the units of measure
	 */
	char_type pcmsg[PCMSG_LEN+1];

	/***************************************************************************
	 * Ascii time tag */
	char_type ATT[ATT_LEN+1];

	/***************************************************************************
	 * When odomsg is send it's also stored here */
	// char_type last_odomsg[ODOMSG_LEN+1];

	//%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
	// after full PCMSG has been written from serial into pcmsg this flag is set
	char_type parse_pcmsg;

	//%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
	// 1 when the message recieving usart rutine is inside PCMSG
	char_type recieving_pcmsg;

	//%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
	// 1 when the message recieving usart rutine is inside GPS-ATT msg
	char_type recieving_ATT;

	//%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
	// 1 when the pcmsg parsing is complete and the actual msg should be sended
	char_type send_actualmsg;

}ODOM_communication;


/**
  ******************************************************************************
  * External variables declaration
  ******************************************************************************
  */
// pointer to the currently allocated robot and odomsg configuration
extern ODOM_robot* currob;
extern ODOM_communication* curmsg;


/**
  ******************************************************************************
  * Function declarations
  ******************************************************************************
  */
void ODOM_INIT_robot_def				(ODOM_robot* rob);
void ODOM_INIT_path_per_wheel_rev	(ODOM_robot* rob);
void ODOM_INIT_communication		(ODOM_communication* msg);

void ODOM_CALC_ticks_and_reset	(ODOM_robot* rob);
void ODOM_CALC_wheel_revs		(ODOM_robot* rob);
void ODOM_CALC_wheel_paths		(ODOM_robot* rob);
void ODOM_CALC_dpath_dth		(ODOM_robot* rob);

void ODOM_UPDATE_xyth			(ODOM_robot* rob);

void ODOM_iteration				(ODOM_robot* rob);
void ODOM_SET_rob_start			(ODOM_robot* rob);
void ODOM_SEND_odomsg			(ODOM_robot* rob, ODOM_communication* msg, char from);
void ODOM_SEND_actualmsg		(ODOM_robot* rob, ODOM_communication* msg);
void ODOM_PPS_came				(ODOM_robot* rob, char from);
void ODOM_PARSE_pcmsg			(ODOM_robot* rob, ODOM_communication* msg);
#endif
