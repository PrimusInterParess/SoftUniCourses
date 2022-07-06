
let commands = ['create pesho', 'create gosho inherit pesho', 'create stamat inherit gosho', 'set pesho rank number1', 'set gosho nick goshko', 'print stamat'];
let command1 = ['create c1',
    'create c2 inherit c1',
    'set c1 color red',
    'set c2 model new',
    'print c1',
    'print c2']
    ;



result(commands)
result(command1)

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

            let result = [];
            let currentName = name;

            let loopBreaker = true;

            while (loopBreaker) {
                loopBreaker = storage[currentName].parent != '';
                let props = storage[currentName].properties;

                if (Object.keys(props).length != 0) {

                    result = result.concat(Object.keys(props).map(k => `${k}:${props[k]}`));
                }
                currentName = storage[currentName].parent;
            }
            console.log(result.join(','));

        }
    }


}









