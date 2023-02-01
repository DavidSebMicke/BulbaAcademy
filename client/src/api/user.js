import { redirect } from "@sveltejs/kit";
import {StoreInSession}from "../Utils/SessionStore.js"
import { api } from "./api.js";

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


const endpoint = "Authentication/login"; 
const url = "http://localhost:8000/api/Authentication/login"; 

export async function PasswordLogIn(inputEmail, inputPassword)
{
	
	const response = await api.post(endpoint, {
		email : inputEmail,
		password : inputPassword
	});

    // const response = await fetch(`${url}`, {
    //     method: 'POST',
    //     headers: {
    //         'Accept': 'application/json',
    //         'Content-Type': 'application/json'
    //     },
    //     body: JSON.stringify({
	// 		email : inputEmail,
	// 		password : inputPassword
	// 		})

    // });
	
	if(response.ok){

		let data = await response.data;

		if(data.token){

			StoreInSession("TwoFToken", data.token)
			return true;
		}
		else {
			return false;
		}
	}
	else{
		return false;
	}
}