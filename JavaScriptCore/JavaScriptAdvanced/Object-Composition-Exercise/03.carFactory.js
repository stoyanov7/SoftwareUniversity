function solve(carInfo) {
     let getEngine = (() => {
          if (carInfo.power <= 90) {
               return engine = {
                    power: 90,
                    volume: 1800
               };
          } else if (carInfo.power <= 120) {
               return engine = {
                    power: 120,
                    volume: 2400
               };
          } else {
               return engine = {
                    power: 200,
                    volume: 3500
               };
          }
     })();

     let getWheels = (() => {
          let value = carInfo.wheelsize;

          if (carInfo.wheelsize % 2 === 0) {
               value -= 1;
          }

          return [value, value, value, value];
     })();

     let car = {
          model: carInfo.model,
          engine: getEngine,
          carriage: {
               type: carInfo.carriage,
               color: carInfo.color
          },
          wheels: getWheels
     };

     return car;
}