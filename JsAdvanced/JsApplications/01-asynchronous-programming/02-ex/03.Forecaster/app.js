async function attachEvents() {
    let inputElement = document.getElementById('location');

    let btnEl = document.getElementById('submit');
    let forecastDivEl = document.getElementById('forecast');
    let currentConditionEl = document.getElementById('current');
    let threeDaysForecastEl = document.getElementById('upcoming');

    btnEl.addEventListener('click', onClick);

    let locationsResponse = await fetch('http://localhost:3030/jsonstore/forecaster/locations');

    let locationsData = await locationsResponse.json();

    console.log(locationsData);

    async function onClick(e) {

        let {code} = await locationsData.find(d=>d.name==inputElement.value);

        let currentLocationResponse = await fetch(`http://localhost:3030/jsonstore/forecaster/today/${code}`);
        let currentLocationResponseUpcommingDays = await fetch(`http://localhost:3030/jsonstore/forecaster/upcoming/${code}`);

        
        let {name,forecast} = await currentLocationResponse.json();
        let currentLocationDataUpcommingDays  = await currentLocationResponseUpcommingDays.json();

        forecastDivEl.style.display ='block';

        let foreCastDisplayDiv = createElenementForeCastDisplayDiv(name,forecast);
      


       
    }


    async function createElenementForeCastDisplayDiv(name,forecast){

    }


}

attachEvents();