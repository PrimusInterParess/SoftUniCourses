function deleteByEmail() {

    const input = document.querySelector('input[name="email"]');

    const rows = Array.from(document.querySelector('tbody').children)
        .filter(r => r.children[1].textContent == input.value);

    rows.forEach(r => r.remove());

    console.log(rows.length);
    document.getElementById('result').textContent = rows.length > 0 ? 'Deleted' : 'Not found';

    //     let inputSearchElement = document.querySelector('input[name="email"]');
    //     let tdEmailElements = document.querySelectorAll('tbody tr td:nth-child(2)');
    //     let resultElement= document.querySelector('div[id="result"]');
    //     let result ='';

    //     let deletedLiElement = Array.from(tdEmailElements).forEach(e => {
    //         if (e.textContent == inputSearchElement.value) {
    //             e.parentElement.remove();
    //             result='Deleted';
    //             return;
    //         };
    //     });

    //    if(result!='Deleted'){
    //     result='Not found.'
    //    }
    //     resultElement.textContent= result;

}