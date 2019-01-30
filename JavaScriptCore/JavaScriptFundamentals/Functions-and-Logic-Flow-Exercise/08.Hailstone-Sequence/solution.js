function getNext() {
    let number = +document.getElementById('num').value;
    let result = [number];

    while (number !== 1) {
        if (number % 2 === 0) {
            number = number / 2;
            result.push(number);
        } 
        else {
            number = number * 3 + 1;
            result.push(number);
        }
    }

    document.getElementById('result').textContent = `${result.join(' ')} `;
}