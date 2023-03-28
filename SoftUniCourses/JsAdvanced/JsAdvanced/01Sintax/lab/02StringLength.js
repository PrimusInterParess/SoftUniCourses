function stringLength(firstWord, secondWord, ThirdWord) {

    let wordsLength = firstWord.length + secondWord.length + ThirdWord.length;
    let averageLength = Math.round(wordsLength / 3);
    console.log(wordsLength);
    console.log(averageLength);
}

stringLength('chocolate', 'ice cream', 'cake')