function solve() {
    $('button').click(() => {
        let input = $('input').val();

        let firstLetterIndex = input
            .toLowerCase()
            .charCodeAt(0) - 97;

        if (firstLetterIndex >= 0 && firstLetterIndex <= 25) {
            name = input
                .charAt(0)
                .toUpperCase() + input.substr(1).toLowerCase();

            let liElements = document.querySelectorAll('li');
            let li = liElements[firstLetterIndex];
            
            if (li.textContent === "") {
                li.textContent += name;
            } else {
                li.textContent += ", " + name;
            }
    
            $('input').val('');
        }
    });
}