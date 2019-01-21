function solve(fruit, weight, pricePerKilo) {
    let need = (weight * pricePerKilo) / 1000;

    console.log(`I need ${need.toFixed(2)} leva to buy ${(weight / 1000).toFixed(2)} kilograms ${fruit}.`)
}