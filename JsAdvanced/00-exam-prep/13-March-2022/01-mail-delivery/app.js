
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
    buttons.reset.addEventListener('click', onReset);

    function onAdd(e) {
        e.preventDefault();

        if (isEmptySpace(inputFields.recepient.value) || isEmptySpace(inputFields.title.value) || isEmptySpace(inputFields.message.value)) {
            return;
        }

      

        let titleText = inputFields.title.value;
        let recepientText = inputFields.recepient.value;


        let liElementListOfMail = document.createElement('li');
        let h4ElementTitle = createElement('h4', '', '', 'Title: ' + titleText);
        let h4ElementRecepient = createElement('h4', '', '', 'Recipient Name: ' + recepientText);
        let spanElementMessage = createElement('span', '', '', inputFields.message.value);
        let divElement = createElement('div', '', 'list-action', '');

        let sendButton = createButton('subbmit', 'send', 'Send');
        let deleteButton = createButton('subbmit', 'delete', 'Delete');

        sendButton.addEventListener('click', onSend);
        deleteButton.addEventListener('click', onDelete);

        divElement.appendChild(sendButton);
        divElement.appendChild(deleteButton);

        liElementListOfMail.appendChild(h4ElementTitle);

        liElementListOfMail.appendChild(h4ElementRecepient);

        liElementListOfMail.appendChild(spanElementMessage);
        liElementListOfMail.appendChild(divElement);

        ulElements.listOfMail.appendChild(liElementListOfMail);


        function onSend(e) {
            e.preventDefault();

            h4ElementRecepient.remove();
            h4ElementTitle.remove();
            spanElementMessage.remove();
            divElement.remove();
            sendButton.remove();

            let spanElementRecepient = createElement('span', '', '', `To: ${recepientText}`);
            let spanElementTitle = createElement('span', '', '', `Title: ${titleText}`);
            liElementListOfMail.appendChild(spanElementRecepient);
            liElementListOfMail.appendChild(spanElementTitle);
            
            let divElementSendMails = createElement('div','btn');
            divElement.appendChild(deleteButton);
            liElementListOfMail.appendChild(divElementSendMails);


            ulElements.sentMails.appendChild(liElementListOfMail);

        }

        function onDelete(e) {
            e.preventDefault();

            if (e.target.parentNode.parentNode.parentNode.id == 'list') {
                onSend(e);
            }

            deleteButton.remove();
            sendButton.remove();

            ulElements.deletedMails.appendChild(liElementListOfMail);




        }


        blankField(inputFields.title);
        blankField(inputFields.recepient);
        blankField(inputFields.message);
    }

    function onReset(e) {
        e.preventDefault();

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

        if (id != '' && id != undefined) {
            elementToReturn.setAttribute('id', id);
        }
        if (className != '' && id != undefined) {
            elementToReturn.classList.add(className);
        }

        if (textContent != '' && id != undefined) {
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