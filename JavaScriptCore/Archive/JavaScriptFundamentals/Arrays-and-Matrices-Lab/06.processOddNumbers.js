function processOddNumbers(arr) {     
     let result = arr.reduce((acc, element, index) => {
          if (index % 2 !== 0) {
               acc.push(element + element);
          }

          return acc;
     }, []);
 
     result.reverse();
     console.log(result);
 }