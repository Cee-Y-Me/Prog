<?php
// Database connection details
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

// Retrieve login details from POST request
$loginEmail = $_POST['loginEmail'];
$loginPassword = $_POST['loginPassword'];

// Query to check if the user exists with the given email and password
$sql = "SELECT * FROM users WHERE email='$loginEmail' AND password='$loginPassword'";
$result = $conn->query($sql);

if ($result->num_rows > 0) {
    // User exists, so login is successful
    echo "success";
} else {
    // User does not exist or credentials are incorrect
    echo "failure";
}

// Close connection
$conn->close();
?>
