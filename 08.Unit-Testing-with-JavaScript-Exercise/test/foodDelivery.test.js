import { foodDelivery } from "../foodDelivery.js"
import { expect } from "chai"

describe('Test foodDelivery', () => {
    describe('getCategory', () => {
        it('should return proper message for input Vegan', () => {
             let message = "Dishes that contain no animal products."
            expect(foodDelivery.getCategory("Vegan")).to.equal(message)
        })
        it('should return proper message for input Vegetarian', () => {
            let message = "Dishes that contain no meat or fish."
            expect(foodDelivery.getCategory("Vegetarian")).to.equal(message)
        })
        it('should return proper message for input Gluten-Free', () => {
            let message = "Dishes that contain no gluten."
            expect(foodDelivery.getCategory("Gluten-Free")).to.equal(message)
        })
        it('should return proper message for input All', () => {
            let message = "All available dishes."
            expect(foodDelivery.getCategory("All")).to.equal(message)
        })
        it('should throw an error if input parameter is not valid', () => {
            expect(() => foodDelivery.getCategory("invalid category")).to.throw("Invalid Category!")
        })
    })
    describe('addMenuItem', () => {
        it('should throw an error if input parameters are not valid', () => {
            // if frist parameter is not an array
            expect(() => foodDelivery.addMenuItem("invalid", 7)).to.throw("Invalid Information!")
            // if second parameter is not a number
            let arr = [
                { 
                    name: "Fish",
                    price: 12.5
                }
            ]
            expect(() => foodDelivery.addMenuItem(arr, 'invalid')).to.throw("Invalid Information!")
            // if first parameter is empty array
            expect(() => foodDelivery.addMenuItem([], 7)).to.throw("Invalid Information!")
            // if second parameter is not a number
            let arr2 = [
                { 
                    name: "Fish",
                    price: 12.5
                }
            ]
            expect(() => foodDelivery.addMenuItem(arr2, 3)).to.throw("Invalid Information!")
        })
        it('should return proper message if parameters are valid', () => {
            // Arrange
            let menu = [
                { name: "Fish", price: 12.5 },
                { name: "Dessert", price: 3.5 },
                { name: "Salad", price: 10.5 }
            ]
            let maxPrice = 10.5;
            let expected = `There are 2 available menu items matching your criteria!`

            // Act & Assert
            expect(foodDelivery.addMenuItem(menu, maxPrice)).to.equal(expected)
        })
        it('should return proper message if all items prices are gteater than maxPrice', () => {
             // Arrange
            let menu = [
                { name: "Fish", price: 12.5 },
                { name: "Dessert", price: 6.5 },
                { name: "Salad", price: 10.5 }
            ]
            let maxPrice = 6;
            let expected = `There are 0 available menu items matching your criteria!`

            // Act & Assert
            expect(foodDelivery.addMenuItem(menu, maxPrice)).to.equal(expected)
        })
    })
    describe('calculateOrderCost', () => {
        it('should throw an error if input parameters are not valid', () => {
             // if first parameter is not an array
            expect(() => foodDelivery.calculateOrderCost("invalid", ["sauce"], true)).to.throw("Invalid Information!")
            // if second parameter is not an array
            expect(() => foodDelivery.calculateOrderCost(["standard"], "invalid", true)).to.throw("Invalid Information!")
            // if third parameter is not a boolean
            expect(() => foodDelivery.calculateOrderCost(["standard"], ["sauce"], "invalid")).to.throw("Invalid Information!")       
        })
        it('should return proper message with discount', () => {
            // Arrange
            let shipping = ["standard", "standard", "express", "some"]
            let addons = ["beverage", "beverage", "sauce", "sauce", "some"]
            let priceWithDiscount = 20 * 0.85  // -15% discount
            let expected = `You spend $${priceWithDiscount.toFixed(2)} for shipping and addons with a 15% discount!`

            // Act & Assert
            expect(foodDelivery.calculateOrderCost(shipping, addons, true)).to.equal(expected)
        })
        it('should return proper message without discount', () => {
            // Arrange
            let shipping = ["standard", "standard", "express", "some"]
            let addons = ["beverage", "beverage", "sauce", "sauce", "some"]
            let totalPrice = 20 
            let expected = `You spend $${totalPrice.toFixed(2)} for shipping and addons!`

            // Act & Assert
            expect(foodDelivery.calculateOrderCost(shipping, addons, false)).to.equal(expected)
        })
    })
})