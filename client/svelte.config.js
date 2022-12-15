import adapter from '@sveltejs/adapter-static';
import sveltePreprocess from 'svelte-preprocess';
// import { dirname, join } from 'path';
// import { fileURLToPath } from 'url';

// const __dirname = dirname(fileURLToPath(import.meta.url));

/** @type {import('@sveltejs/kit').Config} */
const config = {
	kit: {
		adapter: adapter({
			//fallback: 'home.html'
		})
	},
	preprocess: sveltePreprocess({
		// Import global less file later
		//prependData: `@import '${join(__dirname, 'src/to/variable.less').replace(/\\/g, '/')}';`
	})
};

export default config;
