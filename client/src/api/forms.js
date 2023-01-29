import axios from 'axios';
import {api} from './api'

export async function PasswordLogIn(inputEmail, inputPassword)
{
    const response = await api.request('Authentication/login',{
        method:'POST',
        data: {
			email : inputEmail,
			password : inputPassword
		}
    })
	
	if(response.ok){

		let data = await response.json();

		if(data.token){

			console.log(data.token);
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