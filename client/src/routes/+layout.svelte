<script>
	import Themetoggle from '../components/themetoggle/themetoggle.svelte';
	import ChatBubble from '../components/chat/chatBubble.svelte';
	import Footer from '../components/footer/footer.svelte';
	import 'iconify-icon';
</script>

<Themetoggle />

<slot />
<ChatBubble />
<Footer />
