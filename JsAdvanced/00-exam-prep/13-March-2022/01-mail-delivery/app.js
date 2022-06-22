
function solve() {

    let inputFields = {
        recepient: document.getElementById('recipientName'),
        title: document.getElementById('title'),
        message: document.getElementById('message')
    }

    let buttons = {
        addToList: document.getElementById('add'),
        reset: document.getElementById('reset'),
    }

    let ulElements = {
        listOfMail: document.querySelector('div.list-mails ul#list'),
        sentMails: document.querySelector('div.sent-mails ul.sent-list'),
        deletedMails: document.querySelector('div.trash ul.delete-list'),
    }

    buttons.addToList.addEventListener('click', onAdd);


    function onAdd(e) {
        e.preventDefault();

        if (isEmptySpace(inputFields.recepient.value) || isEmptySpace(inputFields.title.value) || isEmptySpace(inputFields.message.value)) {
            return;
        }

        console.log(ulElements.listOfMail);
        console.log(ulElements.sentMails);
        console.log(ulElements.deletedMails);

        let liElement = document.createElement('li');
        let h4ElementTitle = createElement('h4', '', '', inputFields.title.value);
        let h4ElementRecepient = createElement('h4', '', '', inputFields.recepient.value);
        let spanElementMessage = createElement('span', '', '', inputFields.message.value);
        let divElement = createElement('div', '', 'list-action', '');

        let sendButton = createButton('subbmit', 'send', 'Send');
        let deleteButton = createButton('subbmit', 'delete', 'Delete');

        divElement.appendChild(sendButton);
        divElement.appendChild(deleteButton);

        liElement.appendChild(h4ElementTitle);
        liElement.appendChild(h4ElementRecepient);
        liElement.appendChild(spanElementMessage);
        liElement.appendChild(divElement);

        ulElements.listOfMail.appendChild(liElement);

        blankField(inputFields.title);
        blankField(inputFields.recepient);
        blankField(inputFields.message);


    }

    function createButton(type, id, textContent) {
        let elementToReturn = document.createElement('button');

        if (type != '') {
            elementToReturn.type = type;
        }

        if (id != '') {
            elementToReturn.setAttribute('id', id);
        }

        if (textContent != '') {
            elementToReturn.textContent = textContent;
        }

        return elementToReturn;

    }

    function createElement(tagName, className, id, textContent) {

        let elementToReturn = document.createElement(tagName);

        if (id != '') {
            elementToReturn.setAttribute('id', id);
        }
        if (className != '') {
            elementToReturn.classList.add(className);
        }

        if (textContent != '') {
            elementToReturn.textContent = textContent;
        }


        return elementToReturn;
    }

    function isEmptySpace(string) {
        return string == '' || string == null || string == undefined
    }

    function blankField(inputField) {
        inputField.value = '';
    }

}
solve();