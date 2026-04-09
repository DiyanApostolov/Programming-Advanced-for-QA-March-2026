import { chooseYourCar } from '../chooseYourCar.js'
import { describe } from 'mocha'
import { expect, assert } from 'chai';

describe('Test chooseYourCar', () => {
    describe('choosingType', () => {
        it('should throw an error on invalid input', () => {
            // year < 1900
            expect(() => chooseYourCar.choosingType("Sedan", "Blue", 1890)).to.throw(`Invalid Year!`)
            // year > 2022
            expect(() => chooseYourCar.choosingType("Sedan", "Blue", 2025)).to.throw(`Invalid Year!`)
            // type is not Sedan
            expect(() => chooseYourCar.choosingType("SportWagon", "Blue", 2020)).to.throw("This type of car is not what you are looking for.")
        });
        it('should meet requirments for a car', () => {
            // Arrage
            let type = 'Sedan'
            let color = 'Green'
            let year = 2008
            let expectedMessage = `This ${type} is too old for you, especially with that ${color} color.`

            // Act
            let result = chooseYourCar.choosingType(type, color, year)

            // Assert
            expect(result).to.equal(expectedMessage)
        });
        it('should not meet requirments for a car', () => {
            // Arrage
            let type = 'Sedan'
            let color = 'Blue'
            let year = 2018
            let expectedMessage = `This ${color} ${type} meets the requirements, that you have.`

            // Act
            let result = chooseYourCar.choosingType(type, color, year)

            // Assert
            expect(result).to.equal(expectedMessage)
            // year 2010
            expect(chooseYourCar.choosingType(type, color, 2010)).to.equal(expectedMessage)
        });
    });

    describe('brandName', () => {
        it('should throw an error on invalid input', () => {
            // first parametere is not array
            expect(() => chooseYourCar.brandName('opel', 3)).to.throw("Invalid Information!")
            // second parameter is not a integer
            expect(() => chooseYourCar.brandName(['opel'], 'pet')).to.throw("Invalid Information!")
            // if second parameter < 0
            expect(() => chooseYourCar.brandName(['opel'], -2)).to.throw("Invalid Information!")
            // if second parameter is greater than array length
            expect(() => chooseYourCar.brandName(['opel', 'bmw'], 5)).to.throw("Invalid Information!")
            // if second parameter is equal to array length
            expect(() => chooseYourCar.brandName(['opel', 'bmw'], 2)).to.throw("Invalid Information!")
        });

        it('should return the correct brands', () => {
            // Arrange
            let brands = ['opel', 'bmw', 'honda', 'toyota', 'mercedes']
            let index = 3
            let expected = 'opel, bmw, honda, mercedes'

            // Act
            let result = chooseYourCar.brandName(brands, index)

            // Assert
            expect(result).to.equal(expected)
        });
    });

    describe('carFuelConsumption', () => {
        it('should throw an error on invalid input', () => {
            // first parameters is not a number
            expect(() => chooseYourCar.carFuelConsumption('5', 20)).to.throw("Invalid Information!")
            // second parameters is not a number
            expect(() => chooseYourCar.carFuelConsumption(7, '30')).to.throw("Invalid Information!")
            // first parameters < 0
            expect(() => chooseYourCar.carFuelConsumption(-5, 20)).to.throw("Invalid Information!")
            // second parameters < 0
            expect(() => chooseYourCar.carFuelConsumption(5, -20)).to.throw("Invalid Information!")
            // first parameters = 0
            expect(() => chooseYourCar.carFuelConsumption(0, 20)).to.throw("Invalid Information!")
            // second parameters = 0
            expect(() => chooseYourCar.carFuelConsumption(5, 0)).to.throw("Invalid Information!")
        });

        it('should return message for an efficient car', () => {
            // Arrange
            let distanceInKilometers = 350
            let consumptedFuelInLiters = 20
            let expectedMessage = `The car is efficient enough, it burns 5.71 liters/100 km.`

            // Act
            let result = chooseYourCar.carFuelConsumption(distanceInKilometers, consumptedFuelInLiters)

            // Assert
            expect(result).to.equal(expectedMessage)
            // fuelConsumption = 7
            expect(chooseYourCar.carFuelConsumption(100, 7)).to.equal(`The car is efficient enough, it burns 7.00 liters/100 km.`)
        });

        it('should return message for an non efficient car', () => {
            // Arrange
            let distanceInKilometers = 245
            let consumptedFuelInLiters = 20
            let expectedMessage = `The car burns too much fuel - 8.16 liters!`

            // Act
            let result = chooseYourCar.carFuelConsumption(distanceInKilometers, consumptedFuelInLiters)

            // Assert
            expect(result).to.equal(expectedMessage)
        });
    });
});