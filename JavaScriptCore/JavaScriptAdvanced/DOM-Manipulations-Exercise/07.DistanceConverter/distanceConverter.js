function attachEventsListeners() {
     $('#convert').click(() => {
          let inputDistance = $('#inputDistance').val().trim();
          let inputUnits = $('#inputUnits option:selected').val();

          let outputUnits = $('#outputUnits option:selected').val();

          let meterBasedRates = {
               km: 1000,
               m: 1,
               cm: 0.01,
               mm: 0.001,
               mi: 1609.34,
               yrd: 0.9144,
               ft: 0.3048,
               in: 0.0254
          };

          if (inputDistance === '') {
               return;
          }

          let value = Number(inputDistance);

          if (isNaN(value)) {
              return;
          }

          let fromRate = meterBasedRates[inputUnits];
          let targetRate = meterBasedRates[outputUnits];
          
          if (!fromRate || !targetRate) {
               return;
          }

          $('#outputDistance').val(value * fromRate / targetRate);
     });
}