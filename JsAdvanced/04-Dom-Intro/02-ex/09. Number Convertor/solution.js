function solve() {


    let selectElement = document.querySelector('#selectMenuTo');
    selectElement.selected = true;
    selectElement.innerHTML = null;

    let hexaElement = document.createElement('option');
    let binaryElement = document.createElement('option');

    hexaElement.value = 'hexadecimal';
    hexaElement.textContent = 'Hexadecimal';

    binaryElement.value = 'binary';
    binaryElement.textContent = 'Binary';

    selectElement.appendChild(hexaElement);
    selectElement.appendChild(binaryElement);

    document.querySelector('#container button').addEventListener('click', convert);
    let inputNumber = Number(document.getElementById('input').value);
    let converter = document.getElementById('selectMenuTo').value;

    let result = '';

    if (converter == 'hexadecimal') {
        result = inputNumber.toString(16).toUpperCase();
    } else if (converter == 'binary') {
        result = inputNumber.toString(2);
    }

    document.getElementById('result').value = result;


}