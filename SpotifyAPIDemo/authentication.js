
function Authenticate(){
    var SpotifyWebApi = require('spotify-web-api-node');
    
    var scopes = ['user-read-private', 'user-read-email','playlist-modify-public'],
      redirectUri = 'http://localhost:4200/home',
      clientId = '0c8985046bc0483ebc4b6192fffa648d',
      clientSecret = 'bc3019aa224d49dcad001b9fd074d886',
      state = 'some-state-of-my-choice';
    
    var spotifyApi = new SpotifyWebApi({
        redirectUri: redirectUri,
        clientId: clientId,
        clientSecret: clientSecret
    });
    
    var authorizeURL = spotifyApi.createAuthorizeURL(scopes, state);
    
    //https://accounts.spotify.com:443/authorize?client_id=5fe01282e44241328a84e7c5cc169165&response_type=code&redirect_uri=https://example.com/callback&scope=user-read-private%20user-read-email&state=some-state-of-my-choice
    //Follow this link -> login to your account -> after it redirects you, take the code from the url: https://example.com/callback?code={copy and paste this}
    console.log(authorizeURL);
    
    
    //Uncomment everything else after you've grabbed your code and replace with your code.
    //Take the access token it gives you and replace it in index.js
    // var code = "AQBaiAd541GV58u3sjj3F_kMO3ERafgdOnV7ZoRLmaVfexJgSmciHGf1fQjNmTy1tAgR47jb3Mxp2K-ya1X-0TtxvfTgt2lwh99FMvQt_ODi9p3HLiaFsctYVbi-KqK52XIydosIR4zoCeGBOUmDHxvihzMV9ulYTTXityeR19oA9FcWpByyP0-mfAuVeBpx-LoI6BsJfZ2ufH33Omr--T-_JzJHZolkdh1H0KbGPWEezJaIbqUhWCzUJRc";
    
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

}



