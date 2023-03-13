var SpotifyWebApi = require('spotify-web-api-node');

var scopes = ['user-read-private', 'user-read-email','playlist-modify-public'],
  redirectUri = 'https://example.com/callback',
  clientId = '0c8985046bc0483ebc4b6192fffa648d',
  state = 'some-state-of-my-choice';

var spotifyApi = new SpotifyWebApi({
    redirectUri: redirectUri,
    clientId: clientId
});

var authorizeURL = spotifyApi.createAuthorizeURL(scopes, state);

//https://accounts.spotify.com:443/authorize?client_id=5fe01282e44241328a84e7c5cc169165&response_type=code&redirect_uri=https://example.com/callback&scope=user-read-private%20user-read-email&state=some-state-of-my-choice
//Follow this link -> login to your account -> after it redirects you, take the code from the url: https://example.com/callback?code={copy and paste this}
console.log(authorizeURL);


//Uncomment everything else after you've grabbed your code and replace with your code.
//Take the access token it gives you and replace it in index.js
// var code = "your code ";

// spotifyApi.authorizationCodeGrant(code).then(
//     function(data) {
//       console.log('The token expires in ' + data.body['expires_in']);
//       console.log('The access token is ' + data.body['access_token']);
//       console.log('The refresh token is ' + data.body['refresh_token']);
  
//       // Set the access token on the API object to use it in later calls
//       spotifyApi.setAccessToken(data.body['access_token']);
//       spotifyApi.setRefreshToken(data.body['refresh_token']);
//     },
//     function(err) {
//       console.log('Something went wrong!', err);
//     }
//   );


