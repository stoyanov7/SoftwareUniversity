function attachEvents() {
     const url = 'https://messenger-8af6d.firebaseio.com/messages.json';

     $('#submit').click(sendMessage);
     $('#refresh').click(refresh);

     function sendMessage() {
          let author = $('#author').val();
          let content = $('#content').val();
          let timestamp = Date.now();

          let message = {
               author,
               content,
               timestamp
          };

          $.ajax({
               url: url,
               method: 'POST',
               data: JSON.stringify(message)
          });
     }

     function refresh() {
          $.ajax({
               url: url,
               method: 'GET',
               success: (data) => {
                    let allMessages = '';

                    for (const message of Object.values(data)) {
                         allMessages += `${message.author}: ${message.content}\n`;
                    }

                    $('#messages').text(allMessages);
               }
          });
     }
}