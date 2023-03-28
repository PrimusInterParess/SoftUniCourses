function pieceOfPie(arr,firstFlavour,secondFlavour){

    let start=arr.indexOf(firstFlavour);
    let end=arr.indexOf(secondFlavour)+1;

    return arr.slice(start,end);

}


var result = pieceOfPie(['Pumpkin Pie',
'Key Lime Pie',
'Cherry Pie',
'Lemon Meringue Pie',
'Sugar Cream Pie'],
'Key Lime Pie',
'Lemon Meringue Pie'
);