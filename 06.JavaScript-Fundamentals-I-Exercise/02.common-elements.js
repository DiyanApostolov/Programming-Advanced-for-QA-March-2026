function solve(firstArray, secondArray){
    for (let i = 0; i < firstArray.length; i++) {
        const firstArrayElement = firstArray[i];
        
        if(secondArray.includes(firstArrayElement)){
            console.log(firstArrayElement)
        }
        
    }
}

solve(['Hey', 'hello', 2, 4, 'Peter', 'e'],
      ['Petar', 10, 'hey', 4, 'hello', '2']
) 