// PASSWORD VALIODATION CHECKS FOR svelte-use-form
// Uses regex to check if the input is valid and returns an error message in Swedish if it is not
// Check at least 3 lowercase letters
export function containsLowerCase(str) {
	var isValid = /([a-z]){3,}/.test(str);
	return isValid
		? null
		: {
				notEnoughLowerCaseLetters: 'Ditt lösenord måste bestå av minst 3 små bokstäver.'
		  };
}

// Check at least 3 uppercase letters
export function containsUpperCase(str) {
	var isValid = /([A-Z]){3,}/.test(str);
	return isValid
		? null
		: {
				notEnoughUpperCaseLetters: 'Ditt lösenord måste bestå av minst 3 stora bokstäver.'
		  };
}

// check at least 3 numbers
export function containsNumbers(str) {
	var isValid = /([0-9]){3,}/.test(str);
	return isValid
		? null
		: { notEnoughNumbersInPassword: 'Ditt lösenord måste bestå av minst 3 siffror.' };
}

// check that string does not contain spaces
export function doesNotContainSpaces(str) {
	var isValid = !/\s/.test(str);
	return isValid
		? null
		: { notEnoughNumbersInPassword: 'Ditt lösenord får inte innehålla mellanslag.' };
}


// check at least 1 special character
export function containsSpecialChars(str) {
	var isValid = /([!@#$%&*()\\[\]{}\-_+=~|:"',./?]){1,}/.test(str);
	return isValid
		? null
		: {
				noSpecialCharsInPassword:
					'Ditt lösenord måste bestå av minst 3 specialtecken.\n Specialtecknen: !@#$%^&*()\\[]{}-_+=~`|:;"\'<>,./?'
		  };
}

// Check that the passwords match
export function passwordsMatch(str1, form) {
	var isValid = str1 === form.password.value;
	return isValid ? null : { passwordsDoNotMatch: 'Lösenorden är inte lika.' };
}

// Try using minlength on input instead. Keeping the function for now incase it works
export function lengthAtLeast(str, min) {
	var isValid = str.length >= min;
	return isValid ? null : { inputTooShort: `Behöver vara minst ${min} långt.` };
}

// Checks if the input is a valid email
export function emailCheck(str) {
	var isValid = /[a-zA-Z0-9]+@[a-zA-Z0-9]+\.[a-zA-Z0-9]+/.test(str);
	return isValid ? null : { invalidEmail: 'Ogiltig epost.' };
}

// Tests the string (removes dashes(-) and spaces) and makes sure that it either starts with a + or a 0, and that it contains only numbers after that
export function phoneNumberCheck(str) {
	str = str.replace('-', '');
	str = str.replace(' ', '');
	var isValid = /(0|\+)[0-9]+/.test(str);

	return isValid ? null : { invalidPhoneNumber: 'Ogiltigt telefonnumer.' };
}

// Checks the postcode. Removes spaces and makes sure that it only contains numbers (and the spaces)
export function postCodeCheck(str) {
	str = str.replace(' ', '');
	var isValid = /^[0-9]+/.test(str);
	return isValid ? null : { invalidPostCode: 'Ogiltig postkod.' };
}

// Checks the street address. Makes sure that it only contains letters, numbers, and spaces
export function streetAddressCheck(str) {
	var isValid = /[a-zA-Z]+[ ]?[0-9]*[ ]?[a-zA-Z]*/.test(str);
	return isValid ? null : { invalidStreetAddress: 'Ogiltig gatuadress.' };
}

// Checkes if the city contains only letters
export function cityCheck(str) {
	var isValid = /[a-zA-Z]+/.test(str);
	return isValid ? null : { invalidCity: 'Ogiltigt stadsnamn.' };
}

// Checks if the input contains only letters
export function onlyLettersCheck(str) {
	var isValid = /[a-zA-Z]+/.test(str);
	return isValid ? null : { invalidInput: 'Endast bokstäver tillåtna.' };
}

// Checks if the input contains only numbers
export function onlyNumbersCheck(str) {
	var isValid = /[0-9]+/.test(str);
	return isValid ? null : { invalidInput: 'Endast siffror tillåtna.' };
}

// Checks if the input is a valid SSN (Swedish personal number)
export function SSNCheck(str) {
	var isValid =
		/[0-9]{4}-[0-9]{2}-[0-9]{2}-[0-9]{4}/.test(str) || // 0000-00-00-0000 - 12-digit format with - separator between all 4 parts
		/[0-9]{8}-[0-9]{4}/.test(str) || // 00000000-0000 - 12-digit format with - separator
		/[0-9]{12}/.test(str) || // 000000000000 - 12-digit format
		/[0-9]{10}/.test(str) || // 0000000000 - 10-digit format
		/[0-9]{6}-[0-9]{4}/.test(str); // 0000000000 - 10-digit format with separator for last 4

	return isValid ? null : { invalidSSN: 'Ogiltigt personnummer.' };
}

// Checks if the input is a valid 2FA code (6 digits)
export function TwoFactorInputCheck(str) {
	var isValid = /[0-9]{3}[ ]?[0-9]{3}/.test(str); // 000000 or 000 000
	return isValid ? null : { invalid2FACode: 'Ogiltig kod. Sex siffror krävs.' };
}
