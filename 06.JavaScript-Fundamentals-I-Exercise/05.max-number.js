function solve(numbers){
    let outputArray = []

    for (let i = 0; i < numbers.length; i++) {
        const currentElement = numbers[i];
        let isTopInteger = true

        for (let j = i + 1; j < numbers.length; j++) {
            const nextRigthElement = numbers[j];
            
            if(nextRigthElement >= currentElement){
                isTopInteger = false
                break
            }
        }

        if(isTopInteger){
            outputArray.push(currentElement)
        }
    }

    console.log(outputArray.join(' '))
}

solve([14, 24, 3, 19, 15, 17])