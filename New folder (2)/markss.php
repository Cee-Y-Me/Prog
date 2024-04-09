<?php
// Replace with your actual database credentials
$servername = "localhost";
$username = "root";
$password = "";
$dbname = "userres";

// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);

// Check connection
if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
}

$tableName = $_GET['tableName'];
// Process form submission
if ($_SERVER["REQUEST_METHOD"] == "POST") {
    // Decode JSON data
    $jsonData = json_decode(file_get_contents("php://input"), true);

    // Assuming the data array has the same length as the number of dropdowns
    foreach ($jsonData["data"] as $item) {
        $subject = $conn->real_escape_string($item["subject"]);
        $marks = $conn->real_escape_string($item["marks"]);

        // Insert data into the database
        $sql = "INSERT INTO '$tableName' (subject, marks) VALUES ('$subject', $marks)";

        if ($conn->query($sql) !== TRUE) {
            echo "Error: " . $sql . "<br>" . $conn->error;
        } else {
            echo "Data inserted successfully";
        }
    }
}

// Close connection
$conn->close();
?>


