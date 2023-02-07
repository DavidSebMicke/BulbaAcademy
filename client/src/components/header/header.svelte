<script>
	export let title = 'Default Title';
</script>

<header>
	<h1>{title}</h1>
</header>

<style lang="less">
	header {
		display: flex;
		padding: 20px;
		justify-content: center;
		margin: 0;
		background-color: #d4d4dc;
	}

	header h1 {
		margin: 0;
		font-size: 2.5rem;
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
