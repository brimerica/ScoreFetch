<script>
    import { signalrManager } from '$lib/signalrStore.svelte';
</script>

<main>
    <h1>Real-Time API Monitor</h1>

    {#if signalrManager.isConnected}
        <div class="data-card">
            <h3>Latest Update from Remote API:</h3>
            <p>{signalrManager.data}</p>
        </div>
    {:else}
        <p>Attempting to connect to backend...</p>
    {/if}
</main>

<style>
    .data-card {
        border: 2px solid #ff3e00;
        padding: 2rem;
        border-radius: 8px;
        background-color: #fffaf9;
        font-family: monospace;
    }
</style>

<h1>Welcome to SvelteKit</h1>
<p>Visit <a href="https://svelte.dev/docs/kit">svelte.dev/docs/kit</a> to read the documentation</p>
