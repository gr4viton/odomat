#include "INIT.h"

extern USART_TypeDef* USART_PRINTF;
void USART_puts(USART_TypeDef* USARTx, volatile char *s);
