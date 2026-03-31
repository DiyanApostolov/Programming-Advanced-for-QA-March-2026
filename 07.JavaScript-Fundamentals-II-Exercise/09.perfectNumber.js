function perfectNumber(number){
    let sumProperPositiveDivisors = 0;

    for (let i = 1; i < number; i++) {
        if(number % i === 0){
            sumProperPositiveDivisors += i;
        }  
    }

    if (number === sumProperPositiveDivisors){
        console.log("We have a perfect number!")
    } else {
        console.log("It's not so perfect.")
    }
}

perfectNumber(1236498)