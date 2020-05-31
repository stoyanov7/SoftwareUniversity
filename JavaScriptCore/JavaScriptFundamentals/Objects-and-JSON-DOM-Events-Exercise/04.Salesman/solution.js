function solve() {
  let storage = {};
  let profit = 0;

  // add
  $('button').eq(0).click(() => {
    let products = JSON.parse($('textarea').eq(0).val());

    for (let item of products) {
      if (!storage.hasOwnProperty(item.name)) {
        storage[item.name] = {
          price: item.price,
          quantity: +item.quantity
        };
      } else {
        storage[item.name] = {
          price: item.price,
          quantity: storage[item.name].quantity + item.quantity
        };
      }

      $('textarea').eq(2).append(`Successfully added ${item.quantity} ${item.name}. Price: ${item.price}\n`);
    }  
  });

  // buy
  $('button').eq(1).click(() => {
    let product = JSON.parse($('textarea').eq(1).val());

    if (storage.hasOwnProperty(product.name) && storage[product.name].quantity >= product.quantity) {
      storage[product.name].quantity -= product.quantity;
      $('textarea').eq(2).append(`${product.quantity} ${product.name} sold for ${product.quantity * product.price}.\n`);

      profit += product.quantity * storage[product.name].price;
    } else {
      $('textarea').eq(2).append('Cannot complete order.\n');
    }
  });

  $('button').eq(2).click(() => {
    $('textarea').eq(2).append(`Profit ${profit.toFixed(2)}.\n`);
    
    $('button').eq(0).off('click');
    $('button').eq(1).off('click');
    $('button').eq(2).off('click');
  });
}