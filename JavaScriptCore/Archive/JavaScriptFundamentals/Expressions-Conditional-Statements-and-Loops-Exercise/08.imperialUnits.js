function convertInchesToFeet(inches) {
     inches = Number(inches);
     let feet = Math.trunc(inches / 12);
 
     console.log(`${feet}'-${inches % 12}"`);
 }