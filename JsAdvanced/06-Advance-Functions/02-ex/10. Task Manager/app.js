function solve() {

    let taskInputField = document.getElementById('task').value;
    let descriptionInputField = document.getElementById('description').value;
    let dueDateInputField = document.getElementById('date').value;


    const input = {
        name: document.getElementById('task'),
        description: document.getElementById('description'),
        date: document.getElementById('date'),
    }

    document.getElementById('add').addEventListener('click', addTask);

    function addTask(event) {
        event.preventDefault();
        const article = document.createElement('article');
        const h3 = document.createElement('h3');
        h3.textContent = input.name.value;
        article.appendChild(h3);
    }

    function createElement(type,content,className){
     
        const element = document.createElement(type);
        h3.textContent = input.name.value;
        article.appendChild(h3);
    }


}