function solve(...args) {
     let argumentsCount = {};

     for (let i = 0; i < args.length; i++) {
          let obj = args[i];
          let type = typeof obj;

          if(!argumentsCount.hasOwnProperty(type)) {
               argumentsCount[type] = 0;
          }
   
          argumentsCount[type]++;

          console.log(`${type}: ${obj}`);
     }

     let sortedKey =  Object.keys(argumentsCount)
          .sort((a, b) => argumentsCount[b] - argumentsCount[a]);

     for (let key of sortedKey) {
         console.log(`${key} = ${argumentsCount[key]}`);
     }
}