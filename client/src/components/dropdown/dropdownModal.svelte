<script>
	import ClickOutside from '../../Utils/ClickOutside';
	// const modal = document.querySelector('.modal');
	// const overlay = document.querySelector('.overlay');
	// const openModalBtn = document.querySelector('.btn-open');
	// const closeModalBtn = document.querySelector('.btn-close');

	export let showModal = false;
</script>

<section class="modal" />
<!-- <div class="overlay hidden" /> -->
<button class="btn btn-open">Open Modal</button>

<section class="modal" use:ClickOutside on:click_outside={() => (showModal = false)}>
	<div class="flex">
		<button class="btn-close" on:click={() => (showModal = false)}>⨉</button>
	</div>
	<div class="container">
		<div class="modalitem">
			<div class="modalsubitem marginbottom">
				<div>
					<h3>Ändra lösenord</h3>
					<p>Fyll i din epostadress för att ändra lösenord.</p>
				</div>

				<input type="email" id="email" placeholder="brendaneich@js.com" />
				<button class="btn">Bekräfta</button>
			</div>

			<div class="modalsubitem">
				<div>
					<h3>Ändra epostadress</h3>
					<p>Fyll i din nya epostadress för att ändra.</p>
				</div>
				<input type="email" id="email" placeholder="brendaneich@js.com" />
				<button class="btn">Bekräfta</button>
			</div>
		</div>

		<div class="modalitem">
			<div>
				<h3>Ändra epostadress</h3>
				<p>Skriv in din nya gatuadress för att ändra.</p>
			</div>
			<input type="address" id="address" placeholder="Bulbagatan 4" />
			<input type="postalno" id="postalno" placeholder="444 44" />
			<input type="postaladd" id="postaladd" placeholder="Göteborg" />
			<button class="btn">Bekräfta</button>
		</div>
	</div>
</section>

<!-- <div class="overlay hidden" /> -->
<style lang="less">
	@import 'public\less\variables.less';
	@import 'public\less\global.less';
	@import url('https://fonts.googleapis.com/css2?family=Inter&display=swap');
	@import url('https://fonts.googleapis.com/css2?family=Poiret+One&display=swap');

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
		width: fit-content;
		min-height: 250px;
		background-color: white;
		border: 1px solid #ddd;
		border-radius: 15px;
		position: absolute;
		top: 50%;
		left: 50%;
		margin-right: -50%;
		transform: translate(-50%, -50%);
		box-shadow: 5px 5px 3px rgba(0, 0, 0, 0.475);
	}

	.container {
		display: grid;
		grid-template-columns: 1fr 1fr;
		flex-direction: row;
		justify-content: center;
		gap: 2rem;
		padding: 0 1.7rem 2.5rem 1.7rem;
	}

	.modalitem {
		display: flex;
		flex-direction: column;
		gap: 0.7rem;
	}

	.marginbottom {
		margin-bottom: 40px;
	}

	.modalsubitem {
		display: flex;
		flex-direction: column;
		gap: 0.5rem;
	}

	.modal .flex {
		align-self: end;
		width: fit-content;
		position: relative;
		top: 10px;
		right: 10px;
		// margin-top: 10px;
		// margin-right: 10px;
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
		padding: 0.5rem 0.7rem;
		background: #eee;
		border-radius: 50%;
	}

	// .overlay {
	// 	position: fixed;
	// 	top: 0;
	// 	bottom: 0;
	// 	left: 0;
	// 	right: 0;
	// 	width: 100%;
	// 	height: 100%;
	// 	background: rgba(0, 0, 0, 0.5);
	// 	backdrop-filter: blur(3px);
	// 	z-index: 1;
	// }

	.modal {
		z-index: 2;
	}

	.hidden {
		display: none;
	}
</style>
