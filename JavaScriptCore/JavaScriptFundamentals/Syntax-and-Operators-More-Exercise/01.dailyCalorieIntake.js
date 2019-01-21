function solve(arr, activeFactor) {
    let [sex, weight, height, age] = arr;

    let calculateMetabolism = function(sex, weight, height, age) {
        if (sex === 'm') {
            return 66 + 13.8 * weight + 5 * height - 6.8 * age;
        }

        return 655 + 9.7 * weight + 1.85 * height - 4.7 * age;
    }

    let calculate = function(workouts) {
        if (workouts == 1 || workouts == 2) {
            return 1.375;
        } 
        else if (workouts >= 3 && workouts <= 5) {
            return 1.55;
        } 
        else if (workouts == 6 || workouts == 7) {
            return 1.725;
        } 
        else if (workouts > 7) {
            return  1.90;
        } 
        else {
            return 1.2;
        }
    }

    let result = Math.round(calculateMetabolism(sex, weight, height, age) * calculate(activeFactor));
    console.log(result)
}