function solve() {
    let buttons = Array.from(document.getElementsByTagName('button'));
    let inputNumber = document.querySelector('input');
    let output = document.getElementById('output');

    buttons.forEach(btn => {
        btn.addEventListener('click', event => {
            let service = {
                'Chop': (n) => {
                    if (output.textContent) {
                        return output.textContent / 2;
                    }
                    else {
                        return n / 2;
                   }
                },
                'Dice': (n) => {
                    if (output.textContent) {
                        return Math.sqrt(+output.textContent);
                    }
                    else {
                        return Math.sqrt(+n);
                    }
                },
                'Spice': (n) => {
                    if (output.textContent) {
                        return +output.textContent + 1;
                    } else {
                        return n + 1;
                    }
                },
                'Bake': (n) => {
                    if (output.textContent) {
                        return output.textContent * 3;
                    } else {
                        return n * 3;
                    }
                },
                'Fillet': (n) => {
                    if (output.textContent) {
                        return output.textContent * 0.8;
                    } else {
                        return n * 0.8;
                    }
                }
            };
            
            output.innerHTML = service[btn.textContent] (inputNumber.value);
        });
    });
}
