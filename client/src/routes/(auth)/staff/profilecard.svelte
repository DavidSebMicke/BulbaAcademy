<script>
	import ContactCard from './contactCard.svelte';
	import TeacherGallery from './teacherGallery.svelte';
	let backgroundImage =
		'public/img/back-school-background-with-school-supplies-copy-space_23-2148958973.avif';

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
		<button on:click={nextSlide}>
			<div class="arrow2">
				<span />
			</div>
			Next</button
		>
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

		<button class="prevButton" on:click={prevSlide}>
			<div class="arrow">
				<span />
			</div>
			Previous</button
		>
	</div>
</div>
<div class="contactCardElement">
	<ContactCard {teachers} />
</div>

<style lang="less">
	@import 'public/less/global.less';

	.background-images {
		background-image: url('public/img/pencils.jfif');
		background-position: center;
		height: 100vh;
		width: 100%;
		position: relative;
		background-size: cover;
		text-align: -webkit-center;
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
		border-bottom: 5px solid var(--color);
		border-right: 5px solid white;
		transform: rotate(45deg);
	}
	.arrow2 span {
		display: block;
		width: 1.5vw;
		background-color: transparent;
		color: var(--bg-color);
		height: 1.5vw;
		border-bottom: 5px solid var(--color);
		border-right: 5px solid white;
		transform: rotate(45deg);
		margin: -20px;
	}
	.arrow span:nth-child(2) {
		animation-delay: -0.6s;
	}

	.arrow span:nth-child(3) {
		animation-delay: -0.8s;
	}
	.arrow2 span:nth-child(2) {
		animation-delay: -0.2s;
	}

	.arrow2 span:nth-child(3) {
		animation-delay: -1.6s;
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
		margin: 2rem;
		justify-content: center;

		button,
		.prevButton {
			.classic-button;
			color: var(--color);
			align-self: center;
			width: 25%;
			margin: 5px;
			font-weight: 800;
			margin-left: 10%;
			padding: none;

			font-size: 20px;
			transition: all 1s;
			border: 2px solid var(--color);
			border-radius: none;

			&:hover {
				background-color: var(--bg-color);
				color: white;
				transform: translateX(2em);
				border-left: 5px solid #f3f6f4;
				border-top: none;
				border-bottom: none;
				border-right: none;
				font-weight: 800;
				font-size: 20px;
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
			font-size: 20px;
			transform: translateX(-2em);
			border-top: none;
			border-bottom: none;
			border-left: none;
			border-right: 2px solid white;
		}
	}
	.profileCard {
		display: flex;
		margin-left: 10%;
		flex-wrap: wrap;
		justify-content: center;
		width: 80vh;
		background-color: transparent;
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
		border-radius: 50%;
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
		border-radius: 50%;

		background: rgba(20, 20, 20, 0.502);
		top: 0;
		left: 0;
		box-sizing: border-box;
		padding: 1rem;
		transform: scale(0);
		transition: all 0.8s 0.2s ease-in-out;
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
