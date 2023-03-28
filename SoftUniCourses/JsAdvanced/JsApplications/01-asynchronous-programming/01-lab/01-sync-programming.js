console.log('before');

setTimeout(callBack, 2000);

console.log('after');

function callBack() {
    console.log('inside callBack()');
}