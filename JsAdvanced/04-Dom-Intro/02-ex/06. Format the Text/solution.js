function solve() {

    let inputText = document
        .getElementById('input')
        .value.split('.')
        .filter(function(entry) { return entry.trim() != ''; });

    let loops = 3;
    let result = '';

    while (inputText.length != 0) {
        let currentSentence = `${inputText.shift()}.`;
        loops--;
        result += currentSentence;
        if (inputText.length == 0 ||
            loops == 0) {
            loops = 3;
            let para = document.createElement("p");
            para.innerHTML = result;
            document.getElementById('output').appendChild(para);
            result = '';
        }
    }

}