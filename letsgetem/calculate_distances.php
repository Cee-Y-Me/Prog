<?php
header('Content-Type: application/json');

$request = file_get_contents('php://input');
$data = json_decode($request, true);
$inputAddress = $data['address'];

// Database connection
$servername = "localhost";
$username = "root";
$password = "";
$dbname = "proximity_app";

$conn = new mysqli($servername, $username, $password, $dbname);

if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
}

// Fetch stored addresses
$sql = "SELECT id, address FROM users";
$result = $conn->query($sql);

$userAddresses = [];
while ($row = $result->fetch_assoc()) {
    $userAddresses[] = $row;
}

$conn->close();

// Google Maps API
$apiKey = 'AIzaSyCW4AZFPeKUUe8yDwZvr6PckYdvK_7qBLw';
$distances = [];

foreach ($userAddresses as $user) {
    $url = "https://maps.googleapis.com/maps/api/distancematrix/json?origins=" . urlencode($inputAddress) . "&destinations=" . urlencode($user['address']) . "&key=" . $apiKey;
    $response = file_get_contents($url);
    $data = json_decode($response, true);
    
    $distance = $data['rows'][0]['elements'][0]['distance']['value'] / 1000; // Convert to km
    $distances[] = [
        'userId' => $user['id'],
        'distance' => $distance
    ];
}

// Sort distances in descending order
usort($distances, function($a, $b) {
    return $b['distance'] - $a['distance'];
});

echo json_encode($distances);
?>
