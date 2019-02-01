function gradsToRadians(grad) {
     grad = Number(grad);
     let diffDeg = 400 / 360;
     let convert = grad / diffDeg;
     convert %= 360;
 
     if (convert < 0) {
         convert += 360;
     }
 
     console.log(convert);
 }