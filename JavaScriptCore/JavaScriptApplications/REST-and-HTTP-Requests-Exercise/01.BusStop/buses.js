function getInfo() {
     $('#buses').text("");
     $('#stopName').text("");

     let stopId = $('#stopId').val();
     const baseUrl = 'https://judgetests.firebaseio.com/businfo/';     

     $.ajax({
          url: baseUrl + stopId + '.json',
          method: 'GET',
          success: (data) => {
               $('#stopName').text(data.name);

               for (let [busId, time] of Object.entries(data.buses)) {
                    $('#buses').append(`<li>Bus ${busId} arrives in ${time} minutes</li>`);
               }
          },
          error: () => $('#stopName').text('Error')
     });
    
     $('#stopId').val('');
}