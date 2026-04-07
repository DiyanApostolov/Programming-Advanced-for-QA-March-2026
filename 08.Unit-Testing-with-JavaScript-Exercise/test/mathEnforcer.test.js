import { describe } from 'mocha'
import {mathEnforcer} from '../mathEnforcer.js'
import {assert} from 'chai'

describe('test-mathEnforcer', ()=> {
    describe('addFive', () => {
        it('should return undefined if parameter is not a number', () => {
            assert.equal(mathEnforcer.addFive('42'), undefined)
            assert.equal(mathEnforcer.addFive([]), undefined)
            assert.equal(mathEnforcer.addFive({}), undefined)
            assert.equal(mathEnforcer.addFive(null), undefined)
            assert.equal(mathEnforcer.addFive(undefined), undefined)
        })
        it('shoud return input parameter plus five', () => {
            assert.equal(mathEnforcer.addFive(7), 12)
            assert.equal(mathEnforcer.addFive(-3), 2)
            assert.closeTo(mathEnforcer.addFive(5.5), 10.5, 0.01)
        })
    })
    describe('subtractTen', () => {
        it('should return undefined if parameter is not a number', () => {
            assert.equal(mathEnforcer.subtractTen('42'), undefined)
            assert.equal(mathEnforcer.subtractTen([]), undefined)
            assert.equal(mathEnforcer.subtractTen({}), undefined)
            assert.equal(mathEnforcer.subtractTen(null), undefined)
            assert.equal(mathEnforcer.subtractTen(undefined), undefined)
        })
        it('should return parameter minus ten', () => {
            assert.equal(mathEnforcer.subtractTen(30), 20)
            assert.equal(mathEnforcer.subtractTen(10), 0)
            assert.equal(mathEnforcer.subtractTen(5), -5)
            assert.equal(mathEnforcer.subtractTen(-15), -25)
            assert.closeTo(mathEnforcer.subtractTen(-5.25), -15.25, 0.01)
        })
    })
    describe('sum', () => {
        it('should return undefined if any parameter is not a number', () => {
            assert.equal(mathEnforcer.sum('pet', 5), undefined, 'first parameters is a number')
            assert.equal(mathEnforcer.sum(7, 'pet'), undefined, 'second parameters is a number')
        })
        it('should return sum if both parameters are numbers', () => {
            assert.equal(mathEnforcer.sum(3, 9), 12)
            assert.equal(mathEnforcer.sum(5, 0), 5)
            assert.equal(mathEnforcer.sum(3, -9), -6)
            assert.equal(mathEnforcer.sum(-3, -9), -12)
            assert.closeTo(mathEnforcer.sum(3.24, 7.33), 10.57, 0.01)
        })
    })
})