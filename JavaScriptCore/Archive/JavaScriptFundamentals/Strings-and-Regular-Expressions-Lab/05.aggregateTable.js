function aggregateTable(arr) {
     let result = [];
     let sum = 0;
 
     for (let i = 0; i < arr.length; i++) {
         let tokens = arr[i].split('|').filter(x => x.trim());
         let currentTown = tokens[0].trim();
         let currentPrice = Number(tokens[1]);
 
         result.push(currentTown);
         sum += currentPrice;
     }
 
     console.log(result.join(', '));
     console.log(sum);
 }