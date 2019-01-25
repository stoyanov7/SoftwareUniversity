function solve() {
	let button = document.querySelector('button');
	let isNumberValid = false;

	button.addEventListener('click', event => {
		let inputNumbers = document.querySelector('input').value.split(' ');
		
		if (inputNumbers.length === 6) {
			inputNumbers.forEach(number => {
				let parsedNumber = +number;
				let allNumbers = document.getElementById('allNumbers');

				if (parsedNumber > 0 || parsedNumber <= 49) {
					isNumberValid = true;
				}
			})
		}

		if (isNumberValid) {
			for (let i = 1; i <= 49; i++) {
				let createDiv = document.createElement('div');
				createDiv.textContent = i;
				createDiv.classList.add('numbers');

				if (inputNumbers.indexOf(`${i}`) > -1) {
					createDiv.style.background = 'orange'
				}

				allNumbers.appendChild(createDiv);
			}
		}
	})
}