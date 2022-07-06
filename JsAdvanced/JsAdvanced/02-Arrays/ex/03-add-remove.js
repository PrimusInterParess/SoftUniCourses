function addRemove(array) {
    let result = [];

    let num = 1;

    while (array.length > 0) {

        let command = array.shift();

        if (command == 'add') {
            result.push(num);
        } else {
            if (result.length <= 0) {

                break;
            }
            else {
                result.pop();
            }
        }

        num += 1;
    }

    if(result.length==0){
        return 'Empty'

    }else{
        return  result.join('\n');
    }

    }



console.log(solved);