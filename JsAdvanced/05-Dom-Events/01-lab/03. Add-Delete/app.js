function addItem() {
    let ulElement = document.getElementById('items');
    let inputElement = document.getElementById('newItemText');
    
    if(inputElement.value!=''){
        let liCreateElement = document.createElement('li');
        let createDeleteChild = document.createElement('a');
        createDeleteChild.setAttribute('href', '#');
        createDeleteChild.textContent = '[Delete]';
        createDeleteChild.addEventListener('click',deleteItem)
        liCreateElement.textContent= inputElement.value;
        liCreateElement.appendChild(createDeleteChild);
    
        ulElement.appendChild(liCreateElement);

        function deleteItem(){
            liCreateElement.remove();
        }
    
    }

    inputElement.value='';
}