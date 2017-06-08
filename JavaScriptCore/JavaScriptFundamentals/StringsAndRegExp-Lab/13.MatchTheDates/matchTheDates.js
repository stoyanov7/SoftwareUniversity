function matchTheDates(text) {
    let regex = new RegExp(/\b([0-9]{1,2})-([A-Z][a-z]{2})-[0-9]{4}\b/g);

    for (let i = 0; i < text.length; i++) {
        let match = text[i].match(regex);

        if (match) {
            let dateTokens = match[0].split('-');
            console.log(`${match[0]} (Day: ${dateTokens[0]}, Month: ${dateTokens[1]}, Year: ${dateTokens[2]})`);
        }
    }
}