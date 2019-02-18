function solve(arr, startIndex, endIndex) {
     if (!Array.isArray(arr)) {
          return NaN;
     }

     if (startIndex <= 0) {
          startIndex = 0;
     }

     if (endIndex >= arr.length) {
          endIndex = arr.length - 1;
     }

     return arr
          .slice(startIndex, endIndex + 1)
          .map(Number)
          .reduce((a , b) => a + b, 0);
}