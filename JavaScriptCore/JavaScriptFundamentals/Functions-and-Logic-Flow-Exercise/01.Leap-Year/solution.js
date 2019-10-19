function leapYear() {
    let year = $('input');   
    let yearH2 = $('#year h2');
    let yearInnerDiv = $('#year div');

    $('button').click(() => {
        if (isYearLeap(year.val())) {
            yearH2.html("Leap Year");
            yearInnerDiv.html(year.val());
        } else {
            yearH2.html("Not Leap Year");
            yearInnerDiv.html(year.val());
        }

        year.val("");
    });

    function isYearLeap(year) {
        return ((year % 4 == 0) && (year % 100 != 0)) || (year % 400 == 0);
    }
}