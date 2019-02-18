(() => {
     let sum = 0;
     
     return function add(num) {
         sum += num;

         add.toString = () => {
             return sum;
         };

         return add;
     };
 })();