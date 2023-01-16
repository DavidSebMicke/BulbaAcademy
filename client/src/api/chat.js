import { api } from './api';

// Get all chats for the user
export const getAllChats = () => {
	return [
		{
			chatId: '0001',
			users: [
				{
					firstName: 'John',
					lastName: 'Doe'
				}
			],
			lastMessage: {
				content: 'Hey! How ya doin',
				timestamp: '2022-01-12T12:22:00.000Z'
			}
		},
		{
			chatId: '0002',
			users: [
				{
					firstName: 'Jane',
					lastName: 'Doe'
				}
			],
			lastMessage: {
				content: 'Hi there! How ya doin over there?',
				timestamp: '2022-01-12T12:34:00.000Z'
			}
		},
		{
			chatId: '0003',
			users: [
				{
					firstName: 'Johnathan',
					lastName: 'Doeathan',
					guid: '0001'
				}
			],
			lastMessage: {
				content: 'Helloooo',
				timestamp: '2022-01-11T12:00:00.000Z'
			}
		},
		{
			chatId: '0004',
			users: [
				{
					firstName: 'John',
					lastName: 'Doe'
				}
			],
			lastMessage: {
				content: 'Hey! How ya doin',
				timestamp: '2022-01-12T12:22:00.000Z'
			}
		},
		{
			chatId: '0005',
			users: [
				{
					firstName: 'Jane',
					lastName: 'Doe'
				}
			],
			lastMessage: {
				content: 'Hi there! How ya doin over there?',
				timestamp: '2022-01-12T12:34:00.000Z'
			}
		},
		{
			chatId: '0006',
			users: [
				{
					firstName: 'Johnathan',
					lastName: 'Doeathan',
					guid: '0001'
				}
			],
			lastMessage: {
				content: 'Helloooo',
				timestamp: '2022-01-11T12:00:00.000Z'
			}
		},
		{
			chatId: '0007',
			users: [
				{
					firstName: 'John',
					lastName: 'Doe'
				}
			],
			lastMessage: {
				content: 'Hey! How ya doin',
				timestamp: '2022-01-12T12:22:00.000Z'
			}
		},
		{
			chatId: '0008',
			users: [
				{
					firstName: 'Jane',
					lastName: 'Doe'
				}
			],
			lastMessage: {
				content: 'Hi there! How ya doin over there?',
				timestamp: '2022-01-12T12:34:00.000Z'
			}
		},
		{
			chatId: '0009',
			users: [
				{
					firstName: 'Johnathan',
					lastName: 'Doeathan',
					guid: '0001'
				}
			],
			lastMessage: {
				content: 'Helloooo',
				timestamp: '2022-01-11T12:00:00.000Z'
			}
		}
	];
};

// Get whole chat by chatId
export const getChat = (chatId) => {
	return {
		chatId: '0001',
		users: [
			{
				id: '0001',
				firstName: 'John',
				lastName: 'Doe'
			}
		],
		messages: [
			{
				sender: '0001',
				content: 'Hey',
				timestamp: '2022-01-12T12:22:00.000Z'
			},
			{
				sender: '0002',
				content: 'Hey',
				timestamp: '2022-01-12T12:22:30.000Z'
			},
			{
				sender: '0001',
				content: 'How are you?',
				timestamp: '2022-01-12T12:23:00.000Z'
			},
			{
				sender: '0002',
				content: "I'm good",
				timestamp: '2022-01-12T12:24:30.000Z'
			},
			{
				sender: '0002',
				content: 'How are you?',
				timestamp: '2022-01-12T12:25:00.000Z'
			},
			{
				sender: '0001',
				content: 'Good aswell',
				timestamp: '2022-01-12T12:26:30.000Z'
			},
			{
				sender: '0002',
				content: 'Nice',
				timestamp: '2022-01-12T12:27:00.000Z'
			},
			{
				sender: '0001',
				content: 'Ok, bye',
				timestamp: '2022-01-12T12:28:30.000Z'
			},
			{
				sender: '0002',
				content: 'Goodbye',
				timestamp: '2022-01-12T12:29:00.000Z'
			},
			{
				sender: '0002',
				content: 'Goodbye',
				timestamp: '2022-01-12T12:29:00.000Z'
			},
			{
				sender: '0002',
				content:
					'Goodbye longer message long message long message long message long message long message',
				timestamp: '2022-01-12T12:29:00.000Z'
			},
			{
				sender: '0002',
				content: 'Goodbye',
				timestamp: '2022-01-12T12:29:00.000Z'
			}
		]
	};
};
