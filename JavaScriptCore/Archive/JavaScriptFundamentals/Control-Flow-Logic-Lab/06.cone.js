function calculateVolumeAndAreaOfCone(radius, height) {
     function pow(number, power) {
         return Math.pow(number, power);
     }
 
     let volume = (1 / 3) * Math.PI * pow(radius, 2) * height;
     let slantHeight = Math.sqrt(pow(radius, 2) + pow(height, 2));
     let lateral = Math.PI * radius * slantHeight;
     let base = Math.PI * pow(radius, 2);
     let totalArea = lateral + base;
 
     console.log(`volume = ${volume}`);
     console.log(`area = ${totalArea}`);
 }