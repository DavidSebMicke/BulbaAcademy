import { api } from './api.js';

export async function GetAllGroups() {
	const endpoint = '/Group/GetAllGroups';
	try {
		const response = await api.get(endpoint);
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