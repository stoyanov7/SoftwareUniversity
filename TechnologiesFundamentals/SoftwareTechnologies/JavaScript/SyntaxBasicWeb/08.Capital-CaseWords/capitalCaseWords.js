function solve(args) {
    let words = args
        .join('')
        .split(/\W+/)
        .filter(w => w.length > 0)
        .filter(w => w === w.toUpperCase())
        .join(', ');

    console.log(words);
}