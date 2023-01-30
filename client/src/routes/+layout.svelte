<script>
	import Themetoggle from '../components/themetoggle/themetoggle.svelte';
	import Footer from '../components/footer/footer.svelte';
	import 'iconify-icon';
</script>

<Themetoggle />
<nav class="tempnav">
	<a href="/loginPage">Login sidan</a>
	<a href="/staff">Personal</a>
	<a href="/">Startsida</a>
	<a href="/profile">profile</a>
</nav>
<slot />
<Footer />
