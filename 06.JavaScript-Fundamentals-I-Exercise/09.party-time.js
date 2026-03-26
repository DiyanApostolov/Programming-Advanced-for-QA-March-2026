function solve(inputArray){
    let guestList = []

    while(inputArray[0] !== 'PARTY'){
        let currentGuest = inputArray.shift()
        guestList.push(currentGuest)
    }

    // remove command 'PARTY'
    inputArray.shift()

    for (const commingGuest of inputArray) {
        if(guestList.includes(commingGuest)){
            let guestIndex = guestList.indexOf(commingGuest)
            guestList.splice(guestIndex, 1)
        }
    }

    let vipGuests = guestList.filter(guest => !isNaN(guest[0]))
    let regularGuests = guestList.filter(guest => isNaN(guest[0]))

    console.log(guestList.length)
    console.log(vipGuests.join('\n'))
    console.log(regularGuests.join('\n'))
}

solve(['m8rfQBvl',
'fc1oZCE0',
'UgffRkOn',
'7ugX7bm0',
'9CQBGUeJ',
'2FQZT3uC',
'dziNz78I',
'mdSGyQCJ',
'LjcVpmDL',
'fPXNHpm1',
'HTTbwRmM',
'B5yTkMQi',
'8N0FThqG',
'xys2FYzn',
'MDzcM9ZK',
'PARTY',
'2FQZT3uC',
'dziNz78I',
'mdSGyQCJ',
'LjcVpmDL',
'fPXNHpm1',
'HTTbwRmM',
'B5yTkMQi',
'8N0FThqG',
'm8rfQBvl',
'fc1oZCE0',
'UgffRkOn',
'7ugX7bm0',
'9CQBGUeJ'
]

)