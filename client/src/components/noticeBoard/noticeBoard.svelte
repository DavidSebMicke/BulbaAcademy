<script>
	import { truncateText, handleDateFormatting } from './noticeBoard';
	import NoticeModal from './noticeModal.svelte';
	import { fly } from 'svelte/transition';
	import { current_component } from 'svelte/internal';

	let messages = [
		{
			date: new Date('2023-01-04'),
			title: 'First',
			text: 'Dependent certainty off discovery him his tolerably offending. Do greatest at in learning steepest. Breakfast extremity suffering one who all otherwise suspected. He at no nothing forbade up moments. Wholly uneasy at missed be of pretty whence. John way sir high than law who week. Surrounded prosperous introduced it if is up dispatched.'
		},
		{
			date: new Date('2023-01-14'),
			title: 'Second',
			text: 'Improved so strictly produced answered elegance is.Give lady of they such they sure it. Me contained explained my education. Vulgar as hearts by garret. Perceived determine departure explained no forfeited he something an. Contrasted dissimilar get joy you instrument out reasonably.'
		},
		{
			date: new Date('2023-01-16'),
			title: 'Third',
			text: 'Again keeps at no meant stuff. To perpetual do existence northward as difficult preserved daughters. Continued at up to zealously necessary breakfast. Surrounded sir motionless she end literature.'
		},
		{
			date: new Date('2023-01-20'),
			title: 'Fourth',
			text: 'Gay direction neglected but supported yet her.Kept in sent gave feel will oh it we. Has pleasure procured men laughing shutters nay. Old insipidity motionless continuing law shy partiality.'
		},
		{
			date: new Date('2023-01-24'),
			title: 'Fifth',
			text: 'Depending acuteness dependent eat use dejection. Unpleasing astonished discovered not nor shy. Morning hearted now met yet beloved evening. Has and upon his last here must.'
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
		<button class="showMessage" on:click={toggleBanner}>Noticeboard</button>
	</div>
{:else}
	<div class="crisis-banner" transition:fly={{ x: -1000, duration: 800 }}>
		{#each messages as message, i}
			<div class="grid-items">
				<h3 class="noticeTitle" style="grid-column:{i}">{message.title}</h3>
				<li class="noticeMessage" style="grid-column:{i}">
					{truncateText(message.text)}
				</li>
				<li class="noticeDate" style="grid-column:{i}">
					{handleDateFormatting(message.date)}
				</li>
				<li class="noticeDate" style="grid-column:{i}">
					{handleDateFormatting(message.date)}
				</li>
				<button on:click={openModal} on:click={() => setIndexValue(i)} class="showMore"
					>Read more</button
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
		z-index: 99;
		background-color: @crisis-message-background;
		color: black;
		list-style: none;
		display: flex;
		border: 2px solid black;
		align-items: self-end;
	}
	.grid-items {
		border-right: 2px solid black;
	}

	.noticeTitle {
		margin: 0.5rem;
		font-size: 1.2rem;
		font-weight: 700;
		text-overflow: ellipsis;
		border-bottom: 1px solid @light-mode-flavour1;
	}
	.showMore {
		position: relative;
		padding: 10px 20px;
		text-decoration: underline;
		.classic-button;
		box-shadow: none;
		border-radius: 1px;
		margin: 3px;
	}
	.noticeMessage {
		text-align: center;
	}
	.closeCross {
		border: none;
		display: inline-flex;
		float: right;

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
