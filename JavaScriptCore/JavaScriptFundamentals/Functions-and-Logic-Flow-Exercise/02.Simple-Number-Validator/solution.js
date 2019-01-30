function validate() {
    let button = document.querySelector('button');
    let input = document.querySelector('input');
    let weightPosition = [2, 4, 8, 5, 10, 9, 7, 3, 6];
    let sum = 0;

    button.addEventListener('click', event => {        
        let lastDigit = input.value[input.value.length - 1];

        for (let i = 0; i < 9; i++) {
            let temp1 = input.value[i];
            let temp2 = weightPosition[i];

            sum += temp1 * temp2;
        }

        let reminder = sum % 11;

        if (reminder === 10) {
            reminder = 0;
        }

        let responce = document.getElementById('response');

        if (+lastDigit === reminder) {
            responce.textContent = 'This number is Valid!'
        }
        else {
            responce.textContent = 'This number is NOT Valid!'
        }
    });
}