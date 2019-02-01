function solve(arr) {
     let result = new Map();
 
     arr.join(' ')
         .toLowerCase()
         .split(/[^\w]+/)
         .filter(a => a !== '')
         .forEach(w => {
               if (!result.has(w)) {
                    result.set(w, 0);
               }
 
         result.set(w, result.get(w) + 1);
     });
 
     let sortedKeys = Array.from(result.keys()).sort();
 
     for (let value of sortedKeys) {
         console.log(`'${value}' -> ${result.get(value)} times`);
     }
 }