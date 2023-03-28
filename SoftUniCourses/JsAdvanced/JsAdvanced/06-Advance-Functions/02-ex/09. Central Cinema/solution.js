function solve() {

    let [nameInputField, hallInputField, ticketPriceInputField, onScreenButton] = Array.from(document.querySelector('div').children);
    let onScreenUlElement = Array.from(document.getElementById('movies').children).find(e => e.tagName == 'UL');
    let [_, archiveUlElement, clearButton] = Array.from(document.getElementById('archive').children);

    onScreenButton.addEventListener('click', addMovie)

    function addMovie(e) {
        e.preventDefault();

        let name = nameInputField.value;
        let hall = hallInputField.value;
        let price = Number(ticketPriceInputField.value);

        if (name !== '' &&
            hall != '' &&
            !isNaN(price) &&
            ticketPriceInputField.value != '') {

            let liElement = createElement('li');
            let spanElement = createElement('span', name);
            let strongElementLi = createElement('strong', `Hall: ${hall}`);
            let divElement = createElement('div');
            let strongElementDiv = createElement('strong', price.toFixed(2));
            let inputElement = createElement('input', '', 'placeholder=Tickets Sold');
            let archiveButtonElement = createElement('button', 'Archive');
            let deleteButtonElement = createElement('button', 'Delete');

            archiveButtonElement.addEventListener('click', onArchive);
            deleteButtonElement.addEventListener('click', onDelete);
            clearButton.addEventListener('click', onClear);

            divElement.appendChild(strongElementDiv);
            divElement.appendChild(inputElement);
            divElement.appendChild(archiveButtonElement);

            liElement.appendChild(spanElement);
            liElement.appendChild(strongElementLi);
            liElement.appendChild(divElement);

            onScreenUlElement.appendChild(liElement);

            function onArchive() {


                let numberOfTickets = Number(inputElement.value);

                if (isNaN(numberOfTickets) ||
                    numberOfTickets != 0) {
                    let totalAmount = numberOfTickets * price;

                    divElement.remove();
                    liElement.appendChild(deleteButtonElement);
                    strongElementLi.textContent = `Total amount: ${totalAmount.toFixed(2)}`
                    archiveUlElement.appendChild(liElement);
                }

            }

            function onDelete() {
                liElement.remove();
            }

            function onClear() {
                Array.from(archiveUlElement.children).forEach(e => e.remove());
            }


            nameInputField.value = '';
            hallInputField.value = '';
            ticketPriceInputField.value = '';
        }
    }

    function createElement(type, textContent, attribute) {
        let element = document.createElement(type);

        if (textContent != undefined && textContent != '') {
            element.textContent = textContent;
        }

        if (attribute) {
            let [type, value] = attribute.split('=');
            element.setAttribute(type, value);
        }

        return element;
    }
}