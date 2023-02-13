import { api } from "./api";


// Move this to a separate api file later if it will be used by other components
export const getCareGiverByID = async (id) => {
	const response = await api
		.get('/Caregiver', { params: {
            id: id
        } })
		.catch((error) => {
			console.log(error.message);
		});

	return response.data;
};

