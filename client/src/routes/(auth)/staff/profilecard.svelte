<script>
	import ContactCard from './contactCard.svelte';
	import TeacherGallery from './teacherGallery.svelte';

	export let teachers;
	let showSpecificTeacher = false;
	let currentIndex = 0;
	let person;

	async function nextSlide() {
		showSpecificTeacher = false;
		if ((currentIndex + 1) % teachers.length === 8) {
			currentIndex = 0;
		}
		currentIndex = (currentIndex + 1) % teachers.length;
	}

	function selectTeacher(event) {
		person = event.detail.Teacher;
		showSpecificTeacher = event.detail.Boolean;
	}

	async function prevSlide() {
		showSpecificTeacher = false;
		console.log((currentIndex - 1) % teachers.length);
		if ((currentIndex - 1) % teachers.length === -1) {
			currentIndex = 8;
		}
		currentIndex = (currentIndex - 1) % teachers.length;
	}
	//Automatically turns to next img after a delay
	setInterval(async () => {
		await nextSlide();
	}, 10000);
</script>

<TeacherGallery {teachers} on:Teacher={selectTeacher} />
<div class="profileCardContainer">
	<button class="prevButton" on:click={prevSlide}>Previous</button>
	<div class="profileCard">
		{#if showSpecificTeacher}
			<li>
				<img src={person.id} alt={person.alt} class="slide" />
				<div class="overlay">
					<h1>{person.name}</h1>
					<h4>( {person.profession} )</h4>
					<div class="teacherInfo">
						{person.info}
					</div>
				</div>
			</li>
		{/if}
		{#if !showSpecificTeacher}
			<li>
				<img
					src={teachers[currentIndex].id}
					alt={teachers[currentIndex].alt}
					class="slide"
				/>
				<div class="overlay">
					<h1>{teachers[currentIndex].name}</h1>
					<h4>( {teachers[currentIndex].profession} )</h4>

					<div class="teacherInfo">
						{teachers[currentIndex].info}
					</div>
				</div>
			</li>
		{/if}
	</div>
	<button on:click={nextSlide}>Next</button>
</div>
<div class="contactCardElement">
	<ContactCard {teachers} />
</div>

<style lang="less">
	@import 'public/less/global.less';

	.profileCardContainer {
		display: flex;
		margin: 2rem;
		justify-content: center;

		button,
		.prevButton {
			padding: 10px 20px;
			background-color: white;
			color: black;
			align-self: center;
			width: 7em;
			font-weight: 700;
			font-family: 'Times New Roman', Times, serif;
			transition: all 1s;
			border: 2px solid rgb(132, 130, 130);

			&:hover {
				background-color: rgb(102, 102, 103);
				color: white;
				transform: translateX(2em);
				border-left: 2px solid #68f689;
			}
		}

		button::after {
			transform: translateX(0);
		}
		.prevButton::after {
			transform: translateX(0);
		}
		.prevButton:hover {
			transform: translateX(-2em);
			font-weight: 800;
			border-left: none;

			border-right: 2px solid #68f689;
		}
	}
	.profileCard {
		padding: 0.2em;
		display: flex;
		flex-wrap: wrap;
		justify-content: center;
		gap: 2em;
		width: 80vh;
	}
	.profileCard > li {
		text-align: center;
		padding: 0.2em;
		color: #2d545e;
		list-style: none;
		flex-basis: 800px;
		position: relative;
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
	.profileCard::after {
		content: '';
		flex-basis: 8 50px;
	}
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
		transition: all 0.5s 0.2s ease-in-out;
		display: flex;
		align-items: center;
		justify-content: center;

		h1 {
			text-shadow: 1px 1px rgb(165, 163, 163);
			position: absolute;
			color: white;
			top: 0;
		}
		h4 {
			position: absolute;
			color: white;
			font-weight: 400;
			top: 3rem;
		}
	}

	.profileCard li:hover .overlay {
		transform: scale(1);
		offset: 4px solid rgb(224, 36, 36);
		outline-offset: 2px;
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
		color: white;
		overflow-wrap: break-all;
		width: fit-content;
		height: fit-content;
	}
	.contactCardElement {
		text-align: center;
	}
</style>
