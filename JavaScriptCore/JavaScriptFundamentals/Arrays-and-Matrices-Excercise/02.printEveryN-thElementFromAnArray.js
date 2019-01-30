function solve(arr) {
    let step = +arr.pop();

    let result = arr.reduce((acc, element, index) => {
        if (index % step == 0) {
            acc.push(element);
        }

        return acc;
    }, []);

    console.log(result.join('\n'));
}