function roadRadar([currentSpeed, area]) {
     currentSpeed = Number(currentSpeed);
 
     let getLimit = {
          'motorway': (area) => 130,
          'interstate': (area) => 90,
          'city': (area) => 50,
          'residential': (area) => 20
     };
 
     let getInfraction = function (speed, limit) {
         let overSpeed = speed - limit;
 
         if (overSpeed <= 0) {
             return ' ';
         }
         else if (overSpeed > 0 && overSpeed <= 20) {
             return 'speeding';
         }
         else if (overSpeed > 20 && overSpeed <= 40) {
             return 'excessive speeding';
         }
         else if (overSpeed > 40) {
             return 'reckless driving';
         }
     };
 
     console.log(getInfraction(currentSpeed, getLimit[area]()));
 }