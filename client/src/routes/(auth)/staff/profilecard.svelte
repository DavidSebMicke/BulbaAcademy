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
	<div class="background-images">
		<button class="prevButton" on:click={prevSlide}
			>Föregående
			<div class="arrow">
				<span />
			</div>
		</button>
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
		<button on:click={nextSlide}>
			Nästa
			<div class="arrow2">
				<span />
			</div>
		</button>
	</div>
</div>
<div class="contactCardElement">
	<ContactCard {teachers} />
</div>

<style lang="less">
	@import 'public/less/global.less';

	.background-images {
		display: flex;
		background-image: url('public/img/manyBooks.avif');
		position: relative;
		align-self: normal;
		flex: auto;
		margin-right: 0;
		scale: 0.8;
		background-size: cover;
	}
	.arrow {
		position: relative;
		transform: rotate(90deg);
		cursor: pointer;
		float: left;
	}

	.arrow2 {
		position: relative;
		transform: rotate(-90deg);
		cursor: pointer;
		float: right;
	}

	.arrow span {
		display: block;
		width: 1.5vw;
		background-color: transparent;
		color: var(--bg-color);
		height: 1.5vw;
		border-bottom: 7px solid var(--color);
		border-right: 7px solid white;
		transform: rotate(45deg);
	}
	.arrow2 span {
		display: block;
		width: 1.5vw;
		background-color: transparent;
		color: var(--bg-color);
		height: 1.5vw;
		border-bottom: 7px solid var(--color);
		border-right: 7px solid white;
		transform: rotate(45deg);
	}
	@keyframes animate {
		0% {
			opacity: 0;
			transform: rotate(45deg) translate(-20px, -20px);
		}
		50% {
			opacity: 1;
		}
		100% {
			opacity: 0;
			transform: rotate(45deg) translate(20px, 20px);
		}
	}
	.profileCardContainer {
		display: flex;
		button,
		.prevButton {
			.classic-button;
			padding: 10px 20px;
			font-size: 10px;
			border-radius: 5px;
			transition: all 0.5s ease-in-out;
			color: var(--color);
			width: 25%;
			top: 45%;
			position: relative;
			border-left: none !important;
			border-right: none !important;
			font-weight: 800;
			height: 10%;
			font-size: 20px;
			border: 1px solid var(--color);

			&:hover {
				background-color: transparent !important;
				color: white !important;
				transform: translateX(1.5em);
				font-weight: 800;
				font-size: 40px;
				text-shadow: 2px 2px black;
				border-right: none !important ;
			border-left: none !important;
			border-top: none !important;
			border-bottom: 10px solid !important;

			}
			&:hover .arrow2 span {
				display: none;
			}
		}

		button::after {
			transform: translateX(0);
		}
		.prevButton::after {
			transform: translateX(0);
		}
		.prevButton:hover {
			font-weight: 800;
			font-size: 40px;
			text-shadow: 2px 2px solid white;
			transform: translateX(-1.5em);
			
			
		}
		.prevButton:hover .arrow span {
		display: none;

	}
	}
	

	.profileCard > li {
		padding: 0.2em;
		color: #2d545e;
		list-style: none;
		position: relative;
		width: fit-content;
		outline: 1em solid;
        outline-color: var(--bg-color);
        outline-offset: -4px;
		cursor: pointer;
	}
	.profileCard > li img {
		object-fit: cover;
		max-width: 100%;
		height: auto;
		vertical-align: middle;
		border-radius: none;
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
		transition: all 0.8s 0.2s ease-in-out;
		display: flex;
		align-items: flex-end;
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
		display: flex;
		color: white;
		font-size: 1.25em;
		word-break: break-word;
    font-family: 'Inter';
    font-size: x-large;

	}
	.contactCardElement {
		display: grid;
  justify-items: center; 
  align-items: center; 
  text-align: center;
  margin-bottom: 5em;
  padding: 1em;
	}
</style>
