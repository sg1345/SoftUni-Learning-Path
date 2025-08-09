//element for general use
const divListEl = document.querySelector("#list");
const inputStockNameEl = document.getElementById("name");
const inputQuantityEl = document.getElementById("quantity");
const inputDateEl = document.getElementById("date");

//elements for events
const orderBtnEl = document.querySelector("#order-btn");
const editOrderBtnEl = document.querySelector("#edit-order");
const loadBtnEl = document.querySelector("#load-orders");

orderBtnEl.addEventListener("click", createOrder);
editOrderBtnEl.addEventListener("click", editOrder);
loadBtnEl.addEventListener("click", loadOrders);

let currentRecordId = '';

async function loadOrders() {
    divListEl.innerHTML = "";

    const recordRes = await fetch("http://localhost:3030/jsonstore/orders/");
    const recordsData = await recordRes.json();
    const objDataArr = Object.values(recordsData);
    console.log(objDataArr);

    for (const record of objDataArr) {
        const containerDivEl = document.createElement("div");
        containerDivEl.classList.add("container");
        containerDivEl.setAttribute("record-id", record._id);

        const h2NameEl = document.createElement("h2");
        h2NameEl.textContent = record.name;

        const h3DateEl = document.createElement("h3");
        h3DateEl.textContent = record.date;

        const h3QuantityEl = document.createElement("h3");
        h3QuantityEl.textContent = record.quantity;

        const changeBtnEl = document.createElement("button");
        changeBtnEl.classList.add("change-btn");
        changeBtnEl.textContent = "Change";
        changeBtnEl.addEventListener("click", changeOrder);

        const doneBtnEl = document.createElement("button");
        doneBtnEl.classList.add("done-btn");
        doneBtnEl.textContent = "Done";
        doneBtnEl.addEventListener("click", deleteOrder);

        containerDivEl.appendChild(h2NameEl);
        containerDivEl.appendChild(h3DateEl);
        containerDivEl.appendChild(h3QuantityEl);
        containerDivEl.appendChild(changeBtnEl);
        containerDivEl.appendChild(doneBtnEl);

        divListEl.appendChild(containerDivEl);

    }

}
async function createOrder(e) {
    e.preventDefault();

    const name = inputStockNameEl.value.trim();
    const quantity = inputQuantityEl.value.trim();
    const date = inputDateEl.value.trim();
    if (!name || !quantity || !date) {
        return;
    }

    await fetch("http://localhost:3030/jsonstore/orders/", {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify({
            name,
            quantity,
            date
        })
    });

    inputStockNameEl.value = "";
    inputQuantityEl.value = "";
    inputDateEl.value = "";

    // await loadOrders();
    loadOrders();
}
async function editOrder(e) {
    e.preventDefault();
    console.log(currentRecordId);


    await fetch(`http://localhost:3030/jsonstore/orders/${currentRecordId}`, {
        method: "PUT",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify({
            name: inputStockNameEl.value.trim(),
            quantity: inputQuantityEl.value.trim(),
            date: inputDateEl.value.trim(),
            _id: currentRecordId
        })
    });

    orderBtnEl.disabled = false;
    editOrderBtnEl.disabled = true;

    inputStockNameEl.value = "";
    inputQuantityEl.value = "";
    inputDateEl.value = "";
    currentRecordId = '';

    loadOrders();
}
async function deleteOrder(e) {
    const currentOrderDivEl = e.target.parentElement;
    const currentRecordId = currentOrderDivEl.getAttribute("record-id");

    await fetch(`http://localhost:3030/jsonstore/orders/${currentRecordId}`, {
        method: "DELETE"
    });

    loadOrders();
}

function changeOrder(e) {
    const currentOrderDivEl = e.target.parentElement;
    console.log(currentOrderDivEl);


    currentRecordId = currentOrderDivEl.getAttribute("record-id");
    console.log(currentRecordId);

    const orderName = currentOrderDivEl.querySelector("h2").textContent;
    const date = currentOrderDivEl.querySelector("h3:nth-child(2)").textContent;
    const quantity = currentOrderDivEl.querySelector("h3:nth-child(3)").textContent;
    console.log(orderName, date, quantity);

    inputStockNameEl.value = orderName;
    inputDateEl.value = date;
    inputQuantityEl.value = quantity;

    currentOrderDivEl.remove();

    orderBtnEl.disabled = true;
    editOrderBtnEl.disabled = false;
}
