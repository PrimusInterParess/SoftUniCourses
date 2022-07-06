function solve() {

    let taskInputField = document.getElementById('task');
    let descriptionInputField = document.getElementById('description');
    let dueDateInputField = document.getElementById('date');

    let [_, openSection, inProgressSection, completeSection] =
    Array
        .from(document.querySelectorAll('section'))
        .map(e => e.children[1]);


    const input = {
        name: document.getElementById('task'),
        description: document.getElementById('description'),
        date: document.getElementById('date'),
    }

    document.getElementById('add').addEventListener('click', addTask);

    function addTask(event) {
        event.preventDefault();
        const article = document.createElement('article');
        const h3 = createElement('h3', input.name.value);
        const pDescription = createElement('p', `Description: ${input.description.value}`);
        const pDate = createElement('p', `Due Date: ${input.date.value}`);
        const div = createElement('div', '', 'flex');
        const startButton = createElement('button', 'Start', 'green');
        const deleteButton = createElement('button', 'Delete', 'red');
        const finishButton = createElement('button', 'Finish', 'orange');


        startButton.addEventListener('click', onStart);
        deleteButton.addEventListener('click', onDelete);
        finishButton.addEventListener('click', onFinish);

        div.appendChild(startButton);
        div.appendChild(deleteButton);
        article.appendChild(h3);
        article.appendChild(pDescription);
        article.appendChild(pDate);
        article.appendChild(div);

        openSection.appendChild(article);

        function onFinish() {
            deleteButton.remove();
            finishButton.remove();
            completeSection.appendChild(article);
        }

        function onStart() {
            startButton.remove();
            div.appendChild(finishButton);
            inProgressSection.appendChild(article);
        }

        function onDelete() {
            article.remove();
        }
    }



    function createElement(type, content, className) {

        const element = document.createElement(type);
        element.textContent = content;

        if (className) {
            element.className = className;
        }

        return element;
    }
}