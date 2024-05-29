fetch('/Resources/json/flori.json')
    .then(response => response.json())
    .then(data => {
        console.log(data);  
        data.forEach(buchet => {
           
                const buchetElement = document.createElement('div');
                buchetElement.classList.add('col-sm-4');

                
                const imagineElement = document.createElement('img');
                imagineElement.src = buchet.images;
                imagineElement.alt = buchet.pret; 

                buchetElement.appendChild(imagineElement);

                const pretElement = document.createElement('p');
                pretElement.textContent = buchet.pret + ' RON';
                buchetElement.appendChild(pretElement);

                document.getElementById('bucheteContainer').appendChild(buchetElement);

                imagineElement.addEventListener('click', function() {
                    window.location.href = buchet.pagina_html; 
                });
        });
    })
    .catch(error => console.error('Eroare la încărcarea fișierului JSON:', error));
