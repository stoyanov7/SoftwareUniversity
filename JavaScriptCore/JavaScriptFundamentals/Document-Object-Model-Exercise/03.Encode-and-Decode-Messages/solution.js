function solve() {
	let buttons = document.getElementsByTagName('button');
	let textAreas = document.getElementsByTagName('textarea');

	// Encode
	buttons[0].addEventListener('click', () => {
		let encodeMessage = textAreas[0].value;
		let newMessage = '';

		encodeMessage.split('').forEach(ch => {
			let asciiValue = ch.charCodeAt(0) + 1;
			newMessage += String.fromCharCode(asciiValue);
		})

		textAreas[0].value = "";
		textAreas[1].value = newMessage;
	});

	// Decode
	buttons[1].addEventListener('click', () => {
		let decodeMessage = textAreas[1].value;
		let message = '';

		decodeMessage.split('').forEach(ch => {
			let asciiValue = ch.charCodeAt(0) - 1;
			message += String.fromCharCode(asciiValue);
		});

		textAreas[1].value = message;
	});
}