$include(at89c51cc03.inc)
org	0000h
/*	mov 		a,#00h
	mov 		dptr,#0000h
	movc		a,@a+dptr
	mov			08h,a // Normale RAM Adresse direkt adressierbar

	mov 		a,#00h
	mov 		dptr,#0001h
	movc		a,@a+dptr
	mov			09h,a
	........

	mov	r0,#080h
	mov	a,@r0 // a hat jetzt Inhalt von 80h
	mov	r3,a // Zwischenspeichern in r3
	mov	r0,#081h
	mov	a,@r0 // a hat jetzt Inhalt von 81h
	mov	r0,#080h
	mov	@r0,a // Lade Wert von 81h in 80h
	mov r0,#081h
	mov	a,r3 // R3 hat den Wert von 80h => a
	mov	@r0,a // Lade in 81h Wert von 80h

	LJMP	$
*/

	//Aufgabe4
	//mov a,#32d
	//add a,#16d

	//mov a,#250d
	//add a,#10d

	clr c //Damit nicht das Carry abgezogen wird
	mov a,#32d
	subb a,#16d
	subb a,#10d
	subb a,#17d

	ljmp $

	

end