function getInfo() {
     let stopId = $('#stopId').val();
     let baseUrl = `https://judgetests.firebaseio.com/businfo/${stopId}.json`;
     $('#stopId').empty();

     $.ajax({
          url: baseUrl,
          method: 'GET',
          success: (data) => {
               $('#stopName').text(data.name);

               for (let [busId, time] of Object.entries(data.buses)) {
                    $('#buses').append(`<li>Bus ${busId} arrives in ${time} minutes</li>`);
               }
          },
          error: () => $('#stopName').text('Error')
     });
}