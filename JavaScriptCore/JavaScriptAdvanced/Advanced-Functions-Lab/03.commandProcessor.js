function solve(arr) {
     let result = '';

     let service = {
          'append': (str) => {
               result += str;
          },
          'removeStart': (count) => {
               result = result.slice(count);
          },
          'removeEnd': (count) => {
               result = result.slice(0, -count);
          },
          'print': () => {
               console.log(result);
          }
     };

     for (let i = 0; i < arr.length; i++) {
          let token = arr[i].split(' ');
          let command = token[0];
          let str = token[1];

          service[command](str);
     }
}