function evenPositionElements(arr) {
     let result = arr.reduce((acc, element, index) => {
          if (index % 2 === 0) {
               acc.push(element);
          }

          return acc;
     }, []);

     console.log(result.join(' '));
}