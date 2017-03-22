function solve(args) {
    let object = {};

    for(let i = 0; i < args.length; i++)
    {
        let data = args[i].split(" -> ");
        let key = data[0];
        let value = data[1];

        if(!isNaN(value)) {
            value = Number(value);
        }
        object[key] = value;
    }

    console.log(JSON.stringify(object));
}