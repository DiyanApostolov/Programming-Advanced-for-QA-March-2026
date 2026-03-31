
function solve(inputArray){
    for (const element of inputArray) {
        console.log(isPalindome(element))
    }

    function isPalindome(number){
        let numberAsString = number.toString()
        let reversedStrigNumber = numberAsString.split('').reverse().join('')

        if(numberAsString === reversedStrigNumber){
            return true
        } else {
            return false
        }
    }
}

// още по-функционано решение на задачата
function checkIsPalindome(inputArray){
    for (const number of inputArray) {
        console.log(number ==  number.toString().split('').reverse().join(''))        
    }
}

solve([123,323,421,121])