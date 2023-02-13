import { api } from './api';

// Get all chats for the user (with the last message)
export const getAllChats = async () => {
	const response = await api.get('/chat/list').catch((error) => {
		console.log(error.message);
	});

	return response.data;
};

// Get whole chat by chatId
export const getChat = async (chatId) => {
	const response = await api
		.get('/chat', {
			params: {
				id: chatId
			}
		})
		.catch((error) => {
			console.log(error.message);
		});

	return response.data;
};

// Send a message in a chat
export const sendMessage = async (chatId, message) => {
	const response = await api
		.post('/chat/send', {
			chatId,
			message
		})
		.catch((error) => {
			console.log(error.message);
		});

	return response.data;
};

// Create a new chat with the given users (adds the current user in backend)
export const createChat = async (userIds, message) => {
	const response = await api
		.post('/chat/create', {
			users: userIds,
			message
		})
		.catch((error) => {
			console.log(error.message);
		});

	return response.data;
};
