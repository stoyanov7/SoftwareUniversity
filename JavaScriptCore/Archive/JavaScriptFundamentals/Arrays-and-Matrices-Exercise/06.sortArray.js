function solve(inputArr) {
     let sortedArr = inputArr
          .sort((a, b) => a - b)
          .sort((a, b) => a.length - b.length);

     console.log(sortedArr.join('\n'));
}