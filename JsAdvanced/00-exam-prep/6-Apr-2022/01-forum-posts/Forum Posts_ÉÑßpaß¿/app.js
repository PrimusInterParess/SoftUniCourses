window.addEventListener("load", solve);

function solve() {
  let titleInputField = document.getElementById('post-title');
  let categoryInputField = document.getElementById('post-category');
  let contentInputField = document.getElementById('post-content');
  let ulReviewListElement = document.getElementById('review-list');
  let ulUploadedPostsElement = document.getElementById('published-list');

  let publishButton = document.getElementById('publish-btn').addEventListener('click', onClick);
  let clearButton = document.getElementById('clear-btn').addEventListener('click', onClear);

  function onClick(event) {
    event.preventDefault();

    let title = titleInputField.value;
    let category = categoryInputField.value;
    let content = contentInputField.value;

    if (isEmptySpace(title) ||
      isEmptySpace(category) ||
      isEmptySpace(content)) {
      return;
    }

    let liElement = createElement('li', 'rpost');

    let articleElement = createElement('article');

    let h4Element = createElement('h4', '', title);

    // let stringPEl = `Category:${category}`;
    // let stringpEl2 = `Content: ${content}`;

    let pElementCategory = createElement('p', '', 'Category: ' + category);
    let pElementContent = createElement('p', '', 'Content: ' + content);

    let buttonEdit = createElement('button', 'action-btn edit', 'Edit');
    let buttonApprove = createElement('button', 'action-btn approve', 'Approve');

    buttonEdit.addEventListener('click', onEdit);
    buttonApprove.addEventListener('click', onApprove);

    articleElement.appendChild(h4Element);
    articleElement.appendChild(pElementCategory);
    articleElement.appendChild(pElementContent);

    liElement.appendChild(articleElement);
    liElement.appendChild(buttonEdit);
    liElement.appendChild(buttonApprove);

    ulReviewListElement.appendChild(liElement);

    console.log('БРАВО БЕ ТЪПАК!');

    blankField(titleInputField);
    blankField(categoryInputField);
    blankField(contentInputField);

    function onEdit(event) {

      event.preventDefault();
      liElement.remove();

      titleInputField.value = h4Element.textContent;
      categoryInputField.value = pElementCategory.textContent;
      contentInputField.value = pElementContent.textContent;

    }
    function onApprove(event) {
      event.preventDefault();
      ulUploadedPostsElement.appendChild(liElement);
      buttonApprove.remove();
      buttonEdit.remove();
    }


  }

  function blankField(inputField) {
    inputField.value = '';
  }

  function onClear(event) {
    event.preventDefault();
    let listOfChildren = Array.from(ulUploadedPostsElement.children).forEach(c => c.remove());
  }

  function createElement(tagName, className, textContent) {

    let elementToReturn = document.createElement(tagName);

    if (className != '') {
      elementToReturn.className = className;
    }

    elementToReturn.textContent = textContent;

    return elementToReturn;
  }

  function isEmptySpace(string) {
    return string == '' || string == null || string == undefined
  }

}
