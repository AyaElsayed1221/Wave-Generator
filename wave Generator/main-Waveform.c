#include <avr/io.h>
#include <avr/interrupt.h>
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
