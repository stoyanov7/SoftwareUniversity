function solve(day, service, hour) {
    let dayOfWeek = (day) => ['Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday', 'Sunday'].indexOf(day);

    let services = {
        'Fitness': (day, hour) => day <= 4 ? (hour <= 15 ? 5.00 : 7.50) : 8.00,
        'Sauna': (day, hour) => day <= 4 ? (hour <= 15 ? 4.00 : 6.50) : 7.00,
        'Instructor': (day, hour) => 4 ? (hour <= 15 ? 10.00 : 12.50) : 15.00
    };

    return services[service] (dayOfWeek(day), hour);
}