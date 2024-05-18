<?php

// Database configuration
$databaseServer = "localhost";
$databaseUsername = "root";
$databasePassword = "";

// Validate institution parameter
$institution = $_GET['institution'] ?? ''; // Use default value if parameter is not set

if(empty($institution)) {
    die("No institution provided.");
}

// Create connection
$conn = new mysqli($databaseServer, $databaseUsername, $databasePassword);

// Check connection
if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
}

// Validate and sanitize institution name to prevent SQL injection
$institution = $conn->real_escape_string($institution);

// Fetch tables for the specified institution
$sql = "SHOW TABLES FROM $institution";
$result = $conn->query($sql);

$tables = array();

if ($result) {
    while ($row = $result->fetch_assoc()) {
        $tables[] = $row["Tables_in_$institution"];
    }
} else {
    die("Error fetching tables: " . $conn->error);
}

// Close the connection
$conn->close();

// Return the tables as JSON
echo json_encode(['tables' => $tables]);
?>

