function initializeTable() {
    $('#createLink').click(addCountry);

    fixLinks();

    function addCountry() {
        let country = $('#newCountryText').val();
        let capital = $('#newCapitalText').val();

        if (country !== '' && capital !== '') {
            createCountry(country, capital);
        }
    }

    function createCountry(country, capital) {
        let table = $('#countriesTable');

        let row = $('<tr>');
        let countryAndCapital = $(
            `<td>${country}</td>
            <td>${capital}</td>`);
        
        let actions = $('<td>')
            .append($('<a href="#">[Up]</a>').click(moveUp))
            .append($('<a href="#">[Down]</a>').click(moveDown))
            .append($('<a href="#">[Delete]</a>').click(deleteRow));
            
        row.append(countryAndCapital, actions);
        table.append(row);

        fixLinks();
    }

    function moveUp() {
        let currentRow = $(this).parent().parent();
        currentRow.insertBefore(currentRow.prev());

        fixLinks();
    }

    function moveDown() {
        let currentRow = $(this).parent().parent();
        currentRow.insertAfter(currentRow.next());

        fixLinks();
    }

    function deleteRow() {
        let currentRow = $(this).parent().parent();
        currentRow.remove();

        fixLinks();
    }

    function fixLinks() {
        $('a').show();

        $('#countriesTable tr:nth-child(3) td:nth-child(3) a:first-child')
            .hide();

        $('#countriesTable tr:last-child td:nth-child(3) a:nth-child(2)')
            .hide();
    }

    createCountry('Bulgaria', 'Sofia');
    createCountry('Germany', 'Berlin');
    createCountry('Russia', 'Moscow');
}