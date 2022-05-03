function divisor(first, second) {

    let firstN = Number(first);
    let secondN = Number(second);

    while (firstN != secondN) {
        if (firstN > secondN) {
            firstN -= secondN;
        } else {
            secondN -= firstN
        }
    }

    console.log(firstN);
}