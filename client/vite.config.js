import { sveltekit } from '@sveltejs/kit/vite';
import { svelte } from '@sveltejs/vite-plugin-svelte'
import path from 'path'

/** @type {import('vite').UserConfig} */
const config = {
    plugins: [sveltekit()], 
    resolve: {
        alias: {
          $root: path.resolve('./src'),
        },
    },
    server: {
      fs: {
        // Allow serving files from one level up to the project root
        allow: ['..'],


        },
      },
    }

export default config;

