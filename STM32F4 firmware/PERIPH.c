/**
  ******************************************************************************
  * @file      PERIPH.c
  * @author    Daniel Davidek
  * @version   V1.0
  * @date      31/12/2012
  * @brief     This file contains peripheral IRQHandler functions
  * 			and USART_sendchar() function
  *
  ******************************************************************************
  */
#include "PERIPH.h"

/**
  ******************************************************************************
  * Function definitions
  ******************************************************************************
  */
/**
  * @brief  TIM1 update handler function
  * 		TIM1 = ENCL - ch1=pe9, ch2=pe11
  * @param  None
  * @retval None
  */
void TIM1_UP_TIM10_IRQHandler(void){
	if(TIM_GetFlagStatus(TIM1, TIM_FLAG_Update) != RESET ){
		static uint32_t timL=0;
		static uint32_t timR=0;

    	timL = TIM_GetCounter(TIM1);
    	TIM1->CNT = timL + HALF_TIM;

    	timR = TIM_GetCounter(TIM8);
    	TIM8->CNT = HALF_TIM;

    	if(timL <= HALF_TIM)
    		currob->tL = +HALF_TIM;
    	else
    		currob->tL = -HALF_TIM;
    	currob->tR = (signed int) timR - HALF_TIM;
    	ODOM_iteration(currob);

		//GPIO_ToggleBits(GPIOD, GPIO_Pin_13);
		TIM_ClearFlag(TIM1, TIM_FLAG_Update);
	}
}


/**
  * @brief  TIM8 update handler function
  * 		TIM8 = ENCR - ch1=pc6, ch2=pc7
  * @param  None
  * @retval None
  */
void TIM8_UP_TIM13_IRQHandler(void){
	if(TIM_GetFlagStatus(TIM8, TIM_FLAG_Update) != RESET ){

		static uint32_t timL=0;
		static uint32_t timR=0;

    	timR = TIM_GetCounter(TIM8);
    	TIM8->CNT = timR + HALF_TIM;

    	timL = TIM_GetCounter(TIM1);
    	TIM1->CNT = HALF_TIM;

    	if(timR <= HALF_TIM)
    		currob->tR = +HALF_TIM;
    	else
    		currob->tR = -HALF_TIM;
    	currob->tL = (signed int) timL - HALF_TIM;
    	ODOM_iteration(currob);

		//GPIO_ToggleBits(GPIOD, GPIO_Pin_12);
		TIM_ClearFlag(TIM8, TIM_FLAG_Update);
	}
}


/**
  * @brief  TIM3 update handler function
  * 		TIM3 = SIM_PPS - TIM3_IRQn
  * @param  None
  * @retval None
  */
void TIM3_IRQHandler(){
#ifdef DEBUG_LED_ON_TIM3
	GPIO_ToggleBits(GPIOD, DEBUG_TIM3_LED);
#endif
	if (TIM_GetITStatus(TIM3, TIM_IT_Update) != RESET){
		ODOM_PPS_came(currob,'T');
		TIM_ClearITPendingBit(TIM3, TIM_IT_Update);
	}
}
/**
  * @brief  TIM2 interrupt request handler function
  *			TIM2 = iteration - TIM2_IRQn
  * @param  None
  * @retval None
  */
void TIM2_IRQHandler(){
#ifdef DEBUG_LED_ON_TIM2
	GPIO_ToggleBits(GPIOD, DEBUG_TIM2_LED);
#endif
	if (TIM_GetITStatus(TIM2, TIM_IT_Update) != RESET){
		if(currob->iter_type=='t'){
			ODOM_CALC_ticks_and_reset(currob);
			ODOM_iteration(currob);
		}
		if(currob->iter_type=='s'){
			currob->tL = (signed int) TIM_GetCounter(TIM1) - HALF_TIM;
			currob->tR = (signed int) TIM_GetCounter(TIM8) - HALF_TIM;

			if(currob->tL < 0)	currob->tL = -(currob->tL);
			if(currob->tR < 0)	currob->tR = -(currob->tR);

			if( (currob->tL + currob->tR) >= currob->iter_trig.sum_treshold){
				ODOM_CALC_ticks_and_reset(currob);
				ODOM_iteration(currob);
			}
		}
		if(currob->iter_type=='x'){
			// not structurally clear, but more efficient than alternatives
			currob->tL = (signed int) TIM_GetCounter(TIM1) - HALF_TIM;
			if( currob->tL >=  currob->iter_trig.tick_treshold \
			 || currob->tL <= -currob->iter_trig.tick_treshold ){
				ODOM_CALC_ticks_and_reset(currob);
				ODOM_iteration(currob);
			}
			else{
				currob->tR = (signed int) TIM_GetCounter(TIM1) - HALF_TIM;
				if( currob->tR >=  currob->iter_trig.tick_treshold \
				 || currob->tR <= -currob->iter_trig.tick_treshold ){
					ODOM_CALC_ticks_and_reset(currob);
					ODOM_iteration(currob);
				}
			}
		}
		TIM_ClearITPendingBit(TIM2, TIM_IT_Update);
	}
}

/*
 * @brief  When external 1PPS signal from GPS module comes
 * 		   this function calculates and sends the odomsg to the output usart
 * @param  None
 * @retval None
 */
void EXTI1_IRQHandler(void){
	if(EXTI_GetITStatus(EXTI_Line1) != RESET){
		ODOM_PPS_came(currob,'G');
		EXTI_ClearITPendingBit(EXTI_Line1);
#ifdef DEBUG_LED_ON_PPS
		GPIO_ToggleBits(GPIOD,DEBUG_ON_PPS_LED);
#endif
	}
}

/*
 * @brief  When simulated 1PPS signal from button comes
 * 		   this DEBUG function calculates and sends the odomsg to the output usart
 * @param  None
 * @retval None
 */
#ifdef DEBUG_PPS_ON_BUTTON
void EXTI0_IRQHandler(void){
	if(EXTI_GetITStatus(EXTI_Line0) != RESET){
		ODOM_PPS_came(currob,'B');
		EXTI_ClearITPendingBit(EXTI_Line0);
	}
}
#endif

/*
 * @brief  This function acquires external interrupt from USART2
 * 		USART2 is connected to the end device to which is the curmsg sended
 * 		usart2 = ODO+PC - tx=pa2,  rx=pa3
 * @param  None
 * @retval None
 */
void USART2_IRQHandler(void){
	char ch;
	//static char str[10];
	static int i = 0;
	if( USART_GetITStatus(USART2, USART_IT_RXNE) ){
		//while(USART_GetFlagStatus(USART2, USART_FLAG_RXNE) == RESET);

		ch = USART_ReceiveData(USART2);

		if(curmsg->recieving_pcmsg){
			if((ch != 0) && (ch != 13) && (ch != 10) && (i < PCMSG_LEN) && (ch != '$'))
			{
				ch = USART_ReceiveData(USART2);
				curmsg->pcmsg[i] = (char_type)ch;
				i = i+1;
			}
			else
			{
				curmsg->pcmsg[i] = 0;
				curmsg->recieving_pcmsg = 0;
				curmsg->parse_pcmsg = 1;
				i = 0;
			}
		}

		if(ch == '^'){
			curmsg->recieving_pcmsg = 1;
		}
	}


}


/*
 * @brief  This function acquires external interrupt from USART3
 * 			USART3 is connected to GPS module and takes ASCII Time-tag (ATT) message
 * 			usart3 = GPS - tx=pb10, rx=pb11
 * @param  None
 * @retval None
 */
void USART3_IRQHandler(void){
	char ch;
	//static char str[10];
	static int i = 0;
	if( USART_GetITStatus(USART3, USART_IT_RXNE) ){
		//while(USART_GetFlagStatus(USART2, USART_FLAG_RXNE) == RESET);

		ch = USART_ReceiveData(USART3);

		// noise reduction
		if((ch == 'U') && (curmsg->recieving_ATT == 0))	curmsg->recieving_ATT = 1;
		if((ch == 'T') && (curmsg->recieving_ATT == 1))	curmsg->recieving_ATT = 2;
		if((ch == 'C') && (curmsg->recieving_ATT == 2))	{ curmsg->recieving_ATT = 3; i = 2; }

		if(curmsg->recieving_ATT == 3){
			if((ch != 0) && (ch != 13) && (ch != 10) && (i < ATT_LEN) )
			{
				ch = USART_ReceiveData(USART3);
				curmsg->ATT[i] = (char_type)ch;
				i = i+1;
			}
			else
			{
				curmsg->ATT[i] = 0;
				curmsg->recieving_ATT = 0;
				i = 0;
			}
		}

	}
}

void USART_sendchar(USART_TypeDef *USARTx, char *ch){
	while(*ch){
		USART_SendData(USARTx, (char) *(ch++));
		while( !USART_GetFlagStatus(USARTx, USART_FLAG_TC) ){
		}
	}
}
