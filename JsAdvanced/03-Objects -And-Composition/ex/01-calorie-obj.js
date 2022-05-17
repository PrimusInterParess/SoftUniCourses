function createFoodObj(array) {
    let current = {}

    for (let index = 0; index < array.length; index += 2) {

        

        current[array[index]] = Number(array[index + 1]);

     

    }

    console.log(current)

}


createFoodObj(['Yoghurt', '48', 'Rise', '138', 'Apple', '52'])