function solve(input){
    let wordsArray = input.toLowerCase().split(' ')

    let outputWords = {}

    for (const word of wordsArray) {
        // ckeck if word is a key in outputWords
        if(word in outputWords){
            outputWords[word]++
        } else {
            outputWords[word] = 1
        }
    }

    let output = []

    // (for in) array takes only keys form outputWords
    for (const key in outputWords) {
        if (outputWords[key] % 2 === 1){
            output.push(key)
        }
    }

    console.log(output.join(' '))
}

solve('Cake IS SWEET is Soft CAKE sweet Food')