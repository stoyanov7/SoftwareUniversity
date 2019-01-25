function solve() {
	let buttons = Array.from(document.getElementsByTagName('button'));
	let sections = Array.from(document.getElementsByTagName('section'));
	
	let questions = 0;
	let result = 0;

	buttons.forEach(btn => {
		btn.addEventListener('click', event => {
			let parentElement = btn.parentElement;
			let radioElements = parentElement.querySelectorAll('input');

			radioElements.forEach(x => {
				if (x.checked) {
					questions++;

					if (questions === 1) {
						if (x.value === '2013') {
							result++;
						}
					}
					else if (questions === 2) {
						if (x.value === 'Pesho') {
							result++;
						}
					}
					else if (questions === 3) {
						if (x.value === 'Nakov') {
							result++;
						}
					}

					if (questions < 3) {
						sections[questions].style.display = 'block';
					}
					else {
						let resultElement = document.getElementById('result');

						if (result === 3) {
							resultElement.textContent += 'You are recognized as top SoftUni fan!';
						}
						else {
							resultElement.textContent += `You have ${result} right answers`;
						}
					}
				}
			})
		})
	})
}