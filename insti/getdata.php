<?php
$servername = "localhost";
$username = "root";
$password = "";
$dbname = "tut";

// Establish a connection to the database
$mysqli = new mysqli($servername, $username, $password, $dbname);

// Check the connection
if ($mysqli->connect_error) {
    die("Connection failed: " . $mysqli->connect_error);
}

// Get the table name from the request
$tableName = $_GET['table'];

// Assuming each table has columns 'id', 'name', and 'description'
$query = "SELECT Programme FROM $tableName"; // Adjust the query based on your table structure

$result = $mysqli->query($query);

if ($result) {
    $data = array();

    // Fetch all rows
    while ($row = $result->fetch_assoc()) {
        $data[] = $row;
    }

    // Return data as JSON
    header('Content-Type: application/json');
    echo json_encode(['info' => $data]); // Adjust this based on your table structure

    $result->free(); // Free the result set
} else {
    // Handle the case when the query fails
    http_response_code(500);
    echo json_encode(['error' => 'Failed to fetch data: ' . $mysqli->error]); // Include error information
}

// Close the database connection
$mysqli->close();
?>
