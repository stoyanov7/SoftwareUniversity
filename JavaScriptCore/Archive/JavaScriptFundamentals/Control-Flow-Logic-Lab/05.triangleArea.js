function calculateTriangleArea(a, b, c) {
     let semiparameter = (a + b + c) / 2;
     
     let area = Math.sqrt(
         semiparameter *
         (semiparameter - a) *
         (semiparameter - b) *
         (semiparameter - c));
 
     console.log(area);
 }