function binarySearch() {
    let numbers = document.getElementById('arr').value.split(', ');
    let numberForSearch = document.getElementById('num').value;

    let index = numbers.indexOf(numberForSearch);

    let result = document.getElementById('result');

    if (index !== -1) {
        result.textContent = `Found ${numberForSearch} at index ${index}`;
    } 
    else {
        result.textContent = `${numberForSearch} is not in the array`;
    }
}