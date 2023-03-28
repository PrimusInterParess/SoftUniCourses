async function getInfo() {

    let busStopInputField = document.getElementById('stopId');
    let busStopDivElement = document.getElementById('stopName');
    let sceduleUlElement = document.getElementById('buses');
    try {
        let responce = await fetch(`http://localhost:3030/jsonstore/bus/businfo/${busStopInputField.value}`);

        if (responce.ok == false) {
            throw new Error('fuck you')
        }

        let data = await responce.json();

        let { buses, name } = await data;

        busStopDivElement.textContent=name;

        sceduleUlElement.innerHTML='';

        for (const busId in buses) {
            let liElement = document.createElement('li');

            liElement.textContent=`Bus ${busId} arrives in ${buses[busId]} minutes`

            sceduleUlElement.appendChild(liElement);
        }

        

    } catch (er) {
        busStopDivElement.textContent= 'Error';
    }

}