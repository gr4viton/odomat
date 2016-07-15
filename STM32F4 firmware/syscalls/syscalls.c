/**************************************************************************//*****
 * @file     stdio.c
 * @brief    Implementation of newlib syscall
 ********************************************************************************/

#include <stdio.h>
#include <stdarg.h>
#include <sys/types.h>
#include <sys/stat.h>

#include "INIT.h"

#undef errno
extern int errno;
extern int  _end;

caddr_t _sbrk ( int incr )
{
  static unsigned char *heap = NULL;
  unsigned char *prev_heap;

  if (heap == NULL) {
    heap = (unsigned char *)&_end;
  }
  prev_heap = heap;

  heap += incr;

  return (caddr_t) prev_heap;
}

int link(char *old, char *new) {
return -1;
}

int _close(int file)
{
  return -1;
}

int _fstat(int file, struct stat *st)
{
  st->st_mode = S_IFCHR;
  return 0;
}

int _isatty(int file)
{
  return 1;
}

int _lseek(int file, int ptr, int dir)
{
  return 0;
}


int _read(int file, char *ptr, int len) {
	/*
 int c, rxCount = 0;

 (void) file;

 while (len--) {
  if ((c = GetChar()) != -1) {       // Getchar Function need to be replaced by the function you used to get values.
   *ptr++ = c;
   rxCount++;
  } else {
   break;
  }
 }

 if (rxCount <= 0) {
  return -1; // Error exit

 }

 return rxCount;*/
	return(0);
}

int _write(int file, char *ptr, int len) {
	int i = len;
	for (; i > 0; i--)
	{
		if (*ptr == 0) break;
		USART_SendData(USART_PRINTF, (char) (*ptr));
		while (USART_GetFlagStatus(USART_PRINTF, USART_FLAG_TC) == RESET);
		ptr++;
	}
	return len;
}

void abort(void)
{
  /* Abort called */
  while(1);
}
          
/* --------------------------------- End Of File ------------------------------ */
