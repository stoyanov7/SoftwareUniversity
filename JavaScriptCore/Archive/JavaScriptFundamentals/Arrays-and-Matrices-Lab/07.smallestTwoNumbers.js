function smallestTwoNumbers(arr) {
     arr = arr.map(Number).sort((a, b) => a - b).slice(0, 2);
 
     console.log(arr.join(" "));
 }