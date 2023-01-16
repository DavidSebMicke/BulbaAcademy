<script>
	import Profilecard from './profilecard/profilecard.svelte';
</script>

<div class="aboutHeader">Bulba Academy - The Staff</div>

<div class="aboutContainer">
	<div class="moreinfo" />
	<Profilecard />
</div>

<style lang="less">
	.aboutContainer {
		height: 100%;
		display: flex;
		background-color: #e1b382;
	}

	.aboutHeader {
		text-align: center;
		width: 100%;
		font-size: 4rem;
		font-family: 'Times New Roman', Times, serif;
		background-color: #2d545e;
		color: #c89666;
		text-shadow: white 1.5px 0.5px 0.5px;
	}
</style>
