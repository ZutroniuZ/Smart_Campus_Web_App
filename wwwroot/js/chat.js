const connection = new signalR.HubConnectionBuilder()
    .withUrl("/ChatHub")
    .build();

connection.on("ReceiveMessage", (user, message) => {
    const li = document.createElement("li");
    li.textContent = `${user}: ${message}`;
    document.getElementById("messagesList").appendChild(li);
});

document.getElementById("sendButton").addEventListener("click", async () => {
    const message = document.getElementById("messageInput").value;
    await connection.invoke("SendMessage", "User", message);
    document.getElementById("messageInput").value = "";

});

connection.start().catch(err => console.error(err));

