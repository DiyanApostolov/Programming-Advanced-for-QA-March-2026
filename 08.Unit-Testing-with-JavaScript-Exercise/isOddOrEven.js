function isOddOrEven(text) {
    if (typeof(text) !== 'string') {
        return undefined;
    }
    if (text.length % 2 === 0) {
        return "even";
    }

    return "odd";
}

export {
    isOddOrEven
}
