
let commands = ['create pesho', 'create gosho inherit pesho', 'create stamat inherit gosho', 'set pesho rank number1', 'set gosho nick goshko', 'print stamat'];


result(commands)

function result(data) {

    let res = factory();

    for (const operation of data) {
        let args = operation.split(' ');

        if (args[0] == 'create' && args.length == 2) {
            res.create(args[1]);
        } else if (args[0] == 'create') {
            res.create(args[1]);
            res.inherit(args[1], args[3]);
        } else if (args[0] == 'set') {
            res.set(args[1], args[2], args[3]);
        } else {
            res.print(args[1]);
        }
    }

    function factory() {

        let storage = {}

        return {
            create,
            inherit,
            set,
            print,
        }

        function create(elName) {
            storage[elName] = {
                parent: '',
                properties: {}
            }
        }

        function inherit(name, parentName) {
            storage[name].parent = parentName;
        }

        function set(name, key, value) {
            storage[name].properties[key] = value;
        }

        function print(name) {
            let currentObj = storage[name];
            let result;
            let isTrue = true;

            while (Object.keys(currentObj).length != 0) {
                if (Object.keys(currentObj.properties).length != 0) {
                    result.push(currentObj.properties)

                }

                currentObj = storage[currentObj.parent];

            }

            console.log(result);
        }


    }


}






