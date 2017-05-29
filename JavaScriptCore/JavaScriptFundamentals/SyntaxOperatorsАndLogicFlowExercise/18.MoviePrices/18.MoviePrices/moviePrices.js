function moviePrices(movieTitle, day) {
    movieTitle.toLowerCase();
    day.toLowerCase();

    let price = 0;
    let isWeekend = day === 'saturday' || day === 'sunday';
    let isWorkday = day === 'monday' || day === 'tuesday' || day === 'wednesday' || day === 'thursday' || day === 'friday';

    switch (movieTitle) {
        case 'the godfather':
            if (day === 'monday') {
                price = 12;
            }
            else if (day === 'tuesday') {
                price = 10;
            }
            else if (day === 'wednesday' || day === 'friday') {
                price = 15;
            }
            else if (day === 'thursday') {
                price = 12.50;
            }
            else if (day === 'saturday') {
                price = 25;
            }
            else if (day === 'sunday') {
                price = 30;
            }
            else price = 'error';
            break;

        case 'schindler\'s list':
            if (isWeekend) {
                price = '15';
            }
            else if (isWorkday) {
                price = 8.50;
            }
            else {
                price = 'error';
            }
            break;

        case 'casablanca':
            if (isWeekend) {
                price = '10';
            }
            else if (isWorkday) {
                price = 8;
            }
            else {
                price = 'error';
            }
            break;

        case 'the wizard of oz':
            if (isWeekend) {
                price = '15';
            }
            else if (isWorkday) {
                price = 10;
            }
            else {
                price = 'error';
            }
            break;

        default:
            price = 'error';
            break;
    }

    console.log(price);
}