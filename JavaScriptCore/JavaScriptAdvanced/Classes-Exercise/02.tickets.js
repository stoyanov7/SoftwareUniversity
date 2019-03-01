(() => {    
     /**
      * Class that manages a database of tickets.
      */
     class Ticket {
          constructor(destination, price, status) {
               this._destination = destination;
               this._price = price;
               this._status = status;
          }
     }
     let tickets = [];

     return (arr, criteria) => {
          for (let element of arr) {
               let args = element.split('|');
               let destination = args[0];
               let price = +args[1];
               let status = args[2];

               tickets.push(new Ticket(destination, price, status));
          }

          tickets = tickets.sort((a, b) => {
               if (a[criteria] < b[criteria]) {
                    return -1;
               }

               if (a[criteria] > b[criteria]) {
                    return 1;
               }

               return 0;
          });

          return tickets;
     };
})();