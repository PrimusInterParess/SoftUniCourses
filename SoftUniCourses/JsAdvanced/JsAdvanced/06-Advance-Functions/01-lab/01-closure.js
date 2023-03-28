function start() {
    let counter = 0;

    function increment(a) {
        counter += a;
        console.log(counter);
    }

    return increment;

    // increment(2);
    // increment(2);
    // increment(2);
    // increment(2);


}

const myIncrement =start();
