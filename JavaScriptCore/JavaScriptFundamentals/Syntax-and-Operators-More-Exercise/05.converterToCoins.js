function solve(amount, coinValues) {
    let coins = coinValues.sort((a, b) => b - a);
    let result = [];

    for (i = 0; i < coins.length; i++) {
      if (amount - coins[i] >= 0) {
        result.push(coins[i]);
        amount -= coins[i];
        i = -1;
      } 
      else {
      }
    }
    
    console.log(result.join(", "));
  }