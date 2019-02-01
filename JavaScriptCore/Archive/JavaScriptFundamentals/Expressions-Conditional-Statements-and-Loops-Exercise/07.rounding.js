function rounding(arr) {
     let [number, precision] = arr;
 
     if (precision > 15) {
         precision = 15;
     }
 
     let result = number.toFixed(precision);
     result = parseFloat(result);
     console.log(result);
 }