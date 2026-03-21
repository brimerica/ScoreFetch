<script lang="ts">
	import { onMount } from 'svelte';
	import { signalrManager } from '$lib/signalrStore.svelte';

	let { children } = $props();

    onMount(() => {
		signalrManager.start();
	});
</script>

<nav>
    <span>Status: {signalrManager.isConnected ? '🟢 Online' : '🔴 Offline'}</span>
</nav>

{@render children()}

<style>
    nav {
        padding: 1rem;
        background: #f4f4f4;
        border-bottom: 1px solid #ddd;
    }
</style>