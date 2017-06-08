function matchAllWords(arr) {
    let regex = new RegExp(/\w+/g);
    let result = [];
    let match;

    while (match = regex.exec(arr)) {
        result.push(match);
    }

    console.log(result.join('|'));
}

matchAllWords('A Regular Expression needs to have the global flag in order to match all occurrences in the text')