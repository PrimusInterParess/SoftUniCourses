function extractText() {
    let elements = document.getElementById('items')
    let toInsert = document.getElementById('result');

    toInsert.textContent = elements.textContent;

}