function typeOfNumber(n) {
     n = Number(n);
 
     if (n % 2 == 0) {
         console.log('even');
     }
     else if (n % 2 == 1 || n % 2 == -1) {
         console.log('odd');
     }
     else {
         console.log('invalid');
     }
 }