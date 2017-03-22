function solve(args){
    let count = Number(args[0]);
    let arr = [];

    for(let i = 1; i < args.length; i++) {
        let temp = args[i].split(' - ');
        let index = temp[0];
        let value = temp[1];
        arr[index] = value;
    }

    for(let j = 0; j < count; j++) {
        if(arr[j] === undefined) {
            console.log(0);
        }
        else{
            console.log(arr[j]);
        }

    }
}