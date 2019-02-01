function compoundInterest([principal, interest, period, time]) {
     let f = principal * Math.pow((1 + (interest / 100) / (12 / period)), (12 / period) * time);
     console.log(f.toFixed(2));
 }