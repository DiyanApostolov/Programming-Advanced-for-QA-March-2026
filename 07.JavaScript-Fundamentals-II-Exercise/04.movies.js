function solve(inputArray){
    let movies = [] // масив в който ще пазя всички филми

    for (const movieInfo of inputArray) {
        if(movieInfo.startsWith('addMovie')){
            let movieName = movieInfo.substring(9)
            movies.push({name: movieName}) // добавям нов анонимен обект (филм) само с име
        } else if (movieInfo.includes('directedBy')){
            let [movieName, directorName] = movieInfo.split(' directedBy ')

            // търся по референция филма в колекцията
            let movie = movies.find(m => m.name === movieName)

            // ако е наметило такъв филм === true
            // ако movie е останало undefined (няма такъв филм) === false
            if(movie){
                movie.director = directorName
            }
        } else if (movieInfo.includes('onDate')){
            let [movieName, movieDate] = movieInfo.split(' onDate ')

            // търся по референция филма в колекцията
            let movie = movies.find(m => m.name === movieName)

            if(movie){
                movie.date = movieDate
            }
        }
    }

    for (const movie of movies) {
        // ако не намети пропърти director === false
        // ако не намети пропърти date === false
        if(movie.director && movie.date){
            console.log(JSON.stringify(movie))
        }

        // JSON.stringify -> представя обекта във формат JSON
    }
}

solve([
'addMovie The Avengers',
'addMovie Superman',
'The Avengers directedBy Anthony Russo',
'The Avengers onDate 30.07.2010',
'Captain America onDate 30.07.2010',
'Captain America directedBy Joe Russo'
]
)