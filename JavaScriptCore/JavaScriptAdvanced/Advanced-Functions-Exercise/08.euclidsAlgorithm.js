function solve(numA, numB) {
     if (numA == 0)
         return numB;
 
     while (numB != 0) {
         if (numA > numB) {
             numA = numA - numB;
         }
         else {
             numB = numB - numA;
         }
     }
 
     return numA;
 }