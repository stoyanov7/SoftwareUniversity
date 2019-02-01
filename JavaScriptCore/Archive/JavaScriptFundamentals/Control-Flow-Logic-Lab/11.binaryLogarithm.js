function binaryLogarithm(arr) {
     arr.map(x => +x);
 
     for (let j = 0; j < arr.length; j++) {
         let logarithm = Math.log2(arr[j]);
         console.log(logarithm);
     }
 }