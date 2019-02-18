(() => {
    return {
        add: (firstVector, secondVector) => {
            let x1 = firstVector[0];
            let y1 = firstVector[1];
            let x2 = secondVector[0];
            let y2 = secondVector[1];

            return [x1 + x2, y1 + y2];
        },
        multiply: (firstVector, scalar) => {
            let x = firstVector[0];
            let y = firstVector[1];

            return [x * scalar, y * scalar];
        },
        length: (firstVector) => {
            let x = firstVector[0];
            let y = firstVector[1];

            return Math.sqrt((x * x) + (y * y));
        },
        dot: (firstVector, secondVector) => {
            let x1 = firstVector[0];
            let y1 = firstVector[1];
            let x2 = secondVector[0];
            let y2 = secondVector[1];

            return (x1 * x2) + (y1 * y2);
        },
        cross: (firstVector, secondVector) => {
            let x1 = firstVector[0];
            let y1 = firstVector[1];
            let x2 = secondVector[0];
            let y2 = secondVector[1];

            return (x1 * y2) - (y1 * x2);
        }
    };
})();