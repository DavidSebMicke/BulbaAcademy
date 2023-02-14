<script>
	import Profilecard from './profilecard.svelte';
	import Header from '../../../components/header/header.svelte';
	let teachers = [
		{
			id: 'public/img/Hasse.jfif',
			name: 'Hasse',
			profession: 'Lärare',
			phoneNumber: '070-313 33 33',
			email: 'hasse@bulbaacademy.awesome',
			info: ' " Det bästa är att hela tiden träffa nya människor och att se patienternas framsteg under vårdtiden hos oss. Arbetsuppgifterna är varierande då alla patienterna har olika behov. Jag har kollegor att fråga om råd i kluriga situationer. Det är härligt att känna att det jag gör bidrar till att andra människor får en bättre livskvalité. " ',
			alt: 'A person'
		},
		{
			id: 'public/img/Karen.jfif',
			name: 'Karen',
			profession: 'Rektor',
			phoneNumber: '070-313 33 33',
			email: 'karen@bulbaacademy.awesome',
			info: '" Jag är övergripande ansvarig för all verksamhet på Bulba Academy, såväl våra kärnverksamheter som våra fastigheter. Jag leder vår ledningsgrupp och samarbetar med alla områdeschefer. Jag sitter också i stiftelsens samtliga råd och rapporterar mitt arbete till vår styrelse. "',
			alt: 'A person'
		},
		{
			id: 'public/img/Brollan.jfif',
			name: 'Brollan',
			profession: 'Vaktmästare',
			phoneNumber: '070-313 33 33',
			email: 'brollan@bulbaacademy.awesome',
			info: '" Jag pillar med grejjer som inte fungerar, oftast. "',
			alt: 'A person'
		},
		{
			id: 'public/img/Birgit.jfif',
			name: 'Birgit',
			profession: 'Lärare',
			email: 'birgit@bulbaacademy.awesome',
			phoneNumber: '070-313 33 33',
			info: '" Den dagliga kontakten med våra boende. Att se hur de boende lyser upp på grund av en liten sak, t.ex. att sitta ner för en kaffe och pratstund. Ditt jobb gör verkligen skillnad och jag lär mig nya saker hela tiden. Jag brukar tänka att de boende kan glömma bort ditt namn, men de glömmer aldrig hur du fick dem att känna. "',
			alt: 'A person'
		},
		{
			id: 'public/img/Maja.jfif',
			name: 'Maja',
			profession: 'Lärare',
			phoneNumber: '070-313 33 33',
			email: 'maja@bulbaacademy.awesome',
			info: '" Jag uppskattar mest mötet med många olika människor och att se just individens behov.   Att göra skillnad i vardagen och se den glädje det ger är härligt. Det är en fantastiskt lättarbetad miljö, härlig stämning och att jag jobbar med frihet under ansvar. "',
			alt: 'A person'
		},
		{
			id: 'public/img/Lasse.jfif',
			name: 'Lasse',
			profession: 'Bild',
			email: 'lasse@bulbaacademy.awesome',
			phoneNumber: '070-313 33 33',
			info: '" Det jag uppskattar mest är nog att få arbeta mycket utifrån mig själv för att tillsammans finna vägar framåt. Jobbet kräver en hel del flexibilitet och lyhördhet vilket jag trivs bra med. Fördelen med att jobba på Stora Sköndal är den gemytliga känslan man får på området där olika verksamheter samsas under samma paroll, där jag stolt kan erbjuda olika boendemöjligheter till klienter som ett led till en förbättrad levnadstillvaro. "',
			alt: 'A person'
		},
		{
			id: 'public/img/Magda.jfif',
			name: 'Magda',
			profession: 'Träslöjd',
			email: 'magda@bulbaacademy.awesome',
			phoneNumber: '070-313 33 33',
			info: '" Jag jobbar som Business Controller. Det är en bred roll och jag ansvarar bl.a. för att säkerställa att månadsbokslutet är korrekt samt genomföra månadsuppföljningar med chefer på respektive verksamhetsområde där jag presenterar det ekonomiska utfallet med bl.a. nyckeltal. Utöver detta är jag ett stöd för verksamhetscheferna för att ge dem förutsättningar att förstå och kunna ta det ekonomiska ansvaret. "',
			alt: 'A person'
		},
		{
			id: 'public/img/Bertil.jfif',
			name: 'Bertil',
			phoneNumber: '070-313 33 33',
			email: 'bertil@bulbaacademy.awesome',
			info: '" Att jag känner att jag kan hjälpa de boende med sin omvårdnad och sitt vardagliga liv. Att vara med på aktiviteter med de boende. Jag uppskattar även att jag har så bra kollegor som jag samarbetar med. "',
			profession: 'Kaffe-drickare',
			alt: 'A person'
		}
	];
</script>

<Header title="Vår Personal" />
<Profilecard {teachers} />

<style lang="less">
	.gallery {
		display: grid;
		grid-template-columns: 10% 11% 10% 11% 10% 11% 10% 11%;
		column-gap: 0.2em;
		position: relative;
		background: none;
		padding-left: 10%;
	}
	button {
		border: none;
	}

	.gallery-item {
		text-align: center;
		color: white;
		font-size: 1.2em;
		text-decoration: underline;
		text-decoration-color: rgb(254, 252, 252);
		img {
			border: 2px solid white;

			outline: 2px solid #030303;
		}
		&:hover img {
			border: none;
			outline: 2px solid #f2f5f5;
			outline-offset: -0.08em;
			border-radius: 25%;
			transform: translateY(-0.25em);
			opacity: 1;
			z-index: 99;
			offset: 2;
			scale: 1.5;
		}
	}
	.gallery-item img {
		transition: all 1s;
		opacity: 0.5;
		width: 50%;
		height: auto;
	}
</style>
