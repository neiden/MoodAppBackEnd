var sentimentScore;

async function analyzeSentiment(){
    // Imports the Google Cloud client library
    const language = require('@google-cloud/language');

    // Creates a client
    const client = new language.LanguageServiceClient();
    const text = document.getElementById("userInput");

    const output = document.getElementById("output");
    output.innerHTML = text;

    // // Prepares a document, representing the provided text
    // const document = {
    // content: text,
    // type: 'PLAIN_TEXT',
    // };

    // // Detects the sentiment of the document
    // const [result] = await client.analyzeSentiment({document});

    // const sentiment = result.documentSentiment;
    // sentimentScore = sentiment.score;
    // console.log('Document sentiment:');
    // console.log(`  Score: ${sentiment.score}`);
    // console.log(`  Magnitude: ${sentiment.magnitude}`);

}





// //SERVER
// //Load HTTP module
// const http = require("http");
// const hostname = "127.0.0.1";
// const port = 3000;

// //Create HTTP server and listen on port 3000 for requests
// const server = http.createServer((req, res) => {
//   //Set the response HTTP header with HTTP status and Content type
//   res.statusCode = 200;
//   res.setHeader("Content-Type", "text/plain");
//   analyzeSentiment();
//   res.end("Entered text: " + inputText + "\nSentiment score: " + sentimentScore);
// });

// //listen for request on port 3000, and as a callback function have the port listened on logged
// server.listen(port, hostname, () => {
//   console.log(`Server running at http://${hostname}:${port}/`);
// });
