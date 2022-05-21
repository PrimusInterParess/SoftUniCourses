function sumTable() {

    let table = document.querySelectorAll("table tr");
    let total = 0;
    for (let i = 1; i < table.length; i++) {
      let cols = table[i].children;
      let cost = cols[cols.length - 1].textContent;
      total += Number(cost);
    }
    document.getElementById("sum").textContent = total;
  


    // let elements = Array.from(document.querySelectorAll('td:nth-child(even)'));
    // let sumElement = document.getElementById('sum');

    // let total = elements.pop();
    // let sum = 0;

    // for (const obj of elements) {
    //     let currentValue = Number(obj.innerHTML);
    //     sum += currentValue;
    // }

    // sumElement.textContent = sum;
}