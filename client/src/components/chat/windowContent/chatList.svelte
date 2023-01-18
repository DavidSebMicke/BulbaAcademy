<script>
	import dayjs from 'dayjs';
	import { getAllChats } from '../../../api/chat';

	// Move this to onMount when backend is implemented
	let chatList = getAllChats();

	export let openNewChat;
	export let activeChat = chatList[0];

	const handleChatClick = (e, chat) => {
		if (e.key && e.key !== 'Enter') return;

		activeChat = chat;
	};
</script>

<div class="container">
	<div class="scrollContainer">
		{#each chatList as chat}
			<div
				class="chatHeader"
				class:isSelected={chat.chatId == activeChat.chatId}
				on:click={(e) => handleChatClick(e, chat)}
				on:keydown={(e) => handleChatClick(e, chat)}
			>
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
		{/each}
	</div>
	<button class="newChatButton" on:click={openNewChat}>
		<iconify-icon icon="ic:baseline-plus" width="24" />
		New Chat
	</button>
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

	.chatHeader {
		display: flex;
		flex-direction: column;
		width: 100%;
		padding-left: 0.25rem;
		padding-right: 1rem;
		height: fit-content;
		cursor: pointer;
		flex-wrap: nowrap;
		white-space: nowrap;
		overflow: hidden;
		justify-content: start;

		transition: all 0.3s ease-out;

		&:not(:last-child) {
			border-bottom: 1px solid @light-mode-flavour1;
		}

		&:hover {
			background-color: rgb(40, 58, 75);
		}

		& :global(div) {
			background-color: transparent;
		}

		.chatName {
			font-size: 1.2rem;
			font-weight: 500;
		}

		.chatTimestamp {
			font-size: 0.7rem;
			font-weight: 400;
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
		background-color: rgb(1, 50, 94);
	}

	.newChatButton {
		display: flex;
		align-items: center;
		justify-content: center;
		gap: 0.5rem;
		font-size: 1.2rem;
		text-align: center;
		height: 2rem;
		width: 10rem;
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
