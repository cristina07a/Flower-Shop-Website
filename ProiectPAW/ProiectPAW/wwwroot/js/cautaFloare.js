fetch('flowers.json')
  .then(response => response.json())
  .then(data => {
    const flowerData = data.flowerlist;
    
    function searchFlower(event) {
      if (event.key === 'Enter') {
        const searchInput = document.getElementById('searchInput');
        const searchTerm = searchInput.value.toLowerCase();

        const filteredFlowers = flowerData.filter(flower => {
          return flower.name.toLowerCase().includes(searchTerm); 
        });

        renderFlowerCards(filteredFlowers); 
      }
    }

    document.getElementById('searchInput').addEventListener('keypress', searchFlower);
  })
  .catch(error => {
    console.error('Eroare in incarcarea sau parsarea fisierului JSON:', error);
  });