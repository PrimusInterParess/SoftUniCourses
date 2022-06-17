



function ticketFactory(array, criteria) {

class Ticket {
    constructor(destination, price, status) {
        this.destination = destination;
        this.price = price;
        this.status = status;
    }
}


    let restult = [];

    for (const element of array) {
        let [destination, price, status] = element.split('|');

        restult.push(new Ticket(destination,Number(price), status));
    }

    restult = restult.sort(function (a, b) { return criteria!='price'?a[criteria].localeCompare(b[criteria]):a-b });

    return restult;
}

let result = ticketFactory(['Philadelphia|94.20|available',
    'New York City|95.99|available',
    'New York City|95.99|sold',
    'Boston|126.20|departed'],
    'price'
);



console.log(result);