function solve(arr1, arr2, arr3) {
    var tempArr = arr1.filter(function(value) {
      return arr2.indexOf(value) !== -1;
    });
  
    var newArr = tempArr.filter(function(value) {
      return arr3.indexOf(value) !== -1;
    });
  
    var avg = newArr.reduce((a, b) => a + b, 0) / newArr.length;
  
    console.log(`The common elements are ${newArr.sort().join(", ")}.`);
    console.log(`Average: ${avg}.`);
    console.log(`Median: ${median(newArr)}.`);
  
    function median(values) {
      values.sort(function(a, b) {
        return a - b;
      });
  
      if (values.length === 0) {
        return 0;
      }
  
      var half = Math.floor(values.length / 2);
  
      if (values.length % 2) {
        return values[half];
      }
      else {
        return (values[half - 1] + values[half]) / 2.0;
      }
    }
  }