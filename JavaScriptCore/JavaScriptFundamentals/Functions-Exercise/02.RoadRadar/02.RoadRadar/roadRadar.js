function roadRadar([currentSpeed, area]) {
    currentSpeed = Number(currentSpeed);

    let getLimit = function () {
        switch (area) {
            case "motorway":
                return 130;
                break;
            case "interstate":
                return 90;
                break;
            case "city":
                return 50;
                break;
            case "residential":
                return 20;
                break;
        }
    }

    let getInfraction = function (speed, limit) {
        let overSpeed = speed - limit;

        if (overSpeed <= 0) {
            return ' ';
        }
        else if (overSpeed > 0 && overSpeed <= 20) {
            return 'speeding';
        }
        else if (overSpeed > 20 && overSpeed <= 40) {
            return 'excessive speeding';
        }
        else if (overSpeed > 40) {
            return 'reckless driving';
        }
    }

    console.log(getInfraction(currentSpeed, getLimit()));
}