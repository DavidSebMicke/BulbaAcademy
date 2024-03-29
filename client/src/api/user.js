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

