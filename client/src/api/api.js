import axios from 'axios';
import { GetFromSession } from '../Utils/SessionStore';

// Base for api calls. Import this and call .get, .post, etc.
export const api = axios.create({
	baseURL: 'http://localhost:8000/api/',
	validateStatus: () => true
});

api.interceptors.request.use(
	function (config) {
		const token = localStorage.getItem('AccessToken');
		if (token) {
			config.headers['Authorization'] = 'Bearer ' + token;
		}
		return config;
	},
	function (error) {
		return Promise.reject(error);
	}
);

// Used for setting the Authorization header for all calls
export const setAccessToken = (token) => {
	api.defaults.headers.common['Authorization'] = `Bearer ${token}`;
	api.defaults.headers.common['Content-Type'] = 'application/json';
	api.defaults.headers.common['X-Content-Type-Options'] = 'nosniff';
	api.defaults.headers.common['Content-Security-Policy'] =
		'default-src "self" localhost:8000/api/*;';
};

const configureDefaultRequestHeaders = () => {
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
