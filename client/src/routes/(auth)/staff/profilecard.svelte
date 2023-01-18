<script>
	let teachers = [
		{ id: 'https://thispersondoesnotexist.com/image', name: ' Hasse' },
		{ id: 'https://thispersondoesnotexist.com/image', name: ' Lasse' },
		{ id: 'https://thispersondoesnotexist.com/image', name: ' Karen' },
		{ id: 'https://thispersondoesnotexist.com/image', name: ' Brollan' },
		{ id: 'https://thispersondoesnotexist.com/image', name: ' Birgit' },
		{ id: 'https://thispersondoesnotexist.com/image', name: ' Bosse' }
	];
</script>

<div class="profileCardContainer">
	<div class="profileCard">
		{#each teachers as { id, name }}
			<li>
				<img src={id} alt="Could not load" />
				<div class="overlay">
					<span class="teacherName">{name} </span>
					<div class="teacherInfo">
						I'm the best teacher and the teachers are the best, so i'm the very best of
						the best teachers.
					</div>
				</div>
			</li>
		{/each}
	</div>
</div>

<style lang="less">
	.profileCardContainer {
		display: flex;
		margin: 2rem;
		justify-content: center;
	}
	.profileCard {
		padding: 0.2em;
		display: flex;
		flex-wrap: wrap;
		justify-content: center;
		gap: 2em;
		width: 80vh;
		box-shadow: 10px 5px 3px #12343b;
	}
	.profileCard > li {
		padding: 0.2em;
		list-style: none;
		flex-basis: 400px;
		border: 2px solid black;
		outline: 2px solid white;
		outline-offset: -0.3em;
		position: relative;
		box-shadow: 10px 12px 10px #12343b;
		cursor: pointer;
	}
	.profileCard > li img {
		box-sizing: border-box;
		padding: 0.2em;
		object-fit: cover;
		max-width: 100%;
		height: auto;
		vertical-align: middle;
		border-radius: none;
	}
	// .profileCard::after {
	// 	content: '';
	// 	flex-basis: 450px;
	// }
	.overlay {
		position: absolute;
		width: 100%;
		height: 100%;
		background: rgba(20, 20, 20, 0.502);
		top: 0;
		left: 0;
		box-sizing: border-box;
		padding: 1rem;
		transform: scale(0);
		transition: all 0.5s 0.1s ease-in-out;
		color: #fff;
		display: flex;
		align-items: center;
		justify-content: center;
	}

	.profileCard li:hover .overlay {
		transform: scale(1);
	}
	.teacherName {
		font-weight: 600;
		position: absolute;
		top: 2em;
		text-transform: uppercase;
	}
	.teacherInfo {
		display: -webkit-box;
		-webkit-line-clamp: 1;
		display: flex;
		overflow: hidden;
		color: black;
		background-color: white;
		width: fit-content;
		height: fit-content;
	}
</style>
