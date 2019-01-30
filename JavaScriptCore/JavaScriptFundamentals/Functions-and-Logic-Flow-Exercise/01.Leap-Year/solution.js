function leapYear() {
    let button = document.querySelector('button');
    let year = document.querySelector('input');   
    let yearH2 = document.querySelector('#year h2');
    let yearInnerDiv = document.querySelector('#year div');

    button.addEventListener('click', event => {
        if (isYearLeap(year.value)) {
            yearH2.innerHTML = "Leap Year";
            yearInnerDiv.innerHTML = year.value;
        }
        else {
            yearH2.innerHTML = "Not Leap Year";
            yearInnerDiv.innerHTML = year.value;
        }

        year.value = ""
    });

    function isYearLeap(year) {
        return ((year % 4 == 0) && (year % 100 != 0)) || (year % 400 == 0);
    }
}