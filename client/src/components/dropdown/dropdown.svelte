<script>
	let user = { loggedIn: false };

	function toggle() {
		user.loggedIn = !user.loggedIn;
	}
</script>

<button id="logouts" on:click={toggle}>Logga ut</button>

{#if user.loggedIn}
	<button on:click={toggle}>Log out</button>
{/if}

<nav class="navbar">
	<ul class="navbar-nav">
		<li class="nav-item">
			Mer<h />
			<select name="" required>
				<option value="Profil">Profil</option>
				<option value="Inställningar">Inställningar</option>
			</select>
		</li>
	</ul>
</nav>

<style lang="less">
	@import 'public\less\variables.less';
	@import 'public\less\global.less';
	@import url('https://fonts.googleapis.com/css2?family=Inter&display=swap');
	@import url('https://fonts.googleapis.com/css2?family=Poiret+One&display=swap');

	.navbar {
		// height: 40px;
		// width: 100%;
		display: flex;
		font-family: 'Inter', sans-serif;
		font-weight: medium;
		justify-content: right;
		height: 10rem;
		text-decoration: none;
		float: right;
		padding: 5px;
		overflow: hidden;
		margin: 20px;
	}
	.navbar-nav {
		font-family: 'Poiret One';
		font-weight: bold;
		list-style-type: none;
		margin: 0;
		padding: 0;
		// align-items: center;
		height: 100%;
	}
	#logouts {
		display: flex;
		font-family: 'Inter', sans-serif;
		font-weight: bold;
		justify-content: top;
		text-decoration: none;
		float: right;
		padding: 10px;
		overflow: hidden;
		margin: 20px;
		border-radius: 100px;
	}
</style>
