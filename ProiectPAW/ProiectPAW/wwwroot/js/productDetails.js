var urlParams = new URLSearchParams(window.location.search);
var productId = urlParams.get('id');

if (!productId) {
    document.getElementById('productDetails').innerHTML = '<p>Produsul nu poate fi afisat.</p>';
} else {

    var xhr = new XMLHttpRequest();
    xhr.onreadystatechange = function() {
        if (xhr.readyState === XMLHttpRequest.DONE) {
            if (xhr.status === 200) {
                var productsData = JSON.parse(xhr.responseText);
                var productData = productsData.find(function(product) {
                    return product.id === productId;
                });

                renderProductDetails(productData);
            } else {
                document.getElementById('productDetails').innerHTML = '<p>Eroare la incarcarea datelor produsului.</p>';
            }
        }
    };
    xhr.open('GET', '/Resources/json/flori.json', true); 
    xhr.send();
}

function renderProductDetails(productData) {
    var productName = productData.nume;
    var productImage = productData.images;
    var productPrice = productData.pret;
    var productDescription = productData.descriere;

    var productDetailsHTML = `
                <img src="${productImage}" alt="${productName}">
                <h2>${productName}</h2>
                <p><strong>Preț:</strong> ${productPrice} lei</p>
                <p><strong>Descriere:</strong> ${productDescription}</p>
    `;

    document.getElementById('productDetails').innerHTML = productDetailsHTML;
}