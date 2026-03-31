// solution with empty object
function solve(inputArray){
    let person = {} // empty object

    for (const element of inputArray) {
        person.name = element
        person.personalNumber = element.length
        console.log(`Name: ${person.name} -- Personal Number: ${person.personalNumber}`)
    }
}

// slution with class
function employee(inputArray){
    class Employee{
        constructor(name, personalNumber){
            this.fullName = name
            this.personalNumber = personalNumber
        }

        printInfo(){
           return `Name: ${this.fullName} -- Personal Number: ${this.personalNumber}`
        }
    }

    for (const name of inputArray) {
        let personalNumber = name.length

        // new instantion of class Employee
        let newEmployee = new Employee(name, personalNumber)

        // call method printInfo for every object
        console.log(newEmployee.printInfo())
    }
}

employee([
'Silas Butler',
'Adnaan Buckley',
'Juan Peterson',
'Brendan Villarreal'
]
)