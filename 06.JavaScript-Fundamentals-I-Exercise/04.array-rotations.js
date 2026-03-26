function solve(arr, rotations){
    for (let i = 0; i < rotations; i++) {
        // take first element and remove from array
        const firstElement = arr.shift()
        
        // add first element to the end
        arr.push(firstElement)
    }

    console.log(arr.join(' '))
}

solve([51, 47, 32, 61, 21], 2)