<script>
	import { truncateText, handleDateFormatting } from './noticeBoard';
	import NoticeModal from './noticeModal.svelte';
	import { fly } from 'svelte/transition';
	import ClickOutside from '../../Utils/ClickOutside';

	let messages = [
		{
			date: new Date('2023-01-04'),
			title: 'Varning för löss!!!',
			text: '1. Finkamma barnen med en luskam och behandla de som har levande löss innan skolan börjar efter ett längre lov. Det är det bästa sättet att förhindra lusepidemier.\n \n 2. Stryk av kammen på ett vitt papper efter varje kamtag. Om det finns löss i håret fastnar de i kammen eller hamnar på underlaget.\n \n 3. Leta efter lusägg på hårstrået nära hårbotten. De kan vara lättare att upptäcka än själva lössen. De ägg som innehåller den blivande lusen är mörka. De tomma äggen är ljusa, ofta gulvita, ovala, ungefär en millimeter långa och följer med hårstråets utväxt.'
		}, 
		{
			date: new Date('2023-02-17'),
			title: 'Löss....IGEN!',
			text: 'Stryk av kammen på ett vitt papper efter varje kamtag. Om det finns löss i håret fastnar de i kammen eller hamnar på underlaget.\n \n Annars Leta efter lusägg på hårstrået nära hårbotten. De kan vara lättare att upptäcka än själva lössen. De ägg som innehåller den blivande lusen är mörka. De tomma äggen är ljusa, ofta gulvita, ovala, ungefär en millimeter långa och följer med hårstråets utväxt.\n \n I värsta fall finkamma barnen med en luskam och behandla de som har levande löss innan skolan börjar efter ett längre lov. Det är det bästa sättet att förhindra lusepidemier.'
		}
	];
	let currentItem = null;
	let showModal = false;
	let showBanner = false;

	function openModal() {
		showModal = true;
	}
	function setIndexValue(indexNumber) {
		currentItem = messages[indexNumber];
	}

	function closeModal(event) {
		showModal = event.detail.Boolean;
		currentItem = null;
	}
	function toggleBanner() {
		showBanner = !showBanner;
	}
</script>

{#if !showBanner}
	<div class="messageButton">
		<button class="showMessage" on:click={toggleBanner}>Anslagstavla</button>
	</div>
{:else}
	<div class="crisis-banner" transition:fly={{ x: -1000, duration: 800 }} use:ClickOutside on:click_outside={toggleBanner}>
		{#each messages as message, i}
			<div class="grid-items">
				<h3 class="noticeTitle" style="grid-column:{i}">{message.title}</h3>
				<li class="noticeMessage" style="grid-column:{i}">
					{truncateText(message.text)}
				</li>
				<li class="noticeDate" style="grid-column:{i}">
					{handleDateFormatting(message.date)}
				</li>
			
				<button on:click={openModal} on:click={() => setIndexValue(i)} class="showMore"
					>Läs vidare...</button
				>
				{#if showModal}
					<NoticeModal {...currentItem} on:message={closeModal} />
				{/if}
				{#if i + 1 == messages.length}
					<button class="closeCross" on:click={toggleBanner}>
						<iconify-icon icon="material-symbols:close" width="30" />
					</button>
				{/if}
			</div>
		{/each}
	</div>
{/if}

<style lang="less">
	.noticeMe {
		width: 80%;
		height: 70%;
		position: relative;
		left: 10%;
	}
	@import 'public\less\global.less';

	.crisis-banner {
		position: absolute;
		top: 0;
		left: 0;
		z-index: 99;
		background-color: @crisis-message-background;
		color: black;
		text-align: center;
		width:100%;
		list-style: none;
		display: flex;
		align-items: self-end;
	}
	.grid-items {
		border-right: 2px solid black;
		width: 100%;
	}

	.noticeTitle {
		margin: 0.5rem;
		font-size: 1.2rem;
		font-weight: 700;
		text-overflow: ellipsis;
		border-bottom: 3px solid @light-mode-flavour1;
	}
	.showMore {
		position: relative;
		padding: 10px 20px;
		.classic-button;
		margin: 3px;
		border: none !important;
		background-color: transparent !important;
		font-size: 2em;
		&:hover {
			border: none !important;
		background-color: transparent !important;
		}
	}
	.noticeMessage {
		text-align: center;
	}
	.closeCross {
		bottom: 0;
    position: absolute;
    border: none;
    right: 0;
	background-color: transparent !important;

		&:hover {
			cursor: pointer;
		}
	}
	.messageButton {
		display: inline-flex;
		float: right;
	}
	.showMessage {
		padding: 0.2em;
		.classic-button;
	}
	.noticeDate {
		font-weight: 600;
		margin-top: 0.2em;
		text-align: center;
	}
</style>
