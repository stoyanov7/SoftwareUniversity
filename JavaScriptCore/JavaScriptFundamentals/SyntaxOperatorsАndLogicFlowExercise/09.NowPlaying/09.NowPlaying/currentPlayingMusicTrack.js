function currentPlayingMusicTrack(arr) {
    let musicTrack = { trackName: arr[0], artistName: arr[1], duration: arr[2] };

    console.log(`Now Playing: ${musicTrack.artistName} - ${musicTrack.trackName} [${musicTrack.duration}]`);
}