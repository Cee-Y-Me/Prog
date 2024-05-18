<?php
// Replace 'your_database_name', 'your_username', and 'your_password' with your actual database details
$servername = "localhost";
$username = "root";
$password = "";
$dbname = "tut";

// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);

// Check connection
if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
}

// Get the table name from the URL parameter
$tableName = $_GET['tableName'];

// Fetch data from the selected table
$sql = "SELECT * FROM $tableName";
$result = $conn->query($sql);

echo "<h1>$tableName</h1>";

if ($result->num_rows > 0) {
    // Output table data
    echo "<table border='1'><tr>";
    while ($row = $result->fetch_assoc()) {
        foreach ($row as $key => $value) {
            echo "<th>$key</th>";
        }
        break; // Display column names only once
    }
    echo "</tr>";

    // Output table rows
    while ($row = $result->fetch_assoc()) {
        echo "<tr>";
        foreach ($row as $value) {
            echo "<td>$value</td>";
        }
        echo "</tr>";
    }
    echo "</table>";
} else {
    echo "No data found in the table.";
}

$conn->close();
?>
