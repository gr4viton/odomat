/**
  ******************************************************************************
  * @file      SIM.c
  * @author    Daniel Davidek
  * @version   V1.0
  * @date      31/12/2012
  * @brief     This file contains simulation functions definitions
  *
  ******************************************************************************
  */
#include "SIM.h"

/**
  ******************************************************************************
  * Function definitions
  ******************************************************************************
  */

/*
 * @brief  Function to simulate main loop and signal from the encoders
 * @param  None
 * @retval None
 */
void SIM_MAIN_loop(void){
	static signed int i =0;
	static tick_type dela = 10;
	/*
	static signed int timL = 0;
	static signed int timR = 0;
	*/
    while(1)
    {
    	//delay(dela);
    	//go_ahead = GPIO_ReadInputDataBit(GPIOA, GPIO_Pin_0);
    	if(currob->DEBUG_SIM_ENC_IN_LOOP){
			for(i=0;i<10;i++){
				SIM_ENC_loop(100, 0, dela, GPIOE, GPIO_Pin_0, GPIO_Pin_1);
				SIM_ENC_loop(100, 1, dela, GPIOE, GPIO_Pin_2, GPIO_Pin_3);
				delay(10);
				//ODOM_iteration(currob);
			}
    	}
#ifdef DEBUG_LED_ON_SIM_LOOP_END
    	GPIO_ToggleBits(GPIOD, DEBUG_SIM_LOOP_END_LED);
#endif

    	/*
    	timL = (signed int) TIM_GetCounter(TIM1) - HALF_TIM;
    	timR = (signed int) TIM_GetCounter(TIM8) - HALF_TIM;
*/
    	//delay(10);
    	// if there is a loopback
  	    //USART_sendchar(USART3_GPS, "UTC 02.12.21 20:21:16 56\n");

  	    //USART_sendchar(USART2_ODO, "HELLO PUTTY ON THE GR4LAPTOP!!\n");
  	    //while(1){

    	if( currob->DEBUG_SIM_PPS_IN_LOOP != 0){
			//SIM_1PPS();
    		ODOM_PPS_came(currob,'I');
			delay(currob->DEBUG_SIM_PPS_IN_LOOP_DELAY);
    	}

		//delay(100);
  	    //}
    }
}


/*
 * @brief  Function generating not known time delay
 * @param  None
 * @retval None
 */
void delay(long int it){
	it = it*1000;
	for(; it>0; it--)
	{}
}

/*
 * @brief  Simulate 1PPS signal on PE4
 * @param  None
 * @retval None
 */
void SIM_1PPS(void){
	GPIO_WriteBit(GPIOE, GPIO_Pin_6, 0);
	GPIO_WriteBit(GPIOE, GPIO_Pin_6, 1);
	delay(10);
	GPIO_WriteBit(GPIOE, GPIO_Pin_6, 0);
}

/*
 * @brief  Show on diodes what are the sates of defined pins on defined ports
 * @param  None
 * @retval None
 */
void SHOW_ON_LEDS(void){
	/*
	GPIO_WriteBit(GPIOD, GPIO_Pin_12, GPIO_ReadInputDataBit(GPIOC, GPIO_Pin_6));
	GPIO_WriteBit(GPIOD, GPIO_Pin_13, GPIO_ReadInputDataBit(GPIOC, GPIO_Pin_7));

	GPIO_WriteBit(GPIOD, GPIO_Pin_14, GPIO_ReadInputDataBit(GPIOA, GPIO_Pin_8));
	GPIO_WriteBit(GPIOD, GPIO_Pin_15, GPIO_ReadInputDataBit(GPIOA, GPIO_Pin_9));
	//GPIO_WriteBit(GPIOD, GPIO_Pin_14, GPIO_ReadInputDataBit(GPIOE, GPIO_Pin_5));
	//GPIO_WriteBit(GPIOD, GPIO_Pin_15, GPIO_ReadInputDataBit(GPIOE, GPIO_Pin_6));
	//GPIO_WriteBit(GPIOD, GPIO_Pin_14, GPIO_ReadInputDataBit(GPIOC, GPIO_Pin_8));
	//GPIO_WriteBit(GPIOD, GPIO_Pin_15, GPIO_ReadInputDataBit(GPIOC, GPIO_Pin_9));
	 */
}

/*
 * @brief  Simulate encoder's quadrature input
 * @param  go_ahead 	- front [1] or back [0] side type of rotation simulated signal
 * @param  dela 		- delay between the ticks
 * @param  GPIOx 		- port
 * @param  pinA 		- channel A
 * @param  pinB 		- channel B
 * @retval None
 */
void SIM_ENC(int go_ahead, tick_type dela, GPIO_TypeDef* GPIOx, uint16_t pinA, uint16_t pinB ){
	if(go_ahead){
    	GPIO_WriteBit(GPIOx, pinA, 0); GPIO_WriteBit(GPIOx, pinB, 1); delay(dela); SHOW_ON_LEDS();
    	GPIO_WriteBit(GPIOx, pinA, 1); GPIO_WriteBit(GPIOx, pinB, 1); delay(dela); SHOW_ON_LEDS();
    	GPIO_WriteBit(GPIOx, pinA, 1); GPIO_WriteBit(GPIOx, pinB, 0); delay(dela); SHOW_ON_LEDS();
    	GPIO_WriteBit(GPIOx, pinA, 0); GPIO_WriteBit(GPIOx, pinB, 0); delay(dela); SHOW_ON_LEDS();
	}
	else{
		GPIO_WriteBit(GPIOx, pinA, 1); GPIO_WriteBit(GPIOx, pinB, 0); delay(dela); SHOW_ON_LEDS();
		GPIO_WriteBit(GPIOx, pinA, 1); GPIO_WriteBit(GPIOx, pinB, 1); delay(dela); SHOW_ON_LEDS();
		GPIO_WriteBit(GPIOx, pinA, 0); GPIO_WriteBit(GPIOx, pinB, 1); delay(dela); SHOW_ON_LEDS();
		GPIO_WriteBit(GPIOx, pinA, 0); GPIO_WriteBit(GPIOx, pinB, 0); delay(dela); SHOW_ON_LEDS();
	}
}

/*
 * @brief  Simulate encoder's quadrature input in a loop
 * @param  max_iter 	- for loop constraint
 * @param  go_ahead 	- front [1] or back [0] side type of rotation simulated signal
 * @param  dela 		- delay between the ticks
 * @param  GPIOx 		- port
 * @param  pinA 		- channel A
 * @param  pinB 		- channel B
 * @retval None
 */
void SIM_ENC_loop(long int max_iter, int go_ahead, tick_type dela, GPIO_TypeDef* GPIOx, uint16_t pinA, uint16_t pinB ){
	for(;max_iter>0;max_iter--)
		SIM_ENC(go_ahead, dela, GPIOx, pinA, pinB);
}
