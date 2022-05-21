function colorize() {
    let childElements = document.querySelectorAll('table tr');

    let toModify = Array.from(childElements).forEach((x, i) => {
        if (i % 2 != 0) {
            x.style.backgroundColor = 'teal';
        }
    });
}