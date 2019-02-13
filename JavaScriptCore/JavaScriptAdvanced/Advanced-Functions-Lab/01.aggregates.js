function solve(arr) {
     let service = {
          'sum': (arr) => {
               let sum = arr.reduce((a, b) => a + b);             
               console.log(`Sum = ${sum}`);
          },
          'min': (arr) => {
               console.log(`Min = ${Math.min.apply(null, arr)}`);
          },
          'max': (arr) => {
               console.log(`Max = ${Math.max.apply(null, arr)}`);
          },
          'product': (arr) => {
               let product = arr.reduce((a, b) => a * b);
               console.log(`Product = ${product}`);
          },
          'join': (arr) => {
               let join = arr.toString().split(',').join('');
               console.log(`Join = ${join}`);
          }
     };

     service['sum'](arr);
     service['min'](arr);
     service['max'](arr);
     service['product'](arr);
     service['join'](arr);
}