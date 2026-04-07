import {lookupChar} from '../charLookUp.js'
import {expect} from 'chai'

describe('test-charLookUp', () => {
    it('should return undefined if first parameter is not a string', () =>{
        // Arrange
        let firstParameter = 42
        let secondParameter = 7

        // Act
        let result = lookupChar(firstParameter, secondParameter)

        // Assert
        expect(result).to.be.undefined
    })
     it('should return undefined if second parameter is not a integer number', () =>{
        // Arrange
        let firstParameter = 'hello'
        let secondParameter = '5'

        // Act
        let result = lookupChar(firstParameter, secondParameter)

        // Assert
        expect(result).to.be.undefined
        expect(lookupChar(firstParameter, 5.5)).to.be.undefined
        expect(lookupChar(firstParameter, [])).to.be.undefined
        expect(lookupChar(firstParameter, {})).to.be.undefined
        expect(lookupChar(firstParameter, null)).to.be.undefined
        expect(lookupChar(firstParameter, undefined)).to.be.undefined
    })
    it('shoud return text "Incorrect index" if index is invalid', () => {
        // Arrange
        let firstParameter = 'hello'
        let expected = "Incorrect index"

        // Act & Assert
        expect(lookupChar(firstParameter, -1)).to.equal(expected) // negative index
        expect(lookupChar(firstParameter, 10)).to.equal(expected) // greater than length
        expect(lookupChar(firstParameter, 5)).to.equal(expected) // equal to length
    })
    it('shoud return character if input parameres are valid', () => {
        // Arrange
        let firstParameter = 'hello'
        let secondParameter = 1
        let expected = 'e'

        // Act
        let result = lookupChar(firstParameter, secondParameter)

        // Assert
        expect(result).to.equal(expected)
    })
})