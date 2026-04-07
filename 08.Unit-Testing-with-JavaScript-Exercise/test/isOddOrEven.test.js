import {isOddOrEven} from '../isOddOrEven.js'
import {describe} from 'mocha'
import {expect} from 'chai'

describe('test-isEvenOrOdd', ()=>{
    it('should return undefined if input parameter is not a string', () =>{
        // Arrange
        let input = 7

        // Act
        let result = isOddOrEven(input)

        // Assert
        expect(result).to.be.undefined
        expect(isOddOrEven([7, 32])).to.be.undefined
        expect(isOddOrEven({})).to.be.undefined
        expect(isOddOrEven(null)).to.be.undefined
        expect(isOddOrEven(undefined)).to.be.undefined
    })
    it('should return text "even" if input string has even length', () =>{
        // Arrange
        let input = 'Dido'
        let expected = 'even'

        // Act
        let result = isOddOrEven(input)

        // Assert
        expect(result).to.equal(expected)
    })
    it('should return text "odd" if input string has odd length', () =>{
        // Arrange
        let input = 'Hello'
        let expected = 'odd'

        // Act
        let result = isOddOrEven(input)

        // Assert
        expect(result).to.equal(expected)
    })
})