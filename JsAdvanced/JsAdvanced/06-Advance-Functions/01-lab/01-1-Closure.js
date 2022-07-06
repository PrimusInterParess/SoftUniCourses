function createRect(width,heigth){

    function getHeigth(){
        return heigth;
    }

    function getWidth(){
        return width;
    }

    function getAre(){
        return width*heigth;0
    }

    return{
        getWidth,
        getHeigth,
    }
}

const myRect = createRect(3,5);

console.log(myRect);