function attachEvents() {
     const URL = "https://phonebook-nakov.firebaseio.com/phonebook";

     $('#btnLoad').on('click', load);
     $('#btnCreate').on('click', create);

     function load() {
          $.ajax({
               type: "GET",
               url: URL + ".json",
               success: (res) => {
                    for (let key in res) {
                         generate(res[key].person, res[key].phone, key);
                    }
               }
          });
     }

     function create() {
          const person = $('#person');
          const phone = $('#phone');

          let persons = {
               person: person.val(),
               phone: phone.val()
          };

          let newData = JSON.stringify(persons);

          $.ajax({
               type: "POST",
               url: URL + '.json',
               data: newData,
               success: (res) => {
                    generate(person.val(), phone.val(), res.name);
                    person.val('');
                    phone.val('');
               }
          });
     }

     function generate(person, phone, key) {
          let li = $(`<li>${person}: ${phone}</li>`)
               .append($('<button>[Delete]</button>').on('click', () => {
                    $.ajax({
                         type: "DELETE",
                         url: URL + '/' + key + '.json',
                         success: () => {
                              $(li).remove();
                         }
                    });
               }));

          $('#phonebook').append(li);
     }
}