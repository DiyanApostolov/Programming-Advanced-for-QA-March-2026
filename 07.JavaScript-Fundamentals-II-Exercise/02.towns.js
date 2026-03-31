function solve(inputArray){
    class Town{
        constructor(townName, lat, long){
            this.name = townName
            this.latitude = Number(lat)
            this.longitude = Number(long)
        }

        printInfo(){
            return `{ town: '${this.name}', latitude: '${this.latitude.toFixed(2)}', longitude: '${this.longitude.toFixed(2)}' }`
        }
    }

    for (const element of inputArray) {
        let [townName, townLatitude, townLongiitude] = element.split(' | ')

        let city = new Town(townName, townLatitude, townLongiitude)

        console.log(city.printInfo())
    }
}

solve(['Sofia | 42.696552 | 23.32601',
'Beijing | 39.913818 | 116.363625']
)