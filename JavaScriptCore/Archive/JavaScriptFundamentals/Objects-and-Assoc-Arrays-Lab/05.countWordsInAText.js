function solve(input) {
     let result = {};
 
     input.join(' ')
         .split(/[^\w]+/)
         .filter(a => a !== '')
         .forEach(s => {
             if (!result.hasOwnProperty(s)) {
                 result[s] = 0;
             }
 
             result[s]++;
         });
 
     console.log(JSON.stringify(result));
 }