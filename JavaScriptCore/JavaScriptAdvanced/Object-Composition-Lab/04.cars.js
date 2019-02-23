function solve(args) {
     let cars = {};

     let service = {
          'create': (commands) => {
               let tokens = commands.split(' ');
               let name = tokens[1];

               if (tokens.length > 2) {
                    cars[name] = Object.create(cars[tokens[3]]);
               } else {
                    cars[name] = {};
               }
          },
          'set': (commands) => {
               let tokens = commands.split(' ');
               let name = tokens[1];
               let key = tokens[2];
               let value = tokens[3];

               cars[name][key] = value;
          },
          'print': (commands) => {
               let tokens = commands.split(' ');
               let name = tokens[1];

               let result = [];
               let currentCar = cars[name];

               for (let key in currentCar) {
                    result.push(`${key}:${currentCar[key]}`);
               }

               console.log(result.join(', '));
          }
     };

     for (const command of args) {
          let tokens = command.split(' ')[0];
          service[tokens](command);
     }
}