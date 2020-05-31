function solution() {
	let toyType = $('#toyType').val();
	let toyPrice = $('#toyPrice').val();
	let toyDescription = $('#toyDescription').val();

	$('button').click(function () {
		if (toyType === '' ||
			isNaN(toyPrice) ||
			toyDescription === '' ||
			toyDescription.length < 50) {
			return;
		}
		
		let giftDiv = $('<div>', { class: 'gift' })
			.append($('<img>', { src: 'gift.png' }))
			.append($('<h2>').text(toyType))
			.append($('<p>').text(toyDescription))
			.append(
				$('<button>').text(`Buy it for $${toyPrice}`)
					.click(function() {
						$(this).parent().remove();
					})
			);
		
		$('#christmasGiftShop').append(giftDiv);
	});

	$('#toyType').val('');
	$('#toyPrice').val('');
	$('#toyDescription').val('');
}