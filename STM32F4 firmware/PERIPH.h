#ifndef DEF_PERIPH_h
#define DEF_PERIPH_h

/**
  ******************************************************************************
  * Include
  ******************************************************************************
  */
#include "INIT.h"

/**
  ******************************************************************************
  * Function declarations
  ******************************************************************************
  */
void USART_sendchar(USART_TypeDef *USARTx, char *ch);
#endif
