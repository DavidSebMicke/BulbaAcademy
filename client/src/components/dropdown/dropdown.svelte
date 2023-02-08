<!-- <script>
	let user = { loggedIn: false };

	function toggle() {
		user.loggedIn = !user.loggedIn;
	}
</script>

{#if user.loggedIn}
	<button on:click={toggle}>Log out</button>
{/if}

<div class="navbar">
	<a href="#home">Home</a>
	<a href="#news">News</a>
	<div class="dropdown">
		<button class="dropbtn"
			>Mer
			<i class="fa fa-caret-down" />
		</button>
		<div class="dropdown-content">
			<a href="#">Ändra profil</a>
			<a href="http://127.0.0.1:3000/loginPage">Logga ut</a><button
				id="logouts"
				on:click={toggle}>Logga ut</button
			>
		</div>
	</div>
</div>

<section class="modal hidden" />
<div class="overlay hidden" />

<section class="modal hidden">
	<div class="flex">
		<img class="logga" src="public\img\bulbi.png" width="50px" height="50px" alt="gfdk" />
		<button class="btn-close">⨉</button>
	</div>
	<div>
		<h3>Ändra lösenord</h3>
		<p>Fyll i din epostadress för att ändra lösenord.</p>
	</div>

	<input type="email" id="email" placeholder="brendaneich@js.com" />
	<button class="btn">Bekräfta</button>
	<br /><br />
	<div>
		<h3>Ändra epostadress</h3>
		<p>Fyll i din nya epostadress för att ändra.</p>
	</div>
	<input type="email" id="email" placeholder="brendaneich@js.com" />
	<button class="btn">Bekräfta</button>
	<br /><br />
	<div>
		<h3>Ändra epostadress</h3>
		<p>Skriv in din nya gatuadress för att ändra.</p>
	</div>
	<input type="address" id="address" placeholder="Bulbagatan 4" />
	<input type="postalno" id="postalno" placeholder="444 44" />
	<input type="postaladd" id="postaladd" placeholder="Göteborg" />
	<button class="btn">Bekräfta</button>
</section>

<div class="overlay hidden" />

<!-- <div class="navbar">
	<a href="#home">Home</a>
	<a href="#news">News</a>
	<div class="dropdown">
		<button class="dropbtn"
			>Mer
			<i class="fa fa-caret-down" />
		</button>
		<div class="dropdown-content">
			<a href="#">Ändra profil</a>
			<a href="http://127.0.0.1:3000/loginPage">Logga ut</a><button
				id="logouts"
				on:click={toggle}>Logga ut</button
			>
		</div>
	</div>
</div> -->
<style lang="less">
	@import 'public\less\variables.less';
	@import 'public\less\global.less';
	@import url('https://fonts.googleapis.com/css2?family=Inter&display=swap');
	@import url('https://fonts.googleapis.com/css2?family=Poiret+One&display=swap');

	.navbar {
		overflow: hidden;
		background-color: #333;
		font-family: Arial;
	}

	/* Länkarna i navbar */
	.navbar a {
		float: left;
		font-size: 16px;
		color: white;
		text-align: center;
		padding: 14px 16px;
		text-decoration: none;
	}

	/* Dropdown container */
	.dropdown {
		float: left;
		overflow: hidden;
	}

	/* Dropdown knappen */
	.dropdown .dropbtn {
		font-size: 16px;
		border: none;
		outline: none;
		color: white;
		padding: 14px 16px;
		background-color: inherit;
		font-family: inherit; /* Important for vertical align on mobile phones */
		margin: 0; /* Important for vertical align on mobile phones */
	}

	/* Lägger till bakgrundsfärg när man hovrar */
	.navbar a:hover,
	.dropdown:hover .dropbtn {
		background-color: black;
	}

	/* Dropdown content (hidden by default) */
	.dropdown-content {
		display: none;
		position: absolute;
		background-color: #f9f9f9;
		min-width: 160px;
		box-shadow: 0px 8px 16px 0px rgba(0, 0, 0, 0.2);
		z-index: 1;
	}

	/* Länkarna i dropdown */
	.dropdown-content a {
		float: none;
		color: black;
		padding: 12px 16px;
		text-decoration: none;
		display: block;
		text-align: left;
	}

	/* Bakgrundsfärg för dropdown länkarna när man hovrar */
	.dropdown-content a:hover {
		background-color: #ddd;
	}

	/* Visar dropdown menyn när man hovrar */
	.dropdown:hover .dropdown-content {
		display: block;
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

	* {
		margin: 0;
		padding: 0;
		box-sizing: border-box;
		font-family: 'Inter', sans-serif;
	}

	body {
		display: flex;
		flex-direction: column;
		align-items: center;
		justify-content: center;
		color: #222;
		position: relative;
		min-height: 100vh;
	}

	.modal {
		display: flex;
		flex-direction: column;
		justify-content: center;
		gap: 0.4rem;
		width: 450px;
		padding: 1.3rem;
		min-height: 250px;
		position: absolute;
		top: 20%;
		background-color: white;
		border: 1px solid #ddd;
		border-radius: 15px;
	}

	.modal .flex {
		display: flex;
		align-items: center;
		justify-content: space-between;
	}

	.modal input {
		padding: 0.7rem 1rem;
		border: 1px solid #ddd;
		border-radius: 5px;
		font-size: 0.9em;
	}

	.modal p {
		font-size: 0.9rem;
		color: #777;
		margin: 0.4rem 0 0.2rem;
	}

	button {
		cursor: pointer;
		border: none;
		font-weight: 600;
	}

	.btn {
		display: inline-block;
		padding: 0.6rem 1.4rem;
		font-weight: 600;
		background-color: black;
		color: white;
		border-radius: 5px;
		text-align: center;
		font-size: 1em;
	}

	.btn-open {
		position: absolute;
		bottom: 150px;
	}

	.btn-close {
		transform: translate(10px, -20px);
		padding: 0.5rem 0.7rem;
		background: #eee;
		border-radius: 50%;
	}
</style>
