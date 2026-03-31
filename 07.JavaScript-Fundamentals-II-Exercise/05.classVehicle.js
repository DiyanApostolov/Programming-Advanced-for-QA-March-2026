class Vehicle{
    constructor(type, model, parts, fuel){
        this.type = type
        this.model = model
        this.parts = {
            engine: parts.engine,
            power: parts.power,
            quality: parts.engine * parts.power
        }
        this.fuel = fuel
    }

    drive(fuelLoss){
        this.fuel -= fuelLoss
    }
}

// let parts = { engine: 6, power: 100 };
// let vehicle = new Vehicle('Opel', 'Astra', parts, 200);
// vehicle.drive(100);
// console.log(vehicle.fuel);
// console.log(vehicle.parts.quality);

let parts = {engine: 9, power: 500};
let vehicle = new Vehicle('Honda', 'C-RV', parts, 840);
vehicle.drive(20);
console.log(JSON.stringify(vehicle));




