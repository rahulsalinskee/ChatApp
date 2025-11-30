"use strict"

//const { signalR } = require("../lib/signalr/dist/browser/signalr")

var connection = new signalR.HubConnectionBuilder().withUrl("/notificationHub").build();

connection.start().then(() => console.log("SignalR Connected")).catch(error => console.error("SignalR Connection Error: ", error));

connection.on("ReceiveServerNotification", function (message) {
    //var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    //var encodedMsg = user + " says " + msg;

    console.log("Received message:", message); // Debug log

    var li = document.createElement("li");
    li.textContent = message;
    document.getElementById("message-list").appendChild(li);
});