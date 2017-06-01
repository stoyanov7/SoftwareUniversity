function coockingByNumbers(arr) {
    let number = Number(arr[0]);

    for (let i = 1; i < arr.length; i++) {
        let operation = arr[i];

        switch (operation) {
            case 'chop':
                number /= 2;
                break;
            case 'dice':
                number = Math.sqrt(number);
                break;
            case 'spice':
                number++;
                break;
            case 'bake':
                number *= 3;
                break;
            case 'fillet':
                number -= number * 0.2;
                break;
        }

        console.log(number);
    }
}