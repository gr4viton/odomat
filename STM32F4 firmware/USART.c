#include "USART.h"

USART_TypeDef* USART_PRINTF = USART2;

void USART_puts(USART_TypeDef* USARTx, volatile char *s){
	//GPIO_SetBits(GPIOD, GPIO_Pin_13);
	//GPIO_ResetBits(GPIOD, GPIO_Pin_13);
	while(*s){
		GPIO_SetBits(GPIOD, GPIO_Pin_15);
		// wait until data register is empty
		while( !(USARTx->SR & 0x00000040) );
		//puvodne while( !(USARTx->SR & 0x00000040) );
		// if not then  while( !(USARTx->SR & 0×00000080) )
		USART_SendData(USARTx, *s);
		*s++;
	}
	//GPIO_ResetBits(GPIOD, GPIO_Pin_15);
}
