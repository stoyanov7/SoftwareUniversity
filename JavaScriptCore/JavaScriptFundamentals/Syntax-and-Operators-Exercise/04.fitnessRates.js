function solve(day, service, time) {
    let price = 0;
    if (day == "Monday" || day == "Tuesday" || day == "Wednesday" || day == "Thursday" || day == "Friday") {
        if (service == "Fitness") {
            if (time >= 8.00 && time <= 15.00) {
                price = 5.00;
            }
            else {
                price = 7.50;
            }
        }
        else if (service == "Sauna") {
            if (time >= 8.00 && time <= 15.00) {
                price = 4.00
            }
            else {
                price = 6.50;
            }
        }
        else if (service == "Instructor") {
            if (time >= 8.00 && time <= 15.00) {
                price = 10.00;
            }
            else {
                price = 12.50;
            }
        }
    } 
    else {
        if (service == "Fitness") {
            price = 8.00;
        }
        else if (service == "Sauna") {
            price = 7.00;
        } 
        else if (service == "Instructor") {
            price = 15.00;
        }
    }
    console.log(price);
}