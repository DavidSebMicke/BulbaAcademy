<script>
	function handleClick() {
		alert('Du är inloggad');
	}
</script>

<div class="griden">
	<div id="step1">Logga in i Bulba Academy</div>

	<div class="step2">
		<p>Användarnamn<br /><input value="" /></p>
		<p>
			Lösenord<br /><input value="" />
			<br /><br />

			<button id="step3" on:click={handleClick}>
				<h1>Logga in</h1>
			</button>
		</p>
	</div>

	<img class="bulben" src="public\img\bulbi.jpg" alt="gfdkl" />
</div>

<style lang="less">
	@import 'public\less\variables.less';
	@import 'public\less\global.less';
	@import url('https://fonts.googleapis.com/css2?family=Poiret+One&display=swap');
	@import url('https://fonts.googleapis.com/css2?family=Plus+Jakarta+Sans&display=swap');
	@import url('https://fonts.googleapis.com/css2?family=Inter&display=swap');

	.body {
		font-family: 'Poiret One', cursive;
		font-family: 'Plus Jakarta Sans', sans-serif;
		font-family: 'Inter', sans-serif;
	}
	.griden {
		display: grid;
		grid-template-columns: 1fr 1fr;
	}

	#step1 {
		position: absolute;
		width: 724px;
		height: 88px;
		left: 128px;
		top: 90px;

		font-family: 'Poiret One';
		font-style: normal;
		font-weight: 600;
		font-size: 40px;
		line-height: 75px;
		display: grid;

		align-items: center;
		letter-spacing: 0.04em;

		color: #000000;

		//border: 1px solid #000000;
		//text-shadow: 0px 4px 4px rgba(0, 0, 0, 0.25);
	}

	.step2 {
		position: absolute;
		width: 236px;
		height: 39px;
		left: 128px;
		top: 200px;

		font-family: 'Plus Jakarta Sans';
		font-style: normal;
		font-weight: 500;
		font-size: 18px;
		line-height: 25px;
		display: grid;
		align-items: center;
		letter-spacing: 0.04em;

		color: #000000;
	}

	#step3 {
		position: relative;
		width: 333px;
		height: 50px;
		position: absolute;
		background-color: blue;
		display: grid;
		top: 200px;

		font-family: 'Inter';
		font-style: normal;
		font-weight: 500;
		font-size: 10px;
		line-height: 5px;
		display: grid;
		align-items: center;
		text-align: center;
		color: #ffffff;
	}

	.bulben {
		box-sizing: border-box;

		display: grid;
		position: absolute;
		width: 237.61px;
		height: 250.18px;
		left: 50rem;
		top: 10rem;
	}
</style>
