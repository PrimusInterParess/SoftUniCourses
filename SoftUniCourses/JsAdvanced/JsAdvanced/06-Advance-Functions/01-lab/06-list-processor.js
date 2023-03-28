
function result(array) {

    let operator = solve();
    let result = '';

    for (const pair of array) {
        let [command, value] = pair.split(' ');

        if (command != 'print') {
            operator[command](value);

        } else {
            result = operator[command]();
        }

    }

    return result;


    function solve() {

        let result = [];

        return {
            add,
            remove,
            print,
        }

        function add(str) {
            result.push(str);
        }

        function remove(str) {
            result = result.filter(e => e !== str);
        }

        function print() {
            console.log(result.join(','))
        }
    }
}



let see = operations(['add hello', 'add again', 'remove hello', 'add again', 'print']);

let fine = operations(['add pesho', 'add george', 'add peter', 'remove peter', 'print']);


