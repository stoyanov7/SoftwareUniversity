function solve() {
    createOptionElements();    
    let button = Array.from(document.getElementsByTagName('button'));

    button.forEach(btn => {
        btn.addEventListener('click', event => {
            let numberToConvert = document.getElementById('input').value;
            let selectedMenu = document.getElementById('selectMenuTo').value;

            if (selectedMenu === 'binary') {
                let binaryResult = (+numberToConvert).toString(2);
			    let resultElement = document.getElementById('result');
                resultElement.value = binaryResult;
            }
            else if (selectedMenu === 'hexadecimal') {
                let hexadeicmalResult = (+numberToConvert).toString(16);
			    let resultElement = document.getElementById('result');
                resultElement.value = hexadeicmalResult.toUpperCase();
            }
        });
    });

    function createOptionElements() {
        let selectElements = document.getElementById('selectMenuTo');

        let optionFirstElement = document.createElement('option');
        optionFirstElement.value = 'binary';
        optionFirstElement.textContent = 'Binary';
    
        let optionSecondElement = document.createElement('option');
        optionSecondElement.value = 'hexadecimal';
        optionSecondElement.textContent = 'Hexadecimal';
    
        selectElements.appendChild(optionFirstElement);
        selectElements.appendChild(optionSecondElement);
    }
}