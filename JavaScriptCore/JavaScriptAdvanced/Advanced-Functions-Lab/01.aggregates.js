function solve(arr) {
     let service = {
          'sum': (arr) => {
               let sum = arr.reduce((a, b) => a + b);             
               console.log(`Sum = ${sum}`);
          },
          'min': (arr) => {
               console.log(`Min = ${Math.min(...arr)}`);
          },
          'max': (arr) => {
               console.log(`Max = ${Math.max(...arr)}`);
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

     for(let key of Reflect.ownKeys(service)) {
          service[key](arr);
     }
}