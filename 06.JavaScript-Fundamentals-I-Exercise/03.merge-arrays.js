function solve(arr1, arr2){
    let outputArray = []

    for (let i = 0; i < arr1.length; i++) {
        if(i % 2 === 0){
            outputArray.push(Number(arr1[i]) + Number(arr2[i])) // sum
        } else {
            outputArray.push(arr1[i] + arr2[i]) // concatenation
        }
    }

    console.log(outputArray.join(' - '))
}

solve(['13', '12312', '5', '77', '4'],
['22', '333', '5', '122', '44']
)