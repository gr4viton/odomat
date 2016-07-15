/**
  ******************************************************************************
  * @file      INIT.c
  * @author    Daniel Davidek
  * @version   V1.0
  * @date      31/12/2012
  * @brief     This file contains all the initialization function definitions
  ******************************************************************************
  */
#include "INIT.h"


/**
  ******************************************************************************
  * Variable definitions
  ******************************************************************************
  */
//towards which USART send printf - odomsg - USART2
USART_TypeDef* USART_PRINTF = USART2_ODO;



/**
  ******************************************************************************
  * Function definitions
  ******************************************************************************
  */
/* Initializes all the needed components
 * @param  None
 * @retval None
 */
void INIT_all(void){


	INIT_gpio();
	INIT_extint_PPS();
	INIT_usart3_GPS		(BAUDRATE_GPS);
	INIT_usart2_ODOMSG	(BAUDRATE_ODOMSG);

	// iteration
#ifdef DEBUG_SIM_PPS_ON_TIM2
	//INIT_tim_ITERATE();
#endif

	// simul pps
	INIT_tim_ENCODER();
#ifdef DEBUG_SIM_PPS_ON_TIM3
	INIT_tim3_SIM_PPS();
#endif
}

/*
 * @brief  "input" usart3 for ATT messages from GPS module
	        - USART3
	        - pins: PB10 = Tx, PB11 = Rx
	        - receive and transmit
	        - no hardware flow control
	        - word length = 8 Bits
	        - one stop-bit
	        - no parity
 * @param  baudrate 	- one can utilize defined macros
 * @retval None
 */
void INIT_usart3_GPS(uint32_t baudrate){
	GPIO_InitTypeDef GPIO_InitStructure;
	USART_InitTypeDef USART_InitStructure;
	NVIC_InitTypeDef NVIC_InitStructure;

	RCC_AHB1PeriphClockCmd(RCC_AHB1Periph_GPIOB, ENABLE);
	RCC_APB1PeriphClockCmd(RCC_APB1Periph_USART3, ENABLE);

	GPIO_PinAFConfig(GPIOB, GPIO_PinSource10, GPIO_AF_USART3); //TX
	GPIO_PinAFConfig(GPIOB, GPIO_PinSource11, GPIO_AF_USART3); //RX

	GPIO_InitStructure.GPIO_Pin = GPIO_Pin_10 | GPIO_Pin_11;
	GPIO_InitStructure.GPIO_OType = GPIO_OType_PP;
	GPIO_InitStructure.GPIO_PuPd = GPIO_PuPd_UP;
	GPIO_InitStructure.GPIO_Speed = GPIO_Speed_50MHz;
	GPIO_InitStructure.GPIO_Mode = GPIO_Mode_AF;
	GPIO_Init(GPIOB, &GPIO_InitStructure);

	USART_InitStructure.USART_Mode = USART_Mode_Rx | USART_Mode_Tx;
	USART_InitStructure.USART_HardwareFlowControl = USART_HardwareFlowControl_None;
	USART_InitStructure.USART_WordLength = USART_WordLength_8b;
	USART_InitStructure.USART_StopBits = USART_StopBits_1;
	USART_InitStructure.USART_Parity = USART_Parity_No;
	USART_InitStructure.USART_BaudRate = baudrate;
	USART_Init(USART3, &USART_InitStructure);
	// enable the USART3 receive interrupt
	USART_ITConfig(USART3, USART_IT_RXNE, ENABLE);

	NVIC_InitStructure.NVIC_IRQChannel = USART3_IRQn;		 // we want to configure the USART3 interrupts
	NVIC_InitStructure.NVIC_IRQChannelPreemptionPriority = 0x03;// this sets the priority group of the USART3 interrupts
	NVIC_InitStructure.NVIC_IRQChannelSubPriority = 0x03;		 // this sets the sub-priority inside the group
	NVIC_InitStructure.NVIC_IRQChannelCmd = ENABLE;			 // the USART3 interrupts are globally enabled
	NVIC_Init(&NVIC_InitStructure);

	USART_Cmd(USART3, ENABLE);
}



/*
 * @brief  ODOMSG "output" usart2 for upper system messages
	        - USART2
	        - pins: PA2 = Tx, PA3 = Rx
	        - receive and transmit
	        - no hardware flow control
	        - word length = 8 Bits
	        - one stop-bit
	        - no parity
 * @param  baudrate 	- one can utilize defined macros
 * @retval None
 */
void INIT_usart2_ODOMSG(uint32_t baudrate){
	GPIO_InitTypeDef GPIO_InitStructure;
	USART_InitTypeDef USART_InitStructure;
	NVIC_InitTypeDef NVIC_InitStructure;

	RCC_AHB1PeriphClockCmd(RCC_AHB1Periph_GPIOA, ENABLE);
	RCC_APB1PeriphClockCmd(RCC_APB1Periph_USART2, ENABLE);

	GPIO_PinAFConfig(GPIOA, GPIO_PinSource2, GPIO_AF_USART2); //TX
	GPIO_PinAFConfig(GPIOA, GPIO_PinSource3, GPIO_AF_USART2); //RX

	GPIO_InitStructure.GPIO_Pin = GPIO_Pin_2 | GPIO_Pin_3;
	GPIO_InitStructure.GPIO_OType = GPIO_OType_PP;
	GPIO_InitStructure.GPIO_PuPd = GPIO_PuPd_UP;
	GPIO_InitStructure.GPIO_Speed = GPIO_Speed_50MHz;
	GPIO_InitStructure.GPIO_Mode = GPIO_Mode_AF;

	//GPIO_InitStructure.GPIO_Speed = GPIO_Speed_100MHz;
	GPIO_Init(GPIOA, &GPIO_InitStructure);

	USART_InitStructure.USART_Mode = USART_Mode_Rx | USART_Mode_Tx;
	USART_InitStructure.USART_HardwareFlowControl = USART_HardwareFlowControl_None;
	USART_InitStructure.USART_WordLength = USART_WordLength_8b;
	USART_InitStructure.USART_StopBits = USART_StopBits_1;
	USART_InitStructure.USART_Parity = USART_Parity_No;
	USART_InitStructure.USART_BaudRate = baudrate;
	USART_Init(USART2, &USART_InitStructure);
	// enable the USART2 receive interrupt
	USART_ITConfig(USART2, USART_IT_RXNE, ENABLE);

	NVIC_InitStructure.NVIC_IRQChannel = USART2_IRQn;		 // we want to configure the USART2 interrupts
	NVIC_InitStructure.NVIC_IRQChannelPreemptionPriority = 0x04;// this sets the priority group of the USART2 interrupts
	NVIC_InitStructure.NVIC_IRQChannelSubPriority = 0x04;		 // this sets the sub-priority inside the group
	NVIC_InitStructure.NVIC_IRQChannelCmd = ENABLE;			 // the USART2 interrupts are globally enabled
	NVIC_Init(&NVIC_InitStructure);

	USART_Cmd(USART2, ENABLE);
}


/*
 * @brief  Cofigure GPIO ports and pins
 * @param  None
 * @retval None
 */
void INIT_gpio(void){
	GPIO_InitTypeDef  GPIO_InitStructure;

	// STM32 diodes
	RCC_AHB1PeriphClockCmd(RCC_AHB1Periph_GPIOD, ENABLE);
	GPIO_InitStructure.GPIO_Pin = GPIO_Pin_12 | GPIO_Pin_13 | GPIO_Pin_14 | GPIO_Pin_15;
	GPIO_InitStructure.GPIO_Mode = GPIO_Mode_OUT;
	GPIO_InitStructure.GPIO_OType = GPIO_OType_PP;
	GPIO_InitStructure.GPIO_PuPd = GPIO_PuPd_UP;
	GPIO_InitStructure.GPIO_Speed = GPIO_Speed_50MHz;
	GPIO_Init(GPIOD, &GPIO_InitStructure);

	// 1PPS signal input pin
	RCC_AHB1PeriphClockCmd(RCC_AHB1Periph_GPIOB, ENABLE);
	GPIO_InitStructure.GPIO_Pin = GPIO_Pin_1;
	GPIO_InitStructure.GPIO_Mode = GPIO_Mode_IN;
	GPIO_InitStructure.GPIO_OType = GPIO_OType_PP;
	GPIO_InitStructure.GPIO_PuPd = GPIO_PuPd_UP;
	GPIO_InitStructure.GPIO_Speed = GPIO_Speed_50MHz;
	GPIO_Init(GPIOB, &GPIO_InitStructure);

	// gpioE - debug - encoder quadrature signal simulation
	RCC_AHB1PeriphClockCmd(RCC_AHB1Periph_GPIOE, ENABLE);
	GPIO_InitStructure.GPIO_Pin = GPIO_Pin_0 | GPIO_Pin_1 | GPIO_Pin_2 | GPIO_Pin_3;
	GPIO_InitStructure.GPIO_Mode = GPIO_Mode_OUT;
	GPIO_InitStructure.GPIO_OType = GPIO_OType_PP;
	GPIO_InitStructure.GPIO_PuPd = GPIO_PuPd_UP;
	GPIO_InitStructure.GPIO_Speed = GPIO_Speed_50MHz;
	GPIO_Init(GPIOE, &GPIO_InitStructure);

	//gpioE - debug - simulate 1PPS signal generator
	RCC_AHB1PeriphClockCmd(RCC_AHB1Periph_GPIOE, ENABLE);
	GPIO_InitStructure.GPIO_Pin = GPIO_Pin_6;
	GPIO_InitStructure.GPIO_Mode = GPIO_Mode_OUT;
	GPIO_InitStructure.GPIO_OType = GPIO_OType_PP;
	GPIO_InitStructure.GPIO_PuPd = GPIO_PuPd_UP;
	GPIO_InitStructure.GPIO_Speed = GPIO_Speed_50MHz;
	GPIO_Init(GPIOE, &GPIO_InitStructure);

	// gpioA - debug - button for simulation 1PPS signal
	#ifdef DEBUG_PPS_ON_BUTTON
		RCC_AHB1PeriphClockCmd(RCC_AHB1Periph_GPIOA, ENABLE);
		GPIO_InitStructure.GPIO_Mode = GPIO_Mode_IN;
		GPIO_InitStructure.GPIO_PuPd = GPIO_PuPd_NOPULL;
		GPIO_InitStructure.GPIO_Pin = GPIO_Pin_0;
		GPIO_Init(GPIOA, &GPIO_InitStructure);
	#endif
}

/*
 * @brief  Configure external interrupt for 1PPS signal
 * 			- PB1 - 1PPS signal connected from GPS
 * 			- PA0 - button when DEBUG_PPS_ON_BUTTON defined
 * @param  None
 * @retval None
 */
void INIT_extint_PPS(void){
	GPIO_InitTypeDef   GPIO_InitStructure;
	NVIC_InitTypeDef   NVIC_InitStructure;
	EXTI_InitTypeDef   EXTI_InitStructure;

	RCC_AHB1PeriphClockCmd(RCC_AHB1Periph_GPIOB, ENABLE);
	RCC_APB2PeriphClockCmd(RCC_APB2Periph_SYSCFG, ENABLE);
	GPIO_InitStructure.GPIO_Pin = GPIO_Pin_1;
	GPIO_InitStructure.GPIO_Mode = GPIO_Mode_IN;
	GPIO_InitStructure.GPIO_PuPd = GPIO_PuPd_NOPULL;
	GPIO_Init(GPIOB, &GPIO_InitStructure);

	SYSCFG_EXTILineConfig(EXTI_PortSourceGPIOB, EXTI_PinSource1);

	EXTI_InitStructure.EXTI_Line = EXTI_Line1;
	EXTI_InitStructure.EXTI_Mode = EXTI_Mode_Interrupt;
	EXTI_InitStructure.EXTI_Trigger = EXTI_Trigger_Rising;
	EXTI_InitStructure.EXTI_LineCmd = ENABLE;
	EXTI_Init(&EXTI_InitStructure);

	NVIC_InitStructure.NVIC_IRQChannel = EXTI1_IRQn;
	NVIC_InitStructure.NVIC_IRQChannelPreemptionPriority = 0x01;
	NVIC_InitStructure.NVIC_IRQChannelSubPriority = 0x01;
	NVIC_InitStructure.NVIC_IRQChannelCmd = ENABLE;
	NVIC_Init(&NVIC_InitStructure);

	#ifdef DEBUG_PPS_ON_BUTTON
		RCC_AHB1PeriphClockCmd(RCC_AHB1Periph_GPIOA, ENABLE);
		RCC_APB2PeriphClockCmd(RCC_APB2Periph_SYSCFG, ENABLE);
		GPIO_InitStructure.GPIO_Pin = GPIO_Pin_0;
		GPIO_InitStructure.GPIO_Mode = GPIO_Mode_IN;
		GPIO_InitStructure.GPIO_PuPd = GPIO_PuPd_NOPULL;
		GPIO_Init(GPIOA, &GPIO_InitStructure);

		SYSCFG_EXTILineConfig(EXTI_PortSourceGPIOA, EXTI_PinSource0);

		EXTI_InitStructure.EXTI_Line = EXTI_Line0;
		EXTI_InitStructure.EXTI_Mode = EXTI_Mode_Interrupt;
		EXTI_InitStructure.EXTI_Trigger = EXTI_Trigger_Rising;
		EXTI_InitStructure.EXTI_LineCmd = ENABLE;
		EXTI_Init(&EXTI_InitStructure);

		NVIC_InitStructure.NVIC_IRQChannel = EXTI0_IRQn;
		NVIC_InitStructure.NVIC_IRQChannelPreemptionPriority = 0x02;
		NVIC_InitStructure.NVIC_IRQChannelSubPriority = 0x02;
		NVIC_InitStructure.NVIC_IRQChannelCmd = ENABLE;
		NVIC_Init(&NVIC_InitStructure);
	#endif
}


/*
 * @brief  Configure TIM3
 * 			it will call function SIM_PPS in its interrupt handler
 * @param  None
 * @retval None
 */
void INIT_tim3_SIM_PPS(void){
	TIM_TimeBaseInitTypeDef TIM_TimeBaseStructure;
	NVIC_InitTypeDef NVIC_InitStructure;
	RCC_APB1PeriphClockCmd(RCC_APB1Periph_TIM3, ENABLE);
	/* Simple example of counting real Timer frequency
	  SysClk = 168000000 Hz = 168 MHz
	  HPRE = 1
	  HCLK = SysClk / HPRE = 168 MHz
	  PRE2 = 2
	  APB2_clock = PCLK2 = HCLK/PRE2 = 168/2 MHz = 84 MHz
	  PRE1 = 4
	  APB1_clock = PCLK1 = HCLK/PRE1 = 168/4 MHz = 42 MHz
	  TIM3CLK = 2 * APB1_clock = 84 MHz (Because PRE1 != 1)
	  TIM_Prescaler = 42000 - 1 = prescaler register = TIMx_PSC
	  TIM3_counter_clock = TIM2CLK / (TIM_Prescaler + 1) = 2 kHz = 2000 Hz
	  TIM_Period = 2000 - 1 & auto-reload register = TIMx_ARR
	  TIM3_real_freq = TIM3_counter_clock / (TIM_Period + 1) = 1 Hz  (in up-counting)
	*/
	TIM_TimeBaseStructure.TIM_CounterMode = TIM_CounterMode_Up;
	TIM_TimeBaseStructure.TIM_Prescaler = 42000 - 1;
	TIM_TimeBaseStructure.TIM_Period = SIM_TIM3_PERIOD;
	TIM_TimeBaseStructure.TIM_ClockDivision = 0;

	// TIM3_real_freq = 2kHz / (ODOM_TIM2_PERIOD + 1)

	TIM_TimeBaseInit(TIM3, &TIM_TimeBaseStructure);
	TIM_ITConfig(TIM3, TIM_IT_Update, ENABLE);
	TIM_Cmd(TIM3, ENABLE);

	TIM_ClearITPendingBit(TIM3, TIM_IT_Update);
	NVIC_InitStructure.NVIC_IRQChannel = TIM3_IRQn;
	NVIC_InitStructure.NVIC_IRQChannelPreemptionPriority = 1;
	NVIC_InitStructure.NVIC_IRQChannelSubPriority = 1;
	NVIC_InitStructure.NVIC_IRQChannelCmd = ENABLE;
	NVIC_Init(&NVIC_InitStructure);
}


/*
 * @brief  Configure TIM2 for internal triggering of sending function ODOM_iteration()
 * @param  None
 * @retval None
 */
void INIT_tim_ITERATE(void){
	TIM_TimeBaseInitTypeDef TIM_TimeBaseStructure;
	NVIC_InitTypeDef NVIC_InitStructure;
	RCC_APB1PeriphClockCmd(RCC_APB1Periph_TIM2, ENABLE);
	/* Simple example of counting real Timer frequency
	  SysClk = 168000000 Hz = 168 MHz
	  HPRE = 1
	  HCLK = SysClk / HPRE = 168 MHz
	  PRE2 = 2
	  APB2_clock = PCLK2 = HCLK/PRE2 = 168/2 MHz = 84 MHz
	  PRE1 = 4
	  APB1_clock = PCLK1 = HCLK/PRE1 = 168/4 MHz = 42 MHz
	  TIM2CLK = 2 * APB1_clock = 84 MHz (Because PRE1 != 1)
	  TIM_Prescaler = 42000 - 1 = prescaler register = TIMx_PSC
	  TIM2_counter_clock = TIM2CLK / (TIM_Prescaler + 1) = 2 kHz = 2000 Hz
	  TIM_Period = 2000 - 1 & auto-reload register = TIMx_ARR
	  TIM2_real_freq = TIM2_counter_clock / (TIM_Period + 1) = 1 Hz  (in up-counting)
	*/
	TIM_TimeBaseStructure.TIM_CounterMode = TIM_CounterMode_Up;
	TIM_TimeBaseStructure.TIM_Prescaler = 42000 - 1;
	TIM_TimeBaseStructure.TIM_Period = ODOM_TIM2_PERIOD;
	TIM_TimeBaseStructure.TIM_ClockDivision = 0;

	// TIM2_real_freq = 2kHz / (ODOM_TIM2_PERIOD + 1)

	TIM_TimeBaseInit(TIM2, &TIM_TimeBaseStructure);
	TIM_ITConfig(TIM2, TIM_IT_Update, ENABLE);
	TIM_Cmd(TIM2, ENABLE);

	TIM_ClearITPendingBit(TIM2, TIM_IT_Update);
	NVIC_InitStructure.NVIC_IRQChannel = TIM2_IRQn;
	NVIC_InitStructure.NVIC_IRQChannelPreemptionPriority = 1;
	NVIC_InitStructure.NVIC_IRQChannelSubPriority = 1;
	NVIC_InitStructure.NVIC_IRQChannelCmd = ENABLE;
	NVIC_Init(&NVIC_InitStructure);
}


/*
 * @brief  Configure TIM1 and TIM8 as encoder counters
 * 			TIM1 PE9  = ENCL CH1
 * 			TIM1 PE11 = ENCL CH2
 * 			TIM8 PC6  = ENCR CH1
 * 			TIM8 PC7  = ENCR CH2
 * 		   and sets up their update interrupts
 * @param  None
 * @retval None
 */
void INIT_tim_ENCODER(void){
	TIM_TimeBaseInitTypeDef TIM_TimeBaseStructure;
	GPIO_InitTypeDef GPIO_InitStructure;
	NVIC_InitTypeDef NVIC_InitStructure;

	// TIM1 PE9 PE11 Encoder mode
	RCC_APB2PeriphClockCmd(RCC_APB2Periph_TIM1, ENABLE);
	RCC_AHB1PeriphClockCmd(RCC_AHB1Periph_GPIOE,ENABLE);
	GPIO_InitStructure.GPIO_Pin = GPIO_Pin_9 | GPIO_Pin_11 ;
	GPIO_InitStructure.GPIO_Mode = GPIO_Mode_AF;
	GPIO_InitStructure.GPIO_OType = GPIO_OType_PP;
	GPIO_InitStructure.GPIO_PuPd = GPIO_PuPd_NOPULL;
	GPIO_InitStructure.GPIO_Speed = GPIO_Speed_100MHz;
	GPIO_Init(GPIOE, &GPIO_InitStructure);
	GPIO_PinAFConfig(GPIOE, GPIO_PinSource9, GPIO_AF_TIM1);
	GPIO_PinAFConfig(GPIOE, GPIO_PinSource11, GPIO_AF_TIM1);

	TIM_TimeBaseStructInit(&TIM_TimeBaseStructure);
	TIM_TimeBaseStructure.TIM_Period = 0xFFFF;
	TIM_TimeBaseInit(TIM1, &TIM_TimeBaseStructure);
	TIM_EncoderInterfaceConfig(TIM1, TIM_EncoderMode_TI12, TIM_ICPolarity_Rising, TIM_ICPolarity_Rising);
	TIM1->CNT = HALF_TIM;
	TIM_Cmd(TIM1, ENABLE);

	// TIM8 PC6 PC7 Encoder mode
	RCC_APB2PeriphClockCmd(RCC_APB2Periph_TIM8, ENABLE);
	RCC_AHB1PeriphClockCmd(RCC_AHB1Periph_GPIOC,ENABLE);
	GPIO_InitStructure.GPIO_Pin = GPIO_Pin_6 | GPIO_Pin_7 ;
	GPIO_InitStructure.GPIO_Mode = GPIO_Mode_AF;
	GPIO_InitStructure.GPIO_OType = GPIO_OType_PP;
	GPIO_InitStructure.GPIO_PuPd = GPIO_PuPd_NOPULL;
	GPIO_InitStructure.GPIO_Speed = GPIO_Speed_100MHz;
	GPIO_Init(GPIOC, &GPIO_InitStructure);
	GPIO_PinAFConfig(GPIOC, GPIO_PinSource6, GPIO_AF_TIM8);
	GPIO_PinAFConfig(GPIOC, GPIO_PinSource7, GPIO_AF_TIM8);

	TIM_TimeBaseStructInit(&TIM_TimeBaseStructure);
	TIM_TimeBaseStructure.TIM_Period = 0xFFFF;
	TIM_TimeBaseInit(TIM8, &TIM_TimeBaseStructure);
	TIM_EncoderInterfaceConfig(TIM8, TIM_EncoderMode_TI12, TIM_ICPolarity_Rising, TIM_ICPolarity_Rising);
	TIM8->CNT = HALF_TIM;
	TIM_Cmd(TIM8, ENABLE);

	//TIM1 update interrupt = overflow control
	TIM_ClearITPendingBit(TIM1, TIM_IT_Update);
	NVIC_InitStructure.NVIC_IRQChannel = TIM1_UP_TIM10_IRQn;
	NVIC_InitStructure.NVIC_IRQChannelPreemptionPriority = 0;
	NVIC_InitStructure.NVIC_IRQChannelSubPriority = 0;
	NVIC_InitStructure.NVIC_IRQChannelCmd = ENABLE;
	NVIC_Init(&NVIC_InitStructure);
	TIM_ITConfig(TIM1, TIM_IT_Update, ENABLE);

	//TIM8 update interrupt = overflow control
	TIM_ClearITPendingBit(TIM8, TIM_IT_Update);
	NVIC_InitStructure.NVIC_IRQChannel = TIM8_UP_TIM13_IRQn;
	NVIC_InitStructure.NVIC_IRQChannelPreemptionPriority = 0;
	NVIC_InitStructure.NVIC_IRQChannelSubPriority = 0;
	NVIC_InitStructure.NVIC_IRQChannelCmd = ENABLE;
	NVIC_Init(&NVIC_InitStructure);
	TIM_ITConfig(TIM8, TIM_IT_Update, ENABLE);
}
