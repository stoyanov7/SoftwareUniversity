function getTownSales(input) {
     let map = new Map();

     for (let i = 0; i < input.length; i++) {
          let currentArgs = input[i]
               .split(/[->:]/)
               .filter(x => x !== '')
               .map(x => x.trim());

          let [town, product, amount, price] = [currentArgs[0], currentArgs[1], +currentArgs[2], +currentArgs[3]];

          if (!map.has(town)) {
               map.set(town, new Map());
          }

          if (!map.get(town).has(product)) {
               map.get(town).set(product, 0);
          }

          map
          .get(town)
          .set(product, map.get(town).get(product) + (amount * price));
     }

     for (let town of map) {
          console.log(`Town - ${town[0]}`);

          for (let city of town[1]) {
               console.log(`$$$${city[0]} : ${city[1]}`);
          }
     }
}