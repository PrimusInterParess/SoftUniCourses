window.addEventListener("load", solve);

function solve() {
  let titleInputField = document.getElementById('post-title');
  let categoryInputField = document.getElementById('post-category');
  let contentInputField = document.getElementById('post-content');
  let publishButton = document.getElementById('publish-btn');
  let ulReviewListElement = document.getElementById('review-list');

  publishButton.addEventListener('click', onClick)


  function onClick({ target }) {


    if (isEmptySpace(titleInputField.value) == false ||
      isEmptySpace(categoryInputField.value) == false ||
      isEmptySpace(contentInputField.value) == false) {

      liElement = createElement('li', 'rpost');

      articleElement = createElement('article');

      h4Element = createElement('h4', '', titleInputField.value);


      pElementCategory = createElement('p', '', categoryInputField.value);
      pElementContent = createElement('p', '', contentInputField.value);

      buttonEdit = createElement('button', 'action-btn edit', 'Edit');
      buttonApprove = createElement('button', 'action-btn approve', 'Approve');

      //TODO add event listeners to buttons you IDIOT!

      articleElement.appendChild(h4Element);
      articleElement.appendChild(pElementCategory);
      articleElement.appendChild(pElementContent);

      liElement.appendChild(articleElement);
      liElement.appendChild(buttonEdit);
      liElement.appendChild(buttonApprove);

      ulReviewListElement.appendChild(liElement);

      console.log('БРАВО БЕ ТЪПАК!');
    }



  }

  function createElement(tagName, className, textContent) {

    let elementToReturn = document.createElement(tagName);

    if (className != '' && className != undefined) {
      elementToReturn.className = className;
    }

    elementToReturn.textContent = textContent;

    return elementToReturn;
  }





  function isEmptySpace(string) {
    return string == '' || string == null || string == undefined
  }

}
