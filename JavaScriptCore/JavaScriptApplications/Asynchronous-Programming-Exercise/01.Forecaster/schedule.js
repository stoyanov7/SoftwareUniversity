function attachEvents() {
     let weatherSymbolsObj = {
          Sunny: "☀",
          'Partly sunny': "⛅",
          Overcast: "☁",
          Rain: "☂"
     };

     let baseUrl = 'https://judgetests.firebaseio.com/';
     $('#submit').on('click', getWeather);

     async function getWeather() {
          try {
               let getAllLocations = await $.get(baseUrl + 'locations.json');
               let townName = $('#location').val();
               let townCode = getAllLocations.filter(t => t.name === townName)[0].code;

               let todayWeather = await $.get(baseUrl + `forecast/today/${townCode}.json`);
               let treeDayForecast = await $.get(baseUrl + `forecast/upcoming/${townCode}.json `);

               $('#forecast').css('display', 'block');
               setSymbol('#current', todayWeather.forecast.condition, "condition symbol");
               setCondition(todayWeather);                

               for (const day of treeDayForecast.forecast) {                              
                    let span = $('<span class="upcoming">');
                    
                    let symbol = weatherSymbolsObj[day.condition];
                    span.append(`<span class="symbol">${symbol}</span>`);   
          
                    span.append(`<span class="forecast-data">${day.low}°/${day.high}°</span>`);
                    span.append(`<span class="forecast-data">${day.condition}</span>`)

                    $('#upcoming').append(span);
               }       
          } catch (err) {
               console.log(err);
          }
     }

     function setSymbol(id, data, className) {
          let symbol = weatherSymbolsObj[data];
          $(id).append($(`<span class="${className}">${symbol}</span>`))
     }

     function setCondition(data) {
          let span = $('<span class="condition">');
          let spanTown = $(`<span class="forecast-data">${data.name}</span>`);
          let spanTemperatures = $(`<span class="forecast-data">${data.forecast.low}°/${data.forecast.high}°</span>`);
          let spanCondition = $(`<span class="forecast-data">${data.forecast.condition}</span>`);

          span.append([spanTown, spanTemperatures, spanCondition]);
          $('#current').append(span);
     }               
}