<script>
	import { createEventDispatcher } from 'svelte';
	import ClickOutside from '../../Utils/ClickOutside';
	export let title;
	export let date;
	export let text;
	const dispatch = createEventDispatcher();

	function CloseModal() {
		dispatch('message', {
			Boolean: false
		});
	}
</script>

<div class="modal" use:ClickOutside on:click_outside={CloseModal}>
	<div class="modal-content">
		<h2>{title}</h2>
		<div>
			{text}
		</div>
		<p>{date}</p>
		<button class="buttondispatch" on:click={CloseModal}>Close</button>
	</div>
</div>

<style lang="less">
	@import 'public/less/global.less';
	.modal {
		position: fixed;
		top: 0;
		left: 0;
		width: 100%;
		height: 100%;
		background-color: rgba(0, 0, 0, 0.5);
		z-index: 10;
	}
	.buttondispatch {
		.classic-button;
		position: absolute;
		top: 10px;
		right: 10px;
		font-weight: bold;
	}

	.modal-content {
		position: fixed;
		top: 50%;
		left: 50%;
		transform: translate(-50%, -50%);
		background-color: #fff;
		width: 80%;
		max-width: 600px;
		padding: 20px;
		z-index: 11;
	}
</style>
