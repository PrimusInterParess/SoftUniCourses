function solve() {
    document.querySelector('#btnSend').addEventListener('click', onClick);

    function onClick() {
        let inputData = document.querySelector('div textarea').value;

        let restaurants = getRestorurants(inputData);
        let [bestRest, averageSalary, bestSalary] = getBestRestourant(restaurants);

        let resultBestRest = `Name: ${bestRest} Average Salary: ${averageSalary.toFixed(2)} Best Salary: ${bestSalary.toFixed(2)}`
        let resultEmployees = getEmployees(restaurants[bestRest])

        document.querySelector('#bestRestaurant p').textContent = resultBestRest;
        document.querySelector('#workers p').textContent = resultEmployees;

    }

    function getEmployees(employees) {
        let result = '';

        for (const employee of employees) {
            result += `Name: ${employee[0]} With Salary: ${employee[1]} `
        }

        return result;
    }


    function getBestRestourant(restaurants) {

        let bestAverageSalary = 0;
        let resultRestName = '';
        let resultBestSalary = 0;
        for (const restaurant in restaurants) {
            let averageSalaries = restaurants[restaurant]
                .reduce((prev, curr) => prev + curr[1], 0) / restaurants[restaurant].length;

            if (averageSalaries > bestAverageSalary) {
                bestAverageSalary = averageSalaries
                resultRestName = restaurant;
            }
        }

        resultBestSalary = restaurants[resultRestName][0][1];

        return [resultRestName, bestAverageSalary, resultBestSalary];
    }

    function getRestorurants(inputData) {
        let parsedData = JSON.parse(inputData);

        let restaurants = {}

        for (const data of parsedData) {

            let [restaurantName, employees] = data.split(' - ');

            if (!restaurants.hasOwnProperty(restaurantName)) {
                restaurants[restaurantName] = {}
            }

            let splittedEmployees = employees.split(', ');

            for (const employeeData of splittedEmployees) {

                let [name, salary] = employeeData.split(' ');
                let parsedSalary = Number(salary)

                restaurants[restaurantName][name] = parsedSalary;
            }

        }

        let sortedRestaurants = {}

        for (const restaurant in restaurants) {

            sortedRestaurants[restaurant] = Object.entries(restaurants[restaurant]).sort((first, second) => second[1] - first[1]);
        }

        return sortedRestaurants;
    }


}