function calcDistance([firstSpeed, secondSpeed, timeInSecond]) {
     firstSpeed = Number(firstSpeed);
     secondSpeed = Number(secondSpeed);
     timeInSecond = Number(timeInSecond);
 
     firstSpeed *= (1000 / 1) * (1 / 60) * (1 / 60);
     secondSpeed *= (1000 / 1) * (1 / 60) * (1 / 60);
     let firstDistance = firstSpeed * timeInSecond;
     let secondDistance = secondSpeed * timeInSecond;
     let distance = Math.abs(firstDistance - secondDistance);
     
     console.log(distance);
 }