

var cart = [];

function addToCart(name, price, image) {
    cart.push({ name: name, price: price, image: image });
    alert(name + " sepete eklendi.");
    updateCartCount();
}

function updateCartCount() {
    document.getElementById("cartCount").innerText = cart.length;
}

function displayCart() {
    var cartItems = document.getElementById("cartItems");
    cartItems.innerHTML = "";
    var totalPrice = 0;
    cart.forEach(function (item, index) {
        var div = document.createElement("div");
        div.className = "cart-item";
        div.innerHTML = `<img src="${item.image}" alt="${item.name}"> <span>${item.name} - $${item.price}</span> <button onclick="removeFromCart(${index})" class="btn btn-danger btn-sm">Sil</button>`;
        cartItems.appendChild(div);
        totalPrice += item.price;
    });
    var totalDiv = document.createElement("div");
    totalDiv.className = "total-price";
    totalDiv.innerText = "Toplam Fiyat: $" + totalPrice;
    cartItems.appendChild(totalDiv);
}

function removeFromCart(index) {
    cart.splice(index, 1);
    displayCart();
    updateCartCount();
}