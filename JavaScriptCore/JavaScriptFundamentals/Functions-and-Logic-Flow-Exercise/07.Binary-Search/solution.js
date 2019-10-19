function binarySearch() {
    let numbers = $('#arr').val().split(', ');
    let numberForSearch = $('#num').val();

    let index = numbers.indexOf(numberForSearch);

    if (index !== -1) {
        $('#result').text(`Found ${numberForSearch} at index ${index}`);
    } else {
        $('#result').text(`${numberForSearch} is not in the array`);
    }
}