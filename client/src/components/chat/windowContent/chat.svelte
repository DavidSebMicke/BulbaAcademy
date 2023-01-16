<script>
	import { onMount } from 'svelte';
	import ChatMessage from './chatContent/chatMessage.svelte';

	// use this to fetch the chat data from the server
	export let activeChat = {
		chatId: '0001',
		users: [
			{
				id: '0001',
				firstName: 'John',
				lastName: 'Doe'
			}
		]
	};

	export let user = {
		id: '1111',
		firstName: 'Sender',
		lastName: 'Doe'
	};

	// THIS DATA WILL BE FETCHED LATER
	let chatData = {
		chatId: '0001',
		senders: [
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

	$: chatParticipants = activeChat.users
		.reduce((acc, sender) => {
			if (sender.id !== user.id) {
				acc.push(sender.firstName + ' ' + sender.lastName);
			}
			return acc;
		}, [])
		.join(', ');

	onMount(() => {
		const chatContainer = document.querySelector('.chatContainer');
		chatContainer.scrollTop = chatContainer.scrollHeight;
	});
</script>

<div class="container">
	<div class="chatHeader">{chatParticipants}</div>
	<div class="chatContainer">
		{#each chatData.messages as message}
			<ChatMessage {message} senders={chatData.senders} />
		{/each}
		<div class="chatInputContainer">
			<textarea class="chatInput" placeholder="Type a message..." maxlength="2000" />
		</div>
	</div>
</div>

<style lang="less">
	@import '../../../../public/less/variables.less';
	@import '../../../../public/less/global.less';

	.container {
		background: honeydew;
		display: grid;
		grid-template-rows: 2.5rem 1fr;
		height: 21.5rem;
	}

	.chatHeader {
		margin: 0.5rem;
		text-indent: 0.5rem;
		font-size: 1.2rem;
		white-space: nowrap;
		text-overflow: ellipsis;
		border-bottom: 1px solid @primary-color;
	}

	.chatContainer {
		height: 100%;
		display: flex;
		flex-direction: column;
		align-items: flex-start;
		padding: 0.4rem;

		overflow-y: scroll;
		overflow-x: hidden;
		scroll-behavior: smooth;
	}

	.chatInputContainer {
		width: 100%;
		height: fit-content;
		max-height: 10rem;
	}

	.chatInput {
		position: relative;
		bottom: 0;
		width: 95%;
		margin-top: 0.5rem;
		max-height: 1.5rem;
		resize: none;
		border: none;
		padding: 0.5rem;
		font-size: 1.2rem;
		border-radius: 0.5rem;
		font-size: 1rem;

		&:focus {
			outline: rgb(0, 119, 255) solid 1px;
		}
	}
</style>
