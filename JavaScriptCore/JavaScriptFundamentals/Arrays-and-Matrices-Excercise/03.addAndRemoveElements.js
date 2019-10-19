function solve(arr) {
    let result = arr.reduce((acc, element, index) => {
        if (element === 'add') {
            acc.push(index + 1);
        } else if (element === 'remove') {
            acc.pop();
        }

        return acc;
    }, []);

    if (result.length > 0) {
        console.log(result.join('\n'));
    } else {
        console.log('Empty');
    }
}