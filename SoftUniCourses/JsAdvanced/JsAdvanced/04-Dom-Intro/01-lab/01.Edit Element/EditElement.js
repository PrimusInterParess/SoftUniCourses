function editElement(element, match, toInsert) {

      while(element.textContent.includes(match)) {
        element.textContent = element.textContent.replace(match, toInsert);
    }
  
}