function generateReport() {

    let columnsElements = document.querySelectorAll('input[type="checkbox"]');
    let checked = Array.from(columnsElements).map(c => c.checked);
    let data = Array.from(document.querySelectorAll('tbody tr'));

    let result = [];

    for (let i = 0; i < data.length; i++) {

        let currrentObject = {}

        for (let j = 0; j < checked.length; j++) {

            if (checked[j]) {
                currrentObject[columnsElements[j].name] = data[i].cells[j].textContent;
            }
        }
        result.push(currrentObject);
    }

    document.getElementById('output').textContent = JSON.stringify(result);

}
//     // let employee = document.getElementsByName('employee')[0];
//     // let deparment = document.getElementsByName('deparment')[0];
//     // let status = document.getElementsByName('status')[0];
//     // let dateHired = document.getElementsByName('dateHired')[0];
//     // let benefits = document.getElementsByName('benefits')[0];
//     // let salary = document.getElementsByName('salary')[0];
//     // let rating = document.getElementsByName('rating')[0];

//     let columnsName = getColumNames(document.querySelectorAll('thead tr th'))
//         // let checkBoxes = [
//         //     document.getElementsByName('employee')[0].checked,
//         //     document.getElementsByName('deparment')[0].checked,
//         //     document.getElementsByName('status')[0].checked,
//         //     document.getElementsByName('dateHired')[0].checked,
//         //     document.getElementsByName('benefits')[0].checked,
//         //     document.getElementsByName('salary')[0].checked,
//         //     document.getElementsByName('rating')[0].checked
//         // ]

//     let checkBoxElements = Array.from(document.querySelectorAll('input[type="checkbox"]'));

//     let checkBoxes = [];

//     checkBoxElements.forEach((e, i) => {
//         if (e.checked) {
//             checkBoxes.push(true)
//         } else {
//             checkBoxes.push(false)
//         }
//     });

//     let entries = document.querySelectorAll('tbody tr');
//     let resultData = [];

//     for (let index = 0; index < entries.length; index++) {

//         let employee = {};
//         for (let i = 0; i < checkBoxes.length; i++) {

//             if (checkBoxes[i]) {

//                 let entry = entries[index].getElementsByTagName('td')[i].textContent;

//                 if (entry != '') {
//                     employee[columnsName[i]] = entry;
//                 }
//             }
//         }

//         resultData.push(employee);
//     }


//     document.getElementById('output').textContent = JSON.stringify(resultData);


//     function getColumNames(nodeCollection) {
//         let result = []

//         for (const entity of nodeCollection) {
//             result.push(entity.innerText)

//         }

//         return result;
//     }


// }