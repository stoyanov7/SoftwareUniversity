function toggle() {
     $('#extra').toggle(function () {
          if ($('.button').text() === 'More') {
               $('.button').text('Less');
          } else {
               $('.button').text('More');
          }          
     });
}