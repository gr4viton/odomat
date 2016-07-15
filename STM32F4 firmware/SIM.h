#ifndef DEF_SIM_h
#define DEF_SIM_h
/**
  ******************************************************************************
  * Include
  ******************************************************************************
  */
#include "INIT.h"

void SIM_MAIN_loop(void);
void delay(long int it);
void SIM_1PPS(void);
void SHOW_ON_LEDS(void);
void SIM_ENC(int go_ahead, tick_type dela, GPIO_TypeDef* GPIOx, uint16_t pinA, uint16_t pinB );
void SIM_ENC_loop(long int max_iter, int go_ahead, tick_type dela, GPIO_TypeDef* GPIOx, uint16_t pinA, uint16_t pinB );

#endif
