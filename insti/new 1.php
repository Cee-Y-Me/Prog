<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Database Tables</title>
</head>
<body>

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

// Fetch table names from the database
$sql = "SHOW TABLES";
$result = $conn->query($sql);

if ($result->num_rows > 0) {
    // Output buttons for each table
    while ($row = $result->fetch_assoc()) {
        $tableName = $row["Tables_in_$dbname"];
        echo "<button onclick=\"location.href='table.php?tableName=$tableName'\">$tableName</button><br>";
    }
} else {
    echo "No tables found in the database.";
}

$conn->close();
?>

</body>
</html>
