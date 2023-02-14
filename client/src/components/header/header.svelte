<script>
	export let title = 'default title';
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
		background-image: url('public/img/children.avif');
		background-position: center;
		width: 100%;
		position: relative;
		background-size: cover;
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
