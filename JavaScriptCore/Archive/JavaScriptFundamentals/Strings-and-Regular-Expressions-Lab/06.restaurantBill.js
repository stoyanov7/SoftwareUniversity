function printBill(input) {
     let products = input
         .filter((x, i) => i % 2 === 0);
     
     let prices = input
         .filter((x,i) => i % 2 !== 0)
         .map(Number);
     
     let sum = prices
         .reduce((a,b) => a + b);
 
     console.log(`You purchased ${products.join(', ')} for a total sum of ${sum}`);
 }