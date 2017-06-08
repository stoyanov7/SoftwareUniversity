function extractText(text) {
    let openBracket = text.indexOf('(');

    let result = [];

    while (openBracket !== -1) {
        let closeBracket = text.indexOf(')', openBracket);

        if (closeBracket === -1) {
            break;
        }

        result.push(text.substring(openBracket + 1, closeBracket));

        openBracket = text.indexOf('(', closeBracket + 1);
    }

    console.log(result.join(', '));
}