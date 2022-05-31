// function create(words) {
   
//    const parentEl = document.getElementById('content');
//    parentEl.addEventListener('click',showContent);

//    for (const word of words) {
//       let divEl = document.createElement('div');
//       let pElement = document.createElement('p');
//       pElement.textContent=word;
//       console.log(pElement.style.display);
//      pElement.style.display='none';
//       divEl.appendChild(pElement);
//       parentEl.appendChild(divEl);
//    }

//    function showContent(e){
//       if(e.target.tagName=='DIV' && e.target!=parentEl){
//          e.target.querySelector('p').style.display='block'
//          console.log(e);
//       }
//    }
// }


function create(words){

   const content = document.getElementById('content');

   for (const word of words) {
      const div = document.createElement('div');
      const p = document.createElement('p');
      p.textContent=word;
      p.style.display='none';
      div.appendChild(p);
      div.addEventListener('click',reveal.bind(null,p));
      content.appendChild(div);

     
   }

   function reveal(e){
      p.style.display='';
   }
}