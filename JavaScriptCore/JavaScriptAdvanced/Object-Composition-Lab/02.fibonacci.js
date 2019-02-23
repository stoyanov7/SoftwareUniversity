function getFibonator() {
     let f1 = 0;
     let f2 = 1;

     return () => {
         let sum = f1 + f2;
         f1 = f2;
         f2 = sum;

         return f1;
     };
 }