function solve(args) {
    let array = [];

    for (let i = 0; i < args.length; i++) {
        let tempArr = args[i].split(' ');
        let command = tempArr[0];
        let value = tempArr[1];

        if(command === "add") {
            array.push(value)
        }
        if(command === "remove") {
            array.splice(value, 1)
        }
    }

    for(let j = 0; j < array.length; j++) {
        console.log(array[j]);
    }
}