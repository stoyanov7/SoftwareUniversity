function solve(arr) {
    let min = 0;
    let result = arr.reduce((acc, element) => {
        if (element >= min) {
            acc.push(element);
            min = element;
        }

        return acc;
    }, []);

    console.log(result.join('\n'));
}