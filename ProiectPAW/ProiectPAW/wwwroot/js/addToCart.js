function addToCart(productId, quantity) {

    fetch(`/Cart/AddToCart?productId=${productId}&quantity=${quantity}`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        }
    })
        .then(response => {
            if (response.ok) {
                alert('Produsul a fost adaugat in cos.');
            } else {
                alert('Eroare: Produsul nu a putut fi adaugat in cos.');
            }
        })
        .catch(error => {
            console.error('Eroare:', error);
            alert('Eroare: Produsul nu a putut fi adaugat in cos.');
        });
}