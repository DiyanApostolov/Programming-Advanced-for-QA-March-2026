import { workforceManagement } from "../workforceManagement.js"
import { expect } from "chai"

describe.only('Test_workforceManagement', () => {
    describe('recruitStaff', () => { //(name - string, role - string, experience - number)
        it('should return correct message', () => {
            expect(workforceManagement.recruitStaff('Ivanov', 'Developer', 0))
            .to.equal('Ivanov is not suitable for this role.');

            expect(workforceManagement.recruitStaff('Petrov', 'Developer', 4))
            .to.equal('Petrov has been successfully recruited for the role of Developer.');
        })     
        it('shoud throw an error for invalid role', () => {
              expect(() => workforceManagement.recruitStaff('Ivanov', 'QA', 0))
            .to.throw('We are not currently hiring for this role.');
        })
    })
    describe('computeWages', () => { // hoursWorked - number
        it('should throw an error for incorrect hoursWorked', () => {
             expect(() => workforceManagement.computeWages('asd')).to.throw('Invalid hours');
            expect(() => workforceManagement.computeWages(-5)).to.throw('Invalid hours');                     
        })
        it('should return correct payment', () => {
             expect(workforceManagement.computeWages(100)).to.equal(1800);
            expect(workforceManagement.computeWages(200)).to.equal(5100);
        })
    })
    describe('dismissEmployee', () => { //workforce - [string], employeeIndex - int index
        it('should throw an error if input parameters are not valid', () => {
             expect(() => workforceManagement.dismissEmployee()).to.throw('Invalid input');
            expect(() => workforceManagement.dismissEmployee(['Ivan', 'Dragan'], 3.14)).to.throw('Invalid input');
            expect(() => workforceManagement.dismissEmployee(['Ivan', 'Dragan'], 3)).to.throw('Invalid input');
            expect(() => workforceManagement.dismissEmployee(['Ivan', 'Dragan'], -1)).to.throw('Invalid input');
            expect(() => workforceManagement.dismissEmployee({}, 1)).to.throw('Invalid input');
            expect(() => workforceManagement.dismissEmployee(undefined, 1)).to.throw('Invalid input');
        })
        it('should return correct message', () => {
             expect(workforceManagement.dismissEmployee(['Ivan', 'Dragan'], 1)).to.equal('Ivan');
            expect(workforceManagement.dismissEmployee(['Ivan', 'Dragan', 'Petkan'], 1)).to.equal('Ivan, Petkan');
        })
    })
})