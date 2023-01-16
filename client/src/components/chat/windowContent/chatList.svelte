<script>
	import dayjs from 'dayjs';
	// import NewChatModal from './newChatModal/newChatModal.svelte';

	let chatList = [
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

	export let activeChat = chatList[0];
	let showNewChatModal = false;

	const handleChatClick = (e, chat) => {
		activeChat = chat;
	};

	const openNewChatModal = (showNewChatModal = true);
	const closeNewChatModal = (showNewChatModal = false);
</script>

<div class="container">
	<div class="scrollContainer">
		{#each chatList as chat}
			<div
				class="chat"
				class:isSelected={chat.chatId == activeChat.chatId}
				on:click={(e) => handleChatClick(e, chat)}
				on:keydown={(e) => handleChatClick(e, chat)}
			>
				<div class="chatHeader">
					<div class="chatName">
						{chat.users[0].firstName}
						{chat.users[0].lastName}
					</div>
					<div class="chatTimestamp">
						{dayjs(chat.lastMessage.timestamp).format('DD/MM/YYYY HH:mm')}
					</div>
					<div class="chatContent">
						{chat.lastMessage.content}
					</div>
				</div>
			</div>
		{/each}
	</div>
	<button class="newChatButton" on:click={openNewChatModal}>
		<iconify-icon icon="ic:baseline-plus" width="1.5rem" />
		<p>New Chat</p>
	</button>
	<!-- {#if showNewChatModal}
		<NewChatModal />
	{/if} -->
</div>

<style lang="less">
	@import '../../../../public/less/variables.less';
	@import '../../../../public/less/global.less';

	.container {
		height: 22rem;
		display: grid;
		grid-template-rows: 1fr 3rem;
	}

	.scrollContainer {
		position: relative;
		overflow-y: scroll;
		overflow-x: hidden;
		padding: 0.2rem;
	}

	.chat {
		display: flex;
		flex-direction: column;
		width: 100%;
		padding-left: 0.25rem;
		padding-right: 1rem;
		height: fit-content;
		cursor: pointer;
		flex-wrap: wrap;
		overflow: hidden;
		justify-content: start;

		transition: all 0.3s ease;

		&:not(:last-child) {
			border-bottom: 1px solid @primary-color;
		}

		&:hover {
			background-color: rgb(205, 231, 255);
		}

		.chatHeader {
			display: flex;
			flex-direction: column;

			.chatName {
				font-size: 1.2rem;
				font-weight: 500;
			}

			.chatTimestamp {
				font-size: 0.7rem;
				font-weight: 400;
				color: rgb(43, 43, 43);
			}
		}

		.chatContent {
			font-size: 1rem;
			font-weight: 400;
			text-overflow: ellipsis;
			text-indent: 1rem;
			width: 10rem;
			overflow: hidden;
			white-space: nowrap;
			margin-top: 0.2rem;
			margin-bottom: 0.4rem;
		}
	}

	.isSelected {
		background-color: rgb(151, 206, 255);
	}

	.newChatButton {
		display: flex;
		align-items: center;
		justify-content: center;
		gap: 0.5rem;
		font-size: 1.2rem;
		text-align: center;
		height: 2rem;
		align-self: center;
		margin: 0.8rem 0.8rem 0.4rem 0.4rem;
		background-color: rgb(179, 219, 255);
		border: 0;
		border-radius: 1rem;

		padding-left: 0;

		cursor: pointer;

		& > p {
			padding-bottom: 0.1rem;
		}

		&:hover {
			background-color: rgb(151, 206, 255);
		}
	}
</style>
