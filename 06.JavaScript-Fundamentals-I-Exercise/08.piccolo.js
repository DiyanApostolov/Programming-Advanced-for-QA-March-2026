function solve(inputArray){
    let parkingLot = []

    for (const carInfo of inputArray) {
        let direction = carInfo.split(', ')[0]
        let carNumber = carInfo.split(', ')[1]

        if (direction === 'IN'){
            // check if the car is already in the parking lot]
            if(!parkingLot.includes(carNumber)){
                parkingLot.push(carNumber)
            }
        } else if (direction === 'OUT'){
            let carIndex = parkingLot.indexOf(carNumber)

            if (carIndex != -1){
                parkingLot.splice(carIndex, 1)
            }
        }
    }

    if (parkingLot.length === 0){
        console.log("Parking Lot is Empty")
    } else {
        for (const carNumber of parkingLot.sort()) {
            console.log(carNumber)
        }
    }
}

solve(['IN, CA2844AA',
'IN, CA1234TA',
'OUT, CA2844AA',
'OUT, CA1234TA']

)