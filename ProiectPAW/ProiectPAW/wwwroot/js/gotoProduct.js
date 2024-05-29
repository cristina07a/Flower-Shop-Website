document.addEventListener("DOMContentLoaded", function() {
    var productLinks = document.querySelectorAll('.product-link');
    productLinks.forEach(function(link) {
        link.addEventListener('click', function(event) {
            event.preventDefault(); 
            var page = link.dataset.page; 
            window.location.href = page; 
        });
    });
});