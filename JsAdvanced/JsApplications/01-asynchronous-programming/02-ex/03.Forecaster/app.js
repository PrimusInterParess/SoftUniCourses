async function attachEvents() {
    let inputElement = document.getElementById('location');

    let btnEl = document.getElementById('submit');
    let forecastDivEl = document.getElementById('forecast');
    let currentConditionEl = document.getElementById('current');
    let threeDaysForecastEl = document.getElementById('upcoming');

    let conditionSymbols = {
        Sunny: '&#x2600;',
        'Partly sunny': '&#x26C5;',
        Overcast: '&#x2601;',
        Rain: '&#x2614;',
        Degrees: '&#176;',

    }

    btnEl.addEventListener('click', onClick);

    let locationsResponse = await fetch('http://localhost:3030/jsonstore/forecaster/locations');

    let locationsData = await locationsResponse.json();

    async function onClick(e) {


        let { code } = await locationsData.find(d => d.name == inputElement.value);

        let currentLocationResponse = await fetch(`http://localhost:3030/jsonstore/forecaster/today/${code}`);
        let currentLocationResponseUpcommingDays = await fetch(`http://localhost:3030/jsonstore/forecaster/upcoming/${code}`);

        let { name, forecast } = await currentLocationResponse.json();
        let upCommingData = await currentLocationResponseUpcommingDays.json();

        forecastDivEl.style.display = 'block';

        let divCurrentForecast = createElenementForeCastDisplayDiv(name, forecast);

        currentConditionEl.appendChild(divCurrentForecast);

        let divUpcommingForecast = createDivGroupUpcomingForecast(upCommingData);

        console.log(divUpcommingForecast);

        threeDaysForecastEl.appendChild(divUpcommingForecast);

    }

    function createDivGroupUpcomingForecast(upCommingData) {

        let { forecast } = upCommingData;

        let divForecastInfoEl = createDivEl('forecast-info');

        for (const data of forecast) {

            let spanUpcommingEl = createSpanEl('upcoming');
            let spanSymbolEl = createSpanEl('symbol', '', conditionSymbols[data.condition]);
            let spanForecastDataDegreeslEl = createSpanEl('forecast-data', '', `${data.low}${conditionSymbols.Degrees}/${data.high}${conditionSymbols.Degrees}`);
            let spanForecastDataCondition = createSpanEl('forecast-data', data.condition);
            spanUpcommingEl.appendChild(spanSymbolEl);
            spanUpcommingEl.appendChild(spanForecastDataDegreeslEl);
            spanUpcommingEl.appendChild(spanForecastDataCondition);

            divForecastInfoEl.appendChild(spanUpcommingEl);

        }

        return divForecastInfoEl;
    }


    function createElenementForeCastDisplayDiv(name, forecast) {
        let divEl = createDivEl('forecasts')


        let spanElConditionSymbol = createSpanEl('condition symbol', '', conditionSymbols[forecast.condition]);

        let spanElConditon = createSpanEl('condition');



        let spanElForecastDataLocation = createSpanEl('forecast-data', name);
        let spanElForecastDataDegrees = createSpanEl('forecast-data', '', `${forecast.low}${conditionSymbols.Degrees}/${forecast.high}${conditionSymbols.Degrees}`);
        let spanElForecastDataCondition = createSpanEl('forecast-data', forecast.condition);

        spanElConditon.appendChild(spanElForecastDataLocation);
        spanElConditon.appendChild(spanElForecastDataDegrees);
        spanElConditon.appendChild(spanElForecastDataCondition);

        divEl.appendChild(spanElConditionSymbol);
        divEl.appendChild(spanElConditon);

        return divEl;

    }

    function createSpanEl(className, textContent, innerHtml) {
        let spanEl = document.createElement('span');
        spanEl.className = className;

        if (textContent != '' && textContent != undefined) {
            spanEl.textContent = textContent;
        }

        if (innerHtml) {
            spanEl.innerHTML = innerHtml;
        }

        return spanEl;
    }

    function createDivEl(className) {
        let divEl = document.createElement('div');
        divEl.className = className;

        return divEl;
    }


}

attachEvents();