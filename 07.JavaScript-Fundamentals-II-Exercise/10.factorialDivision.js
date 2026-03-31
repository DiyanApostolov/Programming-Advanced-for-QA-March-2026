function factorialDivision(firstNum, secondNum) {
    let factorial1 = factorial(firstNum);
    let factorial2 = factorial(secondNum);
    let result = factorial1 / factorial2

    return result.toFixed(2);

    function factorial(num) {
        let factorial = 1;
        for (let i = 1; i <= num; i++) {
            factorial *= i;
        }
        return factorial;
    }
}