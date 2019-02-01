function printTriangleOfStars(a) {
     a= +a;

     (function() { 
          for (let e, d = 1; d <= a; d++) { 
               e='';
               
               for (let f = 1; f <=d; f++) {
                    e+='*';
               }
               console.log(e);
          }
     })(),
     function() {
          for (let e, d = a-1; 1 <= d; d--) { 
               e=''; 
               for (let f = d; 1 <=f; f--) {
                    e+='*';
               }
               console.log(e)
          }
     }();
}