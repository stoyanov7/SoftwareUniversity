function usernames(arr) {
    let users = arr
        .map(u => u.split('@'));

    let result = [];

    for (let user of users) {
        let [name, domain] = user;
        let domainsTokens = domain.split('.');
        domainsTokens = domainsTokens.map(e => e[0]);
        let username = name + '.' + domainsTokens.join('');

        result.push(username);
    }

    console.log(result.join(', '));
}