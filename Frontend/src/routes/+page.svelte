<script>
    import { signalrManager } from '$lib/signalrStore.svelte';

    //console.log("SignalR Manager State:", signalrManager);
</script>

<main>
    <h1>Real-Time API Monitor</h1>

    {#if signalrManager.isConnected}
        <div class="data-card">
            <h3>Latest Update from Remote API:</h3>
            {#each signalrManager.data.games as game, index}
                <div>
                    <h4>Game {index + 1}: {game.game.startDate} {game.game.startTime}</h4>
                    <p>{game.game.away.names.short} {game.game.away.score}</p>
                    <p>{game.game.home.names.short} {game.game.home.score}</p>
                    <p>Period: {game.game.currentPeriod} | Clock: {game.game.contestClock}</p>
                </div>
                <hr>
            {/each}
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