import axios from 'axios';
import {api} from './api'

const endpoint = "Caregiver/CreateCaregiversAndChild"; 

export async function RegisterChildWithCaregivers(inputForm)
{
	
	
	try {
		
		const response = await api.post(endpoint, inputForm);
		return response.data
	}
	catch (error){
		console.error(error);
		throw error
	}
	
}