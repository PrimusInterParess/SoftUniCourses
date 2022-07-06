function shit(array) {
    array = array.map(e => e.toLowerCase()).filter(function (entry) { return entry.trim() != ''; });;

    let result =[];

    array.forEach((element,i) => {
        if (i != 0) {
            let el = Array.from(element);
            let newWord = `${el[0].toUpperCase()}${el.splice(1).join('')}`;
            result.push(newWord);
        }else{
            result.push(element);
        }
    });


  return result.join('');

}

let result = shit(['DANI', 'BORISOV', 'TERIKANTINA']);

console.log(result);