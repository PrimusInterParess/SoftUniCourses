function prevDay(year, month, day) {
    let date = new Date(`${year}-${month}-${day}`,)

    const previous = new Date(date.getTime());
    previous.setDate(date.getDate() - 1);

    let dd = previous.getDate();

    let mm = previous.getMonth()+1;
    let yyyy = previous.getFullYear();
     
    let prev=`${yyyy}-${mm}-${dd}`;

    console.log(prev);
}

prevDay(2016, 9, 30)