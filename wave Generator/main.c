/*
 * main.c
 *
 * Created: 11/3/2022 5:49:02 PM
 *  Author: acer
 */ 
#include <avr/io.h>
#include <avr/interrupt.h>
#define F_CPU 1000000
#include <util/delay.h>

#include "waveform.h"

int main(void) {

	WAVE_Init();
	
	sei();
	
	while (1)
	{
		WAVE_MainFunction();
	}
	return 0; // never reached
}
