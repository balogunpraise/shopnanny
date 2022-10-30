"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/producthub").build();

document.getElementById("hot").disabled = true;

connection.on("UpdateHot", function () {

})