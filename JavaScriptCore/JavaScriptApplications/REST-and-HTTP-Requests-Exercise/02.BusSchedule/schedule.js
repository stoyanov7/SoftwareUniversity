function solve() {
     let currentStopId = "depot";
     let nextStop = '';

     function depart() {
          $.ajax({
               type: "GET",
               url: `https://judgetests.firebaseio.com/schedule/${currentStopId}.json`,
               success: (res) => {
                    nextStop = res.name;
                    $('span.info').text(`Next stop ${nextStop}`);
                    currentStopId = res.next;
                    $('#depart').prop('disabled', true);
                    $('#arrive').prop('disabled', false);
               }
          });
     }

     function arrive() {
          $('span.info').text(`Arriving at ${nextStop}`);
          $('#depart').prop('disabled', false);
          $('#arrive').prop('disabled', true);
     }

     return {
          depart,
          arrive
     };
}