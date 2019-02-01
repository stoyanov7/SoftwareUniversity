function solve(arr) {
     let results = {};
 
     for (var i = 0; i < arr.length; i++) {
         let tokens = arr[i].split('<->').filter(a => a !== '');
         let [town, population] = [tokens[0], tokens[1]];
 
         if (!results.hasOwnProperty(town)) {
             results[town] = Number(population);
         } 
         else {
             results[town] += Number(population);
         } 
     }
 
     for (let j = 0; j < Object.keys(results).length; j++) {
         console.log(`${Object.keys(results)[j]}: ${Object.values(results)[j]}`);
     }
 }