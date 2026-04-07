import {analyzeArray} from '../arrayAnalyzer.js'
import { expect } from 'chai'

describe('test-arrayAnalyzer', () => {
    it('should return undefined if input parameter is not a array', () => {
        expect(analyzeArray(42)).to.be.undefined
        expect(analyzeArray('array')).to.be.undefined
        expect(analyzeArray({})).to.be.undefined
        expect(analyzeArray(null)).to.be.undefined
        expect(analyzeArray(undefined)).to.be.undefined
    })
    it('should return undefined if input parameter is empty array', () => {
        expect(analyzeArray([])).to.be.undefined
    })
    it('should return undefined if any element in the array is not a number', () => {
        expect(analyzeArray([3, 12, 'text', 7, 42])).to.be.undefined
        expect(analyzeArray([3, 12, [], 7, 42])).to.be.undefined
        expect(analyzeArray([3, 12, {}, 7, 42])).to.be.undefined
        expect(analyzeArray([3, 12, null, 7, 42])).to.be.undefined
        expect(analyzeArray([3, 12, undefined, 7, 42])).to.be.undefined
    })
    it('should return object if input parametere is array with numbers', () => {
        // Arrange
        let input = [3, 7, 12, 5, 42, 8]

        // Act
        let result = analyzeArray(input)

        // Assert
        expect(result.min).to.equal(3)
        expect(result.max).to.equal(42)
        expect(result.length).to.equal(6)  
    })
    it('should return object if input parametere is array with one element', () => {
        // Arrange
        let input = [3]

        // Act
        let result = analyzeArray(input)

        // Assert
        expect(result.min).to.equal(3)
        expect(result.max).to.equal(3)
        expect(result.length).to.equal(1)  
    })
     it('should return object if input parametere is array with equal elements', () => {
        // Arrange
        let input = [3, 3, 3, 3, 3, 3, 3, 3]

        // Act
        let result = analyzeArray(input)

        // Assert
        expect(result.min).to.equal(3)
        expect(result.max).to.equal(3)
        expect(result.length).to.equal(8)  
    })
})