<script>
	import { onMount } from 'svelte';
	import { getChat } from '../../../api/chat';
	import { getUsers } from '../../../api/user';
	import Select from 'svelte-select';
	import ChatMessage from './chatContent/chatMessage.svelte';
	import { formatUsersForSelect } from './chat';

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

	// Move this to onMount/some responsive thing later to fetch the data once the backend is implemented
	activeChat = getChat();

	let users = getUsers();
	$: formattedUsers = formatUsersForSelect(users);
	let selectedUsers = [];
	let messageText;

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

	const sendMessage = () => {
		if (activeChat.messages.length > 0) {
			activeChat = sendMessage(activeChat.chatId, messageText);
		} else {
			activeChat = createChat(
				selectedUsers.map((u) => u.value),
				messageText
			);
		}
	};
</script>

<div class="container">
	<!-- Chat header -->
	<!-- No chatId = new chat -->
	{#if !activeChat.chatId}
		<div class="chatHeader">
			<!-- Use loadOptions later for async loading -->
			<div class="headerScrollContainer">
				<Select
					placeholder="Add a user"
					items={formattedUsers}
					bind:value={selectedUsers}
					multiple={true}
				/>
			</div>
		</div>
	{:else}
		<div class="chatHeader">{chatParticipants}</div>
	{/if}

	<!-- Chat -->
	<div class="chatContainer">
		{#if activeChat.messages}
			{#each activeChat.messages as message}
				<ChatMessage {message} senders={activeChat.users} />
			{/each}
		{/if}
	</div>

	<!-- Chat input -->
	<div class="chatInputContainer">
		<textarea
			class="chatInput"
			bind:value={messageText}
			placeholder="Type a message..."
			maxlength="2000"
		/>
		<button class="sendButton" on:click={sendMessage}>
			<iconify-icon icon="material-symbols:send-outline-rounded" width="auto" /></button
		>
	</div>
</div>

<style lang="less">
	@import '../../../../public/less/variables.less';
	@import '../../../../public/less/global.less';

	.container {
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
		border-bottom: 1px solid @light-mode-flavour1;

		// Custom styling for the select component
		:global(*) {
			--background: rgb(58, 78, 76);
			--multi-item-padding: 0;
			--input-padding: 0;
			--item-padding: 0;
			--margin: 0;
			--padding: 0;
			--height: 1.5rem;
			--list-max-height: 10rem;
			--item-color: @dark-mode-text;
			--list-background: rgb(128, 128, 128);
			--item-hover-bg: rgb(151, 151, 151);
			--multi-item-bg: rgb(151, 151, 151);
			--list-empty-color: @dark-mode-text;
			--multi-select-input-padding: 0;
			--multi-item-height: 1.5rem;
		}
	}

	.headerSelectContainer {
		max-height: 10rem;
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
		position: relative;
		width: 95%;
		height: fit-content;
		margin-left: 0.2rem;
	}

	.chatInput {
		width: 100%;
		margin-top: 0.5rem;
		max-height: 2rem;
		resize: none;
		border: none;
		padding: 0.5rem;
		padding-right: 6rem;
		border-radius: 0.5rem;
		font-size: 1rem;

		transition: all 0.3s ease-out;

		&:focus {
			outline: rgb(0, 119, 255) solid 1px;
			max-height: 5rem;
		}
	}

	.sendButton {
		position: absolute;
		right: 0;
		top: 0;
		display: flex;
		align-items: center;
		justify-content: center;
		height: 100%;
		height: 2rem;
		width: 5rem;
		margin-top: 0.5rem;
		border: none;
		border-left: 1px solid black;
		border-radius: 0 0.5rem 0.5rem 0;
		background-color: white;

		transition: all 0.3s ease;

		cursor: pointer;

		iconify-icon {
			transition: all 0.3s ease;
		}

		&:hover {
			background-color: rgb(166, 196, 206);
		}

		&:hover > iconify-icon {
			color: rgb(0, 119, 255);
		}
	}

	.chatInput:focus + .sendButton {
		height: 4.45rem;

		iconify-icon {
			transform: scale(1.2);
		}
	}
</style>