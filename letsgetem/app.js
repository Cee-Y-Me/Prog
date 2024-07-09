document.getElementById('proximityForm').addEventListener('submit', function(event) {
    event.preventDefault();
    const address = document.getElementById('address').value;
    
    fetch('calculate_distances.php', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ address: address })
    })
    .then(response => response.json())
    .then(data => {
        displayResults(data);
    })
    .catch(error => {
        console.error('Error:', error);
    });
});

function displayResults(data) {
    const resultsDiv = document.getElementById('results');
    resultsDiv.innerHTML = '<h2>Results:</h2>';
    
    const list = document.createElement('ul');
    data.forEach(item => {
        const listItem = document.createElement('li');
        listItem.textContent = `UserID: ${item.userId}, Distance: ${item.distance} km`;
        list.appendChild(listItem);
    });
    
    resultsDiv.appendChild(list);
}
