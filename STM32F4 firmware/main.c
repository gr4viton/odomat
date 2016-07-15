/**
  ******************************************************************************
  * @file      main.c
  * @author    Daniel Davidek
  * @version   V1.0
  * @date      31/12/2012
  * @brief     This file contains the main() function and global pointers to
  * 			used data structures.
  *
  ******************************************************************************
  */

#include "INIT.h"

/**
  ******************************************************************************
  * Variable definitions
  ******************************************************************************
  */
// pointer to the currently allocated robot and odomsg configuration
ODOM_robot* 		currob;
ODOM_communication* curmsg;

/**
  ******************************************************************************
  * Function definitions
  ******************************************************************************
  */
int main(void)
{
	// initialize peripherals
	INIT_all();

	// turn off buffer mode for printf
	setvbuf( stdout, 0, _IONBF, 0 );

	// allocate the space for robot and communication configuration
	ODOM_robot rob;
		currob = &rob;
	ODOM_communication msg;
		curmsg = &msg;

	// initialize robot and message configuration
	ODOM_INIT_robot_def(currob);
	ODOM_INIT_communication(&msg);

	//ODOM_SEND_actualmsg(currob, curmsg);
	while(1){
		// interrupt function are active
		#ifdef DEBUG_SIM_MAIN_LOOP
			SIM_MAIN_loop();
		#endif
	}
}
