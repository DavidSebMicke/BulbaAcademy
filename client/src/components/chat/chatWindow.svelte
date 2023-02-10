<script>
	import { scale } from 'svelte/transition';
	import ClickOutside from '../../Utils/ClickOutside';
	import ChatList from './windowContent/chatList.svelte';
	import Chat from './windowContent/chat.svelte';

	export let closeChat;

	let activeChat = {
		chatId: undefined,
		users: [],
		messages: []
	};

	let scaleOptions = {
		duration: 100
	};

	// Open new chat clears the active chat
	const openNewChat = () => {
		activeChat = {
			chatId: undefined,
			users: [],
			messages: []
		};
	};
</script>

<div class="chatWindow" in:scale={scaleOptions} use:ClickOutside on:click_outside={closeChat}>
	<div class="chatHeader">
		<h2>Active Chats</h2>
		<button on:click={closeChat} class="exitButton">
			<iconify-icon icon="material-symbols:close" width="24" />
		</button>
	</div>
	<div class="mainContainer">
		<ChatList bind:activeChat {openNewChat} />
		<Chat bind:activeChat />
	</div>
</div>

<style lang="less">
	@import '../../../public/less/variables.less';
	@import '../../../public/less/global.less';

	.chatWindow {
		position: relative;
		background-color: var(--bg-color);
		border: 1px solid rgb(172, 161, 161);
		width: 35rem;
		height: 25rem;
		border-radius: 1rem;
		transition: all 0.5s ease-out;
		display: flex;
		align-items: flex-start;
		flex-direction: column;
		overflow: hidden;

		box-shadow: 0 0 3px 1px @light-mode-flavour1;
	}

	.mainContainer {
		display: grid;
		grid-template-columns: 1fr 2fr;
		padding: 0 0.1rem 0 0.1rem;
		height: 22.5rem;
	}

	.chatHeader {
		width: 100%;
		height: 2.5rem;
		display: grid;
		grid-template-columns: 1fr 1fr;
		border-bottom: 1px solid black;

		h2 {
			margin: 0.5rem;
		}
	}

	.exitButton {
		width: fit-content;
		height: fit-content;
		justify-self: right;
		margin: 0.5rem;
		background-color: transparent;
		border: none;
		opacity: 0.4;
		cursor: pointer;

		&:hover {
			opacity: 1;
		}
	}
</style>
