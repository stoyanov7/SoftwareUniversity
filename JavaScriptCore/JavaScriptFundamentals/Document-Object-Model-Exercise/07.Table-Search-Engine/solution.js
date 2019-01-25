function solve() {
    let button = document.getElementById('searchBtn');

    button.addEventListener('click', event => {
        let tbodyElements = document.querySelector('tbody');
        let selectedTrElements = tbodyElements.getElementsByTagName('tr');

        for (let tr of selectedTrElements) {
            tr.classList.remove('select');
        }

        let inputText = document.getElementById('searchField');
        let searchedText = inputText.value.toLowerCase();
        inputText.value = '';

        let trElements = tbodyElements.getElementsByTagName('tr');

        for (let tr of trElements) {
            let tdElements = tr.getElementsByTagName('td');
            
            for (let td of tdElements) {
                if (td.textContent.toLowerCase().includes(searchedText)) {
                    tr.classList.add('select');
                }
            }
        }
    });
}