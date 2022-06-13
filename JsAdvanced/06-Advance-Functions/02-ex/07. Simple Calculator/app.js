function calculator() {

    let numberOneField = null;
    let numberTwoField = null;
    let resultField = null;

    return {
        init,
        add,
        subtract
    }

    function init(selector1, selector2, resultSelector) {

        numberOneField = document.querySelector(selector1);
        numberTwoField = document.querySelector(selector2);
        resultField = document.querySelector(resultSelector);
    }

    function add() {
        resultField.value = Number(numberOneField.value) + Number(numberTwoField.value);
    }

    function subtract() {
        resultField.value = Number(numberOneField.value) - Number(numberTwoField.value);
    }

}





