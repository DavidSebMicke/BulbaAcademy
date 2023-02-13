import { api } from "./api";
import jwt_decode from "jwt-decode";
import { logIn } from "../app.js";


// Move this to a separate api file later if it will be used by other components
export const getChatUsers = async (filter = '') => {
	const response = await api
		.get('/user/getallchatusers', { params: { filter } })
		.catch((error) => {
			console.log(error.message);
		});

	return response.data;
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
    
			var data = response.data;
		
			var loggedInUser = jwt_decode(data.idToken);
		
			if(!loggedInUser) return false;
			else{
				
				return logIn({idToken: data.idToken, accessToken: data.accessToken, loggedInUser:loggedInUser});
			}

		}
		else{
			return false;
		}

	} catch (err) {
		console.error(err);

		throw err;
	}

}

