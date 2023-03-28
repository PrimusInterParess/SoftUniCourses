function addItem() {
    let inputElement = document.getElementById('newItemText');
    let ulElements = document.getElementById('items');
    let lielementToAppend = document.createElement('li');
    lielementToAppend.textContent=inputElement.value;
    inputElement.value='';
    ulElements.appendChild(lielementToAppend);
  
}