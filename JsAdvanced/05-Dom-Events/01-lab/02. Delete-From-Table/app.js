function deleteByEmail() {
    let inputSearchElement = document.querySelector('input[name="email"]');
    let tdEmailElements = document.querySelectorAll('tbody tr td:nth-child(2)');
    let resultElement= document.querySelector('div[id="result"]');
    let result ='';

    let deletedLiElement = Array.from(tdEmailElements).forEach(e => {
        if (e.textContent == inputSearchElement.value) {
            e.parentElement.remove();
            result='Deleted';
            return;
        };
    });
    
   if(result!='Deleted'){
    result='Not found.'
   }
    resultElement.textContent= result;

}