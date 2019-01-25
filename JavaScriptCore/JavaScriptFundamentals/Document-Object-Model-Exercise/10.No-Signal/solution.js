function solve() {
	let horizontalRange = Math.random() * (20 - 1) + 20;
	let verticalRange = Math.random() * (20 - 1) + 20;

	setTimeout(() => {
		let exerciseElement = document.querySelector('#exercise div');
		exerciseElement.style.marginLeft = horizontalRange + '%';
		exerciseElement.style.marginTop = verticalRange + 'vh';

		solve();
	}, 2000);
}