import { redirect } from "@sveltejs/kit";
import {StoreInSession}from "../Utils/SessionStore.js"
import { api, setAccessToken } from "./api.js";
import jwt_decode from "jwt-decode";

// Move this to a separate api file later if it will be used by other components
export const getUsers = (filter = '') => {
	return [
		{
			id: '0001',
			firstName: 'John',
			lastName: 'Doe'
		},
		{
			id: '0002',
			firstName: 'Jane',
			lastName: 'Doe'
		},
		{
			id: '0003',
			firstName: 'Johnathan',
			lastName: 'Doeathan'
		},
		{
			id: '0004',
			firstName: 'John',
			lastName: 'Doe'
		},
		{
			id: '0005',
			firstName: 'Jane',
			lastName: 'Doe'
		},
		{
			id: '0006',
			firstName: 'Johnathan',
			lastName: 'Doeathan'
		},
		{
			id: '0007',
			firstName: 'John',
			lastName: 'Doe'
		},
		{
			id: '0008',
			firstName: 'Jane',
			lastName: 'Doe'
		},
		{
			id: '0009',
			firstName: 'Johnathan',
			lastName: 'Doeathan'
		}
	].filter(
		(user) =>
			user.firstName.toLowerCase().includes(filter.toLowerCase()) ||
			user.lastName.toLowerCase().includes(filter.toLowerCase())
	);
	// Filter should be done in backend later

	
};




export async function PasswordLogIn(loginForm)
{
	const endpoint = "Authentication/login"; 
	try{
		const response = await api.post(endpoint, {
			email : loginForm.email,
			password : loginForm.password
		});		
		if(response.status == 200){
			
			return response.data;
		}
		else{
			return false;
		}

	} catch (err) {
		console.error(err);

		throw err;
	}

}


export async function TOTPLogIn(twoFToken, code)
{
	const endpoint = "Authentication/login/totp"; 
	try{
		const response = await api.post(endpoint, {
			twoFToken : twoFToken,
			code : code
		});		
		if(response.status == 200){
			var data = response.data
			setAccessToken(data.accessToken);

		
			var loggedInUser = jwt_decode(data.idToken);

			StoreInSession("IDToken", data.idToken);
			StoreInSession("LoggedInUser", JSON.stringify(loggedInUser));

			return loggedInUser;
		}
		else{
			return false;
		}

	} catch (err) {
		console.error(err);

		throw err;
	}

}