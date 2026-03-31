function oddAndEvenSum(number){
    let evenSum = 0;
    let oddSum = 0;

    // обръщам си числото в текст, за да мога да го сплитна на масив от текст
    let digitsArrray = number.toString().split('')
    
    for (const digit of digitsArrray) {
        // обръщам теска'5' в числото 5
        let currentDigit = Number(digit)

        if (currentDigit % 2 === 0){
            evenSum += currentDigit
        } else {
            oddSum += currentDigit
        }
    }

    console.log(`Odd sum = ${oddSum}, Even sum = ${evenSum}`)
}

oddAndEvenSum(1000435)