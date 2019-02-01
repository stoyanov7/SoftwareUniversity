function solve() {
    let buttons = Array.from(document.getElementsByTagName('button'));
    let expressionElement = document.getElementById('expressionOutput');
    let resultElement = document.getElementById('resultOutput');
    let expression = '';

    buttons.forEach(btn => {
        btn.addEventListener('click', event => {
            if (btn.textContent === '=') {
                let tokens = expression.split(' ');
                let leftOperand = Number(tokens[0]);
                let operator = tokens[1];
                let rightOperand = Number(tokens[2]);

                if (!leftOperand || !operator || !rightOperand) {
                    resultElement.textContent = 'NaN';
                } 
                else {
                    let result = eval(`${leftOperand} ${operator} ${rightOperand}`);
                    resultElement.textContent = result;
                    return;
                }
            } 

            if (!isNaN(btn.textContent) || btn.textContent === ".") {
                expression += btn.textContent;
            } 
            else if (btn.textContent === 'Clear') {
                expression = '';
                resultElement.textContent = '';
                expressionElement.textContent = '';
            } 
            else {
                expression += ` ${btn.textContent} `;
            }

            expressionElement.textContent = expression;
        });
    });
}