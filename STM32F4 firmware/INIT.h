//
/*
 *
 * LEDS   = pd12,13,14,15
 * usart2 = ODO+PC - tx=pa2,  rx=pa3
 * usart3 = GPS    - tx=pb10, rx=pb11
 * EXTI1  = PPS - pb1
 *
 * TIM1 = ENCL - ch1=pe9, ch2=pe11
 * TIM8 = ENCR - ch1=pc6, ch2=pc7
 *
 * TIM2 = iteration - TIM2_IRQn
 * TIM3 = SIM_PPS - TIM3_IRQn
 *
 * DEBUG
 * SIMENC = pins - ENCL=pe0,pe1  ENCR= pe2,pe3
 * SIMPPS = pins - pe4 --> now pe6
 * SIMPPS = tim  - tim..
 * SIMPPS = btn  - pa0
 *
 *
 * messages
 * STM32 -> PC
 * ODOMSG
 * GCMSG
 *
 * PC -> STM32
 * PCMSG (= CONFMSG= usart2in(OLD))
 */

#ifndef DEF_INIT_h
#define DEF_INIT_h

/**
  ******************************************************************************
  * Macro definitions
  ******************************************************************************
  */
// Encoder timers offset
#define HALF_TIM 0x7FFF
#define USART3_GPS USART3
#define USART_GPS USART3
#define USART2_ODO USART2
#define USART_ODO USART2

//// DEBUG options
// Simulate data from encoders in main loop
#define DEBUG_SIM_MAIN_LOOP

// on PPS extint sprintf ticks into curmsg->usart2in
//#define DEBUG_PPS_TICKS

// toggle defined led on TIM2 periodically
// #define DEBUG_LED_ON_TIM2
// #define DEBUG_LED_ON_TIM3
// #define DEBUG_LED_ON_PPS
// #define DEBUG_LED_ON_SIM_LOOP_END

#define DEBUG_TIM2_LED 			GPIO_Pin_12
#define DEBUG_TIM3_LED			GPIO_Pin_14
#define DEBUG_ON_PPS_LED		GPIO_Pin_15
#define DEBUG_SIM_LOOP_END_LED 	GPIO_Pin_13

// work as if 1pps signal comes on button PA0
#define DEBUG_PPS_ON_BUTTON

//remeber -there is no loop without sim
//#define DEBUG_SIM_PPS_IN_LOOP

#define DEBUG_SIM_PPS_ON_TIM3


//#define DEBUG_SIM_PPS_TIM




// macro definitions of common periods
#define SIM_TIM3_PERIOD_1HZ  2000 - 1
#define SIM_TIM3_PERIOD_2HZ  1000 - 1
#define SIM_TIM3_PERIOD_10HZ  200 - 1
#define SIM_TIM3_PERIOD_100HZ 20 - 1

// setting of tim3 period = frequency of SIM_1PPS triggering
#define SIM_TIM3_PERIOD SIM_TIM3_PERIOD_2HZ





// to expose M_PI macro definition
#define _USE_MATH_DEFINES
#define M_PI2 6.283185307

/**
  ******************************************************************************
  * Include
  ******************************************************************************
  */
#include <math.h>
#include <stdio.h>
//#include <string.h>

//#include "cmsis_boot/startup/startup_stm32f4xx.c"
#include "stm32f4xx.h"
#include "misc.h"

#include "ODOM.h"
#include "PERIPH.h"
#include "SIM.h"

/**
  ******************************************************************************
  * Variable declarations
  ******************************************************************************
  */
extern USART_TypeDef* USART_PRINTF;

/**
  ******************************************************************************
  * Function declarations
  ******************************************************************************
  */
void INIT_all				(void);
void INIT_gpio				(void);
void INIT_extint_ENCODER	(void);
void INIT_extint_PPS		(void);
void INIT_usart3_GPS		(uint32_t baudrate);
void INIT_usart2_ODOMSG		(uint32_t baudrate);
void INIT_tim_ITERATE		(void);
void INIT_tim_ENCODER		(void);
void INIT_tim3_SIM_PPS		(void);

void delay(long int it);


#endif
