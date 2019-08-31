setupConnection = () => {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("/brokerhub")
        .build();

    connection.on("ReceiveUpdatedPrice", (update) => {
        const statusDiv = document.getElementById("status");
        statusDiv.innerHTML = update.price;
    });

    connection.on("finished", function () {
        connection.stop();
    });

    connection.start()
        .then(() => {
            setTimeout(() => {
                connection.invoke("GetUpdatedPrice");
            }, 1000);
        })
        .catch(err => console.error(err.toString()));
};

setupConnection();