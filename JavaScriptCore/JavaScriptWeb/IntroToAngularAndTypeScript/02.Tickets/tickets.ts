const data = [
    'Philadelphia|94.20|available',
    'New York City|95.99|available',
    'New York City|95.99|sold',
    'Boston|126.20|departed'
];

const dest = 'status';

class Ticket {
    destination: string;
    price: number;
    status: string;

    constructor(destination: string, price: number, status: string) {
        this.destination = destination;
        this.price = price;
        this.status = status;
    }
}

let ticketsProgram = (ticket, criteria) => {
    let tickets = [];

    ticket.forEach(ticket => {
        let tokens = ticket.split('|');
        let [destination, price, status] = tokens;

        tickets.push(new Ticket(destination, Number(price), status));
    });

    tickets = sortByProperty(tickets, criteria);

    console.log(tickets)
}

let sortByProperty = (array, propertyName) => {
    return array.sort(function (a, b) {
        if (typeof propertyName === 'string') {
            return a[propertyName].localeCompare(b[propertyName])
        } 
        else {
            return a[propertyName] - b[propertyName]
        }
    });
}

ticketsProgram(data, dest);

export { };