function solve() {
  $('button').eq(0).click(() => {
    let textarea = $('textarea').eq(0).val();
    let furnitures = JSON.parse(textarea);

    for (const furniture of furnitures) {      
      let pName = $('<p>').text(`Name: ${furniture.name}`);
      let img = $('<img>', { src: `${furniture.img}` });
      let pPrice = $('<p>').text(`Price: ${furniture.price}`);
      let pDecFactor = $('<p>').text(`Decoration factor: ${furniture.decFactor}`);
      let checkbox = $('<input />', { type: 'checkbox' });

      let div = $('<div>', { class: 'furniture' })
        .append(pName)
        .append(img)
        .append(pPrice)
        .append(pDecFactor)
        .append(checkbox);

      $('#furniture-list').append(div);
    }
  });

  $('button').eq(1).click(() => {
    let checkedFurnitures = $('input:checked').parent();
    let furnitures= [];
    let totalPrice = 0;
    let decorationFactors = [];

    for (const key of checkedFurnitures) {
      let furniture = key.getElementsByTagName('p')[0].innerHTML.split(': ')[1];
      let price = +key.getElementsByTagName('p')[1].innerHTML.split(': ')[1];
      let decorationFactor = +key.getElementsByTagName('p')[2].innerHTML.split(': ')[1];

      furnitures.push(furniture);  
      totalPrice += price;
      decorationFactors.push(decorationFactor);
    }   

    let averageDecFactor = decorationFactors.reduce((a, b) => a + b) / decorationFactors.length;

    $('textarea')
      .last()
      .append(`Bought furnitures: ${furnitures.join(', ')}\n`)
      .append(`Total price: ${totalPrice.toFixed(2)}\n`)
      .append(`Average decoration factor: ${averageDecFactor}`);
  });
}