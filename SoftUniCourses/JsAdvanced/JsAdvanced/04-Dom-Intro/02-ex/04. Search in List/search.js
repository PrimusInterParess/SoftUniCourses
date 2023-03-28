function search() {
    let towns = document.querySelectorAll('ul li');
    let arr = Array.from(towns);
    arr.forEach(t => {
        t.style.textDecoration = 'none';
    })
    let input = document.getElementById('searchText').value;

    let matches = 0;
    arr.forEach((t, i) => {
        if (t.textContent.includes(input)) {
            t.style.textDecoration = 'underline';
            t.style.textDecoration = 'bold';
            matches++;
        }
    })

    document.getElementById('result').textContent = `${matches} matches found`;
}