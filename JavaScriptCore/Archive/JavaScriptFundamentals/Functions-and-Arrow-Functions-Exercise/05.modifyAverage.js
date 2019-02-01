function solve(input) {
     let number = input[0];
     while (sumNumbers(number) / number.length <= 5){
         number += '9';
     }
 
     function sumNumbers(number) {
         let sum = 0;

         for (let i = 0; i < number.length; i++) {
             sum += Number(number[i]);
         }

         return sum;
     }

     console.log(number); 
 }