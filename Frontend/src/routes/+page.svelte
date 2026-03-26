<script>
    import { signalrManager } from '$lib/signalrStore.svelte';
</script>

<main>
    <h1>Real-Time API Monitor</h1>

    {#if signalrManager.isConnected}
        <div class="data-card">
            <h3>Latest Update from Remote API:</h3>
            <p>{signalrManager.data.games[0].game.away.names.short} {signalrManager.data.games[0].game.away.score}</p>
            <p>{signalrManager.data.games[0].game.home.names.short} {signalrManager.data.games[0].game.home.score}</p>
            <br>
            <h4>{signalrManager.data.games[1].game.away.names.short} {signalrManager.data.games[1].game.away.score}</h4>
            <h4>{signalrManager.data.games[1].game.home.names.short} {signalrManager.data.games[1].game.home.score}</h4>
            <h4>{signalrManager.data.games[1].game.currentPeriod} {signalrManager.data.games[1].game.contestClock}</h4>
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