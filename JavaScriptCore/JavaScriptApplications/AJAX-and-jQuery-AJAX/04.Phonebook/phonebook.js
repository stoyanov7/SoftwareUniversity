function solve() {
     let baseUrl = 'https://phonebook-98629.firebaseio.com/';

     $('#btnLoad').click(() => {
          $.ajax({
               method: 'GET',
               url: `${baseUrl}.json`,
               dataType: "json",
               success: (data) => {
                    data.forEach(element => {
                         if (element) {                              
                              let deleteButton = $('<button>')
                                   .text('Delete')
                                   .click((key) => {
                                        $.ajax({
                                             method: 'DELETE',
                                             url: baseUrl + key + '.json'
                                        });
                                   });

                              let li = $('<li>')
                                   .text(`${element.person}: ${element.phone}`)
                                   .append(deleteButton);

                              $('#phonebook').append(li);
                         }
                    });
               }
          });
     });

     $('#btnCreate').click(() => {
          $.ajax({
               url: baseUrl + '.json',
               method: 'POST',
               data: JSON.stringify({
                    person: $('#person').val(),
                    phone: $('#phone').val()
               }),
               success: (res) => console.log(res)
          });
     });
}