<script>
	import { fade } from 'svelte/transition';
	const fadeIn = {
		delay: 100,
		duration: 200
	};

	const fadeOut = {
		delay: 0,
		duration: 100
	};

	let isExpanded = false;
</script>

<nav class="navbar">
	<ul class="navbar-nav">
		<li class="nav-item">Hem</li>
		<li class="nav-item">Logga ut</li>
		<li class="nav-item">Profil</li>
		<li class="nav-mer">
			<a href="mer"
				>Mer
				<select name="" required>
					<option value="Meddelanden">Meddelanden</option>
					<option value="Lärlogg">Lärlogg</option>
					<option value="Planeringar">Planeringar</option>
					<option value="Lämna Hämta">Lämna Hämta</option>
					<option value="Schema">Schema</option>
					<option value="Kontaktlistor">Kontaktlistor</option>
					<option value="Profil">Profil</option>
					<option value="Inställningar">Inställningar</option>
					<option value="Logga ut">Logga ut</option>
				</select>
			</a>
		</li>

		<li class="nav-item has-dropdown">
			<a href="#">Theme</a>

			<ul class="dropdown">
				<li class="dropdown-item">
					<a href="#">light</a>
				</li>
				<li class="dropdown-item">
					<a href="#">dark</a>
				</li>
				<li class="dropdown-item">
					<a href="#">solarize</a>
				</li>
			</ul>
			<a href="#">Profil</a>
			<a href="#">Logga ut</a>
			<!-- <div class="drop">
                <title>Verktyg</title>
             -->
			<!-- <button
                    ><h2>Mer</h2>
                    <select name="" required>
                        <option value="Meddelanden">Meddelanden</option>
                        <option value="Lärlogg">Lärlogg</option>
                        <option value="Planeringar">Planeringar</option>
                        <option value="Lämna Hämta">Lämna Hämta</option>
                        <option value="Schema">Schema</option>
                        <option value="Kontaktlistor">Kontaktlistor</option>
                        <option value="Profil">Profil</option>
                        <option value="Inställningar">Inställningar</option>
                        <option value="Logga ut">Logga ut</option>
                    </select>
                </button>
            </div> -->
		</li>
	</ul>
</nav>

<style lang="less">
	@import 'public\less\variables.less';
	@import 'public\less\global.less';

	.navbar {
		height: 70px;
		width: 100%;
		background: black;
		color: white;
	}

	.navbar-nav {
		list-style-type: none;
		margin: 0;
		padding: 0;

		display: flex;
		align-items: center;
		justify-content: space-evenly;
		height: 100%;
	}
</style>
