function solve() {
    let products = [];

    $('.product button').click((event) => {        
        let parentNode = $(event.target).parent();
        
        let name = parentNode.find('p').eq(0).text();
        let price = +parentNode.find('p').eq(1).text().split(' ')[1];

        products.push({name, price});
       
        $('textarea').append(`Added ${name} for ${price.toFixed(2)} to the cart.\n`);
    }); 
    
    $('#exercise button').last().click(() => {
        let list = products.map(p => p.name).filter((element, index, arr) => {
            if (arr.indexOf(element) === index) {
                return element;
            }
        });

        let totalPrice = products.map(p => p.price).reduce((a, b) => a + b);

        $('textarea').append(`You bought ${list.join(', ')} for ${totalPrice.toFixed(2)}.`);
    });
}