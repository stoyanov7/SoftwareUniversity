function solve(arr, command) {    
     if (command === 'asc') {
          return arr.sort((a, b) => a - b);
     } else {
          return arr.sort((a, b) => b - a);
     }
}