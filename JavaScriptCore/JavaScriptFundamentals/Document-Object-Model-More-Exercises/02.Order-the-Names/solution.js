function solve() {
    let buttonElement = document.querySelector('button');

    buttonElement.addEventListener('click', event => {
        let input = document.querySelector('input');
        let firstLetterIndex = input.value.toLowerCase().charCodeAt(0) - 97;

        if (firstLetterIndex >= 0 && firstLetterIndex <= 25) {
            name = input.value.charAt(0).toUpperCase() + input.value.substr(1).toLowerCase();
            let liElements = document.querySelectorAll('li');
            let li = liElements[firstLetterIndex];
            
            if (li.textContent === "") {
                li.textContent += name;
            } else {
                li.textContent += ", " + name;
            }
    
            document.querySelector('input').value = '';
        }
    });
}