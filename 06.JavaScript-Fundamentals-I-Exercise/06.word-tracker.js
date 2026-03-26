function solve(inputArray){
    // take first element with shift and remove from inputArray
    // split by whitespace
    let wordToTrack = inputArray.shift().split(' ')

    // create new object for key value pair collection
    let outputWords = {}

    for (const element of wordToTrack) {
        // create keys with every words to track
        outputWords[element] = 0
    }

    for (const currentWord of inputArray) {
        // ckeck if currentWord is a key in outputWords
        if(currentWord in outputWords){
            outputWords[currentWord]++;
        }
    }

    // create array with key-value pairs from outputWords object
    let entries = Object.entries(outputWords)

    // sort array in descennding order
    entries.sort((a, b) => b[1] - a[1])

    for (let[word, count] of entries) {
        console.log(`${word} - ${count}`)
    }
}

solve([
'this sentence', 
'In', 'this', 'sentence', 'you', 'have', 'to', 'count', 'the', 'occurrences', 'of', 'the', 'words', 'this', 'and', 'sentence', 'because', 'this', 'is', 'your', 'task'
]
)