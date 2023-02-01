import axios from 'axios';
import {api} from './api'

const endpoint = "Caregiver/CreateCaregiversAndChild"; 

export async function RegisterChildWithCaregivers(inputForm)
{
	console.log("Hej2");
	
	const response = await api.post(endpoint, inputForm);
	
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