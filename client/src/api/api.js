import axios from 'axios';

// Base for api calls. Import this and call .get, .post, etc.
export const api = () => {
	configureDefaultRequestHeaders();

	return axios.create({
		baseURL: 'http://localhost:8000/api/'
	});
};

// Used for setting the Authorization header for all calls
export const setAccessToken = (token) => {
	axios.AxiosHeaders.common['Authorization'] = `Bearer ${token}`;
};

export const configureDefaultRequestHeaders = () => {
	axios.defaults.headers.post({
		'Content-Type': 'application/json'
	});

	axios.defaults.headers.put({
		'Content-Type': 'application/json'
	});

	axios.defaults.headers.common({
		'Response-Type': 'application/json',
		'X-Content-Type-Options': 'nosniff',
		'Content-Security-Policy': 'default-src "self" localhost:8000/api/*;'
	});
};
