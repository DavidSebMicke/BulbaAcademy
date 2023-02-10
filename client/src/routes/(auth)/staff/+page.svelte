<script>
	import Profilecard from './profilecard.svelte';
	import Header from '../../../components/header/header.svelte';
	let teachers = [
		{
			id: 'public/img/Hasse.jfif',
			name: 'Hasse',
			profession: 'Teacher',
			phoneNumber: '070-313 33 33',
			email: 'hasse@bulbaacademy.awesome',
			info: 'Serving at Grace Lutheran School since 1996 When I was in the 6th grade my mother asked me what I wanted to be when I grew up. The answer I gave her was A teacher. I believe that the Holy Spirit put that idea into my heart and mind. To become a teacher was my goal from 6th grade on. I love working with the children, seeing the light click on when a difficult concept is understood, helping them to live their faith, watching them being confirmed in that faith, and seeing them grow into adulthood. I love developing a rapport with my students and having fun with them. It is my goal to make their learning an enjoyable experience and serve them in any way that I can. They give me so much in return. Of all the schools I have served, Grace is at the top. Grace is committed to providing an excellent education for it’s students, as well as providing it’s teaching staff opportunities to further their education. The staff at Grace is a dedicated group of Christians who put the welfare of each student at priority number one. Christian love and concern is evident every day when dealing with students and each other. I love being a part of Grace.',
			alt: 'A person'
		},
		{
			id: 'public/img/Karen.jfif',
			name: 'Karen',
			profession: 'Headmaster',
			phoneNumber: '070-313 33 33',
			email: 'karen@bulbaacademy.awesome',
			info: 'Serving at Grace Lutheran School since 1984. Karen graduated from Martin Luther College in New Ulm, MN in May of 1999 with a Bachelor of Science Degree in Education. He was assigned to Atonement Lutheran School in Baltimore, MD where he served as the lead teacher for grades 4 – 8 and the school co-administrator. In 2001, Mr. Walker accepted a call to serve as the 5th and 6th-grade teacher at Faith Lutheran in Milwaukee, WI. Mr. Walker was asked to accept the position of Principal of Faith Lutheran in Milwaukee in the spring of 2003. He served in this capacity until 2005 when Reformation Lutheran School in San Diego, CA called him to serve as their principal. Mr. Walker earned a Master of Arts degree in Curriculum and Instruction from Concordia University, Irvine in the spring of 2012. In 2013, he accepted a call to serve as the full-time principal of Apostles Lutheran School in San Jose, CA. He served in this position until 2018 when he began his work at Grace Lutheran School.',
			alt: 'A person'
		},
		{
			id: 'public/img/Brollan.jfif',
			name: 'Brollan',
			profession: 'Janitor',
			phoneNumber: '070-313 33 33',
			email: 'brollan@bulbaacademy.awesome',
			info: 'I do a lot of stuff',
			alt: 'A person'
		},
		{
			id: 'public/img/Birgit.jfif',
			name: 'Birgit',
			profession: 'Teacher',
			email: 'birgit@bulbaacademy.awesome',
			phoneNumber: '070-313 33 33',
			info: 'Serving at Grace Lutheran School since 2001.   There is nothing more exciting to me than seeing the “light bulb” effect as a child learns and understands something new. Watching this “effect” each day is exhilarating. Here at Grace Lutheran School, I have the awesome privilege of watching students grow in their faith, which surpasses any other teaching experience. I am honored to be a part of the faculty at Grace. Together we are strongly committed to our high academic achievement standard and leading our students in their spiritual walk with Christ.',
			alt: 'A person'
		},
		{
			id: 'public/img/Maja.jfif',
			name: 'Maja',
			profession: 'Teacher',
			phoneNumber: '070-313 33 33',
			email: 'maja@bulbaacademy.awesome',
			info: 'Serving at Grace Lutheran School since 2018. My path to teaching started with my mom, who bravely homeschooled my sisters and me for 5 years of grade school. We didn’t have as many resources a a “real” school, but during that time I learned to love my Savior and to love learning. Years later, I chose to become a teacher because I saw how much my mom loves teaching. I was glad to find out that I love it too! During my college years, I was blessed with various classroom experiences with every grade from K-8. This let me see firsthand the personal and academic development I studied in my education courses. I’ve been teaching at Grace ever since I graduated. I love putting my studies into practice and learning alongside my kindergarteners. Through my teaching, I hope to give them a love of learning and encourage their love for Jesus. Watching the children grow in their faith and academics throughout their years at Grace is rewarding. Working together with a talented group of fellow teachers is a blessing. My favorite part about teaching is that each new day is unique with its own set of challenges and blessings. What better way to serve God every day.',
			alt: 'A person'
		},
		{
			id: 'public/img/Lasse.jfif',
			name: 'Lasse',
			profession: 'Arts & Craft',
			email: 'lasse@bulbaacademy.awesome',
			phoneNumber: '070-313 33 33',
			info: 'Serving at Grace Lutheran School since 2013. My love for learning has led me to be a teacher. Teachers do more than just teach, and our impact extends far beyond the classroom. Besides being a classroom teacher, I am also the coach of Grace’s robotics team and we take part in the international FIRST LEGO League annually. It is wonderful to see how the students use their God-given talents to build and program a robot and then to take part in competitions with other teams. As a teacher, I am more than just an educator: I am a mentor, a confidant and a friend. With God’s help I want to make a difference in the lives of as many students as I can.',
			alt: 'A person'
		},
		{
			id: 'public/img/Magda.jfif',
			name: 'Magda',
			profession: 'Woodcraft',
			email: 'magda@bulbaacademy.awesome',
			phoneNumber: '070-313 33 33',
			info: 'Serving at Grace Lutheran School since 2003. I was born and raised in a small town in southern Minnesota. I graduated from Dr. Martin Luther College in 1993 with a Bachelor of Science degree in elementary education. I co-taught preschool/kindergarten for a year in Niles, IL. In 1994, I was called to teach 4th grade at Grace Lutheran School in Glendale, AZ. I taught for six years before I resigned to be a stay-at-home mom. God blessed my husband and me with three beautiful daughters. I returned to teaching in 2007 at Grace, but this time in the preschool. I fell in love with this age level and have continued my education with many classes and workshops geared toward early childhood education. I became the preschool director in 2018 and still teach the 4-year-olds.',
			alt: 'A person'
		},
		{
			id: 'public/img/Bertil.jfif',
			name: 'Bertil',
			phoneNumber: '070-313 33 33',
			email: 'bertil@bulbaacademy.awesome',
			info: 'Serving at Grace since 2015. Pastor Jacobson was born in Milwaukee, Wisconsin. His decision to enter the ministry was influenced by two factors: His years in confirmation class and the influence of his older brother Andrew, a pre-ministerial student who was called home to heaven at the age of 20. Pastor Jacobson is married to Amy and they have four children. During his ministry, Pastor Jacobson has served as an associate pastor at Redeemer Lutheran Church in Tucson from 2004 through 2009. He then served as mission pastor to Redeemer’s daughter congregation, Dove Mountain Lutheran Church, from 2010 through 2014. He enjoys participating in many different outdoor activities with his wife and children. Occasionally he has served as a referee for youth football and basketball games. It’s a joy for him to help people see Jesus as their Savior from sin and their friend in life.',
			profession: 'Coffe-drinker',
			alt: 'A person'
		}
	];
</script>

<Header title="The Staff" />
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
