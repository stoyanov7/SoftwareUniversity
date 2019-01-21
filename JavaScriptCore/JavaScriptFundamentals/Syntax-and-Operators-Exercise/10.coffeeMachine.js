function solve(input) {
    let totalSum = 0;

    for (let value of input) {
        let token = value.split(', ');
        let coins = token[0];
        let drink = token[1];
        let price = 0;

        if (drink == 'coffee') {
            let coffeeType = token[2];

            if (coffeeType == 'caffeine') {
                price = 0.80;
            } 
            else {
                price = 0.90;
            }
            if (token[3] == 'milk') {
                let milkPrice = Number(parseFloat(price * 0.10).toFixed(1));
                price += milkPrice;

                if (token[4] > 0) {
                    price += 0.10;
                }
            } 
            else if (token[3] > 0) {
                price += 0.10;
            }
        } 
        else {
            price = 0.80;

            if (token[2] == 'milk') {
                let milkPrice = Number(parseFloat(price * 0.10).toFixed(1));
                price += milkPrice;

                if (token[3] > 0) {
                    price += 0.10;
                }
            } 
            else if (token[2] > 0) {
                price += 0.10;
            }
        }

        let change = coins - price;
        let moneyNeeded = price - coins;
        
        if (coins >= price) {
            console.log(`You ordered ${drink}. Price: ${price.toFixed(2)}$ Change: ${change.toFixed(2)}$`)
            totalSum += price;
        } 
        else {
            console.log(`Not enough money for ${drink}. Need ${moneyNeeded.toFixed(2)}$ more.`);
        }
    }

    console.log(`Income Report: ${totalSum.toFixed(2)}$`);
}