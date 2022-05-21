function solve() {
    let text = document.getElementById('text').value.split(' ')
    let convention = document.getElementById("naming-convention").value;

    let array = Array.from(text).map(e => e.toLowerCase()).filter(function(entry) { return entry.trim() != ''; });;
    let result = [];

    if (convention == 'Camel Case') {


        array.forEach((element, i) => {
            let newWord = '';
            if (i != 0) {
                let el = Array.from(element);
                newWord = `${el[0].toUpperCase()}${el.splice(1).join('')}`;
                array[i] = newWord
                    // result.push(newWord);
            } else {
                array[i] = newWord;
                // result.push(element);
            }
        });

    } else if (convention == "Pascal Case") {

        array.forEach((element, i) => {
            let el = Array.from(element);
            let newWord = `${el[0].toUpperCase()}${el.splice(1).join('')}`;
            result.push(newWord);
        });

    } else {
        result.push('Error!');
    }

    document.getElementById('result').textContent = result.join('');

}