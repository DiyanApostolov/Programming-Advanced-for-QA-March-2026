function solve(a, b){
    let startIndex = Math.min(a.charCodeAt(), b.charCodeAt())
    let endIndex = Math.max(a.charCodeAt(), b.charCodeAt())

    let chars = []
    
    for (let i = startIndex + 1; i < endIndex; i++) {
        let currentChar = String.fromCharCode(i)
        chars.push(currentChar)
    }

    console.log(chars.join(' '))
}

solve('f','a')