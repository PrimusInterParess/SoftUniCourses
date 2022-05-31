function solve() {

   document.getElementsByClassName('shopping-cart')[0].addEventListener('click', onClick);
   document.getElementsByClassName('checkout')[0].addEventListener('click',chechOut);

   let textAreaElement = document.querySelector('textarea');
   let shoppingCart = {};

   function onClick({ target }) {

      if (target.tagName == 'BUTTON' && target.className == 'add-product') {

         let productElement = target.parentNode.parentNode;

         console.log(productElement);
         let productName = productElement.querySelector('.product-title').textContent;
         let productPrice = Number(productElement.querySelector('.product-line-price').textContent);
         
         if(!shoppingCart.hasOwnProperty(productName)){
            shoppingCart[productName]=0
         }

         shoppingCart[productName]+=productPrice;
         textAreaElement.textContent += `Added ${productName} for ${productPrice.toFixed(2)} to the cart.\n`;

      }

   }

   function chechOut(){
      let totalPrice = Object.values(shoppingCart).reduce((t,c)=>t+c,0);

      textAreaElement.textContent+=`You bought ${Object.keys(shoppingCart).join(', ')} for ${totalPrice.toFixed(2)}.`
      console.log(totalPrice);

      Array.from(document.getElementsByTagName('button')).forEach(element => {
         element.disabled=true;
      });
   }


}