function solve(n) {
     let daysOfWeek = (day) => ['Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday', 'Sunday'].indexOf(day);

     console.log(daysOfWeek(n) > -1 ? daysOfWeek(n) + 1 : 'error');
}