function notify(message) {
     $('#notification')
          .text(message)
          .css('display', 'block');

     setTimeout(() => {
          $('#notification').css('display', 'none');
     }, 2000);
}