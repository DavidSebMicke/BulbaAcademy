import { api, setAccessToken } from './api.js';
import jwt_decode from 'jwt-decode';
import { setCookie } from '../Utils/CookieUtils';

export async function PasswordLogIn(loginForm) {
	const endpoint = 'Authentication/login';
	try {
		const response = await api.post(endpoint, {
			email: loginForm.email,
			password: loginForm.password
		});
		if (response.status == 200) {
			return response.data;
		} else {
			return false;
		}
	} catch (err) {
		console.error(err);

		throw err;
	}
}

export async function TOTPLogIn(twoFToken, code) {
	const endpoint = 'Authentication/login/totp';
	try {
		const response = await api.post(endpoint, {
			twoFToken: twoFToken,
			code: code
		});
		if (response.status == 200) {
			var data = response.data;
			setAccessToken(data.accessToken);

			var loggedInUser = jwt_decode(data.idToken);

			//StoreInSession("IDToken", data.idToken);
			//StoreInSession("LoggedInUser", JSON.stringify(loggedInUser));
			//document.cookie = `IDToken=${data.idToken}; SameSite=None; Secure`;
			//document.cookie = `LoggedInUser=${JSON.stringify(loggedInUser)}; SameSite=None; Secure`;

			if (!loggedInUser) return false;
			else {
				setCookie('IDToken', data.idToken, '/');
				setCookie('LoggedInUser', JSON.stringify(loggedInUser), '/');
				return true;
			}
		} else {
			return false;
		}
	} catch (err) {
		console.error(err);

		throw err;
	}
}
