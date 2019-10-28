function create(sentences) {

     for (const sentence of sentences) {
          let p = $('<p>', { text: sentence}).css('display', 'none');
          let div = $('<div>').append(p);

          $('#content').append(div);
     }

     $('#content div').click((event) => {
          $(event.target).children().css('display', 'block');
     });
}