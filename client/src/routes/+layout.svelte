<script>
	import Themetoggle from '../components/themetoggle/themetoggle.svelte';
	import Footer from '../components/footer/footer.svelte';
	import 'iconify-icon';
	import { onMount } from 'svelte';
	import { CheckUserData } from '../app';



</script>

<Themetoggle />

<slot />
<Footer />
