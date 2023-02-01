import axios from 'axios';
import {api} from './api'

const endpoint = "Caregiver/CreateCaregiversAndChild"; 

export async function RegisterChildWithCaregivers(inputForm)
{
	
	const response = await api.post(endpoint, inputForm);
	console.log(response);
	
	if(response.ok){
		console.log("Hej23");
		let data = await response.data;
		console.log(data);
		return true;

	}
	else
	{
		return false;
	}
}