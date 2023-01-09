export function containsLowerCase (str){    
    return /([a-z]){3}/.test(str);
};


export function containsUpperCase (str){    
    return /([A-Z]){3}/.test(str);
};

export function containsNumbers (str){    
    return /([0-9]){3}/.test(str);
};

export function containsSpecialChars (str){    
    return /([\!@#$%^&*()\\[\]{}\-_+=~`|:;"'<>,./?])/.test(str);
};

export function lengthAtLeast (str, min){    
    return str.length >= min;
};



