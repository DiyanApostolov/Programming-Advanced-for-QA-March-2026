function solve(numbers){
    // [5, 15, 23, 56, 35]

    let originalSum = 0;
    let modifiedSum = 0;

    for (let i = 0; i < numbers.length; i++) {
        originalSum += numbers[i]

       if(numbers[i] %2 === 0){
        numbers[i] += i
       } else {
        numbers[i] -= i
       }
        
       modifiedSum += numbers[i]
    }

    console.log(numbers)
    console.log(originalSum)
    console.log(modifiedSum)
}

solve([-5, 11, 3, 0, 2])