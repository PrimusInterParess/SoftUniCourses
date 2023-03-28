 function solve() {

    let firstStopId = 'depot';
    let departFieldElement = document.getElementById('depart');
    let arrivetFieldElement = document.getElementById('arrive');
    
    let currentStop = '';

    let spanEl = document.querySelector('div#info span.info');
 console.log(spanEl);

   async function depart() {

        let response = await fetch(`http://localhost:3030/jsonstore/bus/schedule/${firstStopId}`);

        let {name,next} = await response.json();

        currentStop=name;

        spanEl.textContent=`Next stop ${name}`;

        departFieldElement.setAttribute('disabled','');

        arrivetFieldElement.removeAttribute('disabled');
        
    }

    function arrive() {
        arrivetFieldElement.setAttribute('disabled','');

        departFieldElement.removeAttribute('disabled');

        spanEl.textContent=`Arriving at ${currentStop}`;
        
    }

    return {
        depart,
        arrive
    };
}

let result = solve();