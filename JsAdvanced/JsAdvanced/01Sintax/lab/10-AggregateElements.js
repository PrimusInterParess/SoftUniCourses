function AggregateEleements(elements){
    Aggregate(elements,0, (a,b)=>a+b);
    Aggregate(elements,0, (a,b)=>a+1/b);
    Aggregate(elements,'', (a,b)=>a+b);

    function Aggregate(arr,intilaValue,func){
        let val = intilaValue;

        for (let index = 0; index < arr.length; index++) {
           
            val=func(val,arr[index]);

        }
        console.log(val);
    }
    

}
   
AggregateEleements([1,2,4])