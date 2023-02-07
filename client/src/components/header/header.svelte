<script>
	export let title = 'Default Title';
</script>

<header>
	<div class="background-div">
		<h1>{title}</h1>
	</div>
</header>

<style lang="less">
	@import 'public/less/global.less';
	header {
		display: flex;
		padding: 20px;
		justify-content: left;
		margin: 0;
		font-size: 2.5rem;
	}
	.background-div {
		width: 100%;
		background-color: var(--bg-color);
	}

	header h1 {
		margin: 0;
		font-weight: 700;
	}

	header nav ul {
		display: flex;
		list-style: none;
		margin: 0;
		padding: 0;
	}

	header nav a {
		display: block;
		padding: 10px 20px;
		color: black;
		text-decoration: none;
	}

	header nav a:hover {
		background-color: gray;
		color: white;
	}
</style>
