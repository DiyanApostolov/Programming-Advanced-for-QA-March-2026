function lookupChar(text, index) {
    if (typeof(text) !== 'string' || !Number.isInteger(index)) {
        return undefined;
    }
    if (text.length <= index || index < 0) {
        return "Incorrect index";
    }

    return text.charAt(index);
}

export {
    lookupChar
}