
function executor(resolve, reject) {
    console.log('before');

    setTimeout(resolve, 2000);

    console.log('after');
}

function start() {

    let promise = new Promise(executor);

    promise.then(onResolve);
    promise.catch(onReject);

    //executor(onResolve, onReject);

    function onResolve() {
        console.log('operation succsesfull');
    }

    function onReject() {
        console.log('ERROR');
    }
}

start();