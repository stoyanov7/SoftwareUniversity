class Kitchen {
     constructor(budget, menu, productsInStock, actionsHistory) {
          this.budget = budget;
          this.menu = {};
          this.productsInStock = {};
          this.actionsHistory = [];
     }

     loadProducts(products) {
          for (const product of products) {
               let tokens = product.split(' ');
               let productName = tokens[0];
               let productQuantity = Number(tokens[1]);
               let productPrice = Number(tokens[2]);

               if (this.budget > productPrice) {
                    if (!this.productsInStock.hasOwnProperty(productName)) {
                         this.productsInStock[productName] = 0;
                    }

                    this.productsInStock[productName] += productQuantity;
                    this.budget -= productPrice;

                    this.actionsHistory.push(`Successfully loaded ${productQuantity} ${productName}`);
               } else {
                    this.actionsHistory.push(`There was not enough money to load ${productQuantity} ${productName}`);
               }
          }

          return this.actionsHistory.join('\n');
     }

     addToMenu(meal, neededProducts, price) {
          if (this.menu.hasOwnProperty(meal)) {
               return `The ${meal} is already in the our menu, try something different.`;
          }

          const products = {};

          for (let product of neededProducts) {
               const [name, priceStr] = product.split(' ');
               products[name] = Number(priceStr);
          }

          this.menu[meal] = { products, price };

          return `Great idea! Now with the ${meal} we have ${Object.keys(this.menu).length} meals in the menu, other ideas?`;
     }
}

showTheMenu() {
     const menuArr = Object.entries(this.menu);

     if (menuArr.length === 0) {
          return 'Our menu is not ready yet, please come later...';
     }

     return menuArr.map(a => `${a[0]} - $ ${a[1].price}`).join('\n') + '\n';
}

// Input 1
let kitchen = new Kitchen(1000);
console.log(kitchen.loadProducts(['Banana 10 5', 'Banana 20 10', 'Strawberries 50 30', 'Yogurt 10 10', 'Yogurt 500 1500', 'Honey 5 50']));

// Input 2
console.log(kitchen.addToMenu('frozenYogurt', ['Yogurt 1', 'Honey 1', 'Banana 1', 'Strawberries 10'], 9.99));
console.log(kitchen.addToMenu('Pizza', ['Flour 0.5', 'Oil 0.2', 'Yeast 0.5', 'Salt 0.1', 'Sugar 0.1', 'Tomato sauce 0.5', 'Pepperoni 1', 'Cheese 1.5'], 15.55));
