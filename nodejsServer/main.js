const WebSocket = require("ws");

const wss = new WebSocket.Server({ port: 8080 }, () => {
  console.log("Listening on port 8080..");
});

wss.on("connection", (ws) => {
  console.log("A client just connected!");
  ws.send("You connected successfully.");
  ws.on("message", (message) => {
    console.log(`Message recieved: ${message}`);
  });

  var data = {
    id: "100",
    name: "Nour",
    willWork: true
  };

  console.log(ws.id);

  ws.on("close", () => {
    console.log("Client disconnected...");
    ws.close();
  });
});

setInterval(() => {
  console.log("Number of clients: " + wss.clients.size);
}, 5000);