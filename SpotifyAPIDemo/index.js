var SpotifyWebApi = require('spotify-web-api-node');


var credentials = {
    clientId: '0c8985046bc0483ebc4b6192fffa648d',
    clientSecret: 'bc3019aa224d49dcad001b9fd074d886',
    redirectUri: 'https://example.com/callback'
  };
  
var spotifyApi = new SpotifyWebApi(credentials);

//!!replace with your own access token created in authentication.js
spotifyApi.setAccessToken("BQCCFz-_elP6EQzsuFF4G3qzlEZPZTRUYBb-mHET3p7T1u5EdwVVIWNb96zBlMdpypDP8ffXJPUaOBRZosDcMojSkL4qDe71nOcX9VPq3FmthqxjCYe6sHBC2_iei7ILhrXpTiRQ-CPbd6TksF1VdngmnNzbHwkq_qwY2xp0t2iBq-YYSORZqecS9v4jgnxEgVfJE04ErzDkZwtBMSxXB9M0Sho-");

// (async () => {
//     const me = await spotifyApi.getMe();
//     console.log(me);
//   })().catch(e => {
//     console.error(e);
//   });

//   (async () => {
//     const me = await spotifyApi.searchTracks('genre:rap', {limit : 10, offset: 2});
//     console.log(me.body.tracks);
//   })().catch(e => {
//     console.error(e);
//   });

async function getTracksByGenre(genre){
  const me = await spotifyApi.searchTracks('genre:rap', {limit : 10, offset: 2});
  console.log(me.body.tracks);
  return me.body.tracks;
}

 
async function createPlaylist(){
  const me = await spotifyApi.createPlaylist('Test playlist', { 'description': 'My description', 'public': true });
  console.log(me.body.tracks);
}

  // (async () => {
  //   const me = await spotifyApi.createPlaylist('Test playlist', { 'description': 'My description', 'public': true });
  //   console.log(me.body.tracks);
  // })().catch(e => {
  //   console.error(e);
  // });
  
