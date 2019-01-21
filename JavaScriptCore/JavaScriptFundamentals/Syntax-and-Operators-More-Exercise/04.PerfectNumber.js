function solve(arr) {
    let arrLength = arr.length;
    let perfectNums = [];

    for (let i = 0; i < arrLength; i++) {
      let divisors = findDivisors(arr[i]);

      if (divisors.length > 1) {
        let sum = 0;
        divisors.forEach(function(vals) {
          sum += vals;

          if (sum === arr[i] && (sum + arr[i]) / 2 === arr[i]) {
            perfectNums.push(arr[i]);
          }
        });
      }
    }
  
    if (perfectNums.length > 0) {
      console.log(perfectNums.join(", "));
    } 
    else {
      console.log("No perfect number");
    }
  
    function findDivisors(num) {
      let divisors = [];
      for (let i = 1; i < num; i++) {
        if (num % i === 0) {
          divisors.push(i);
        }
      }
      
      return divisors;
    }
  }
  