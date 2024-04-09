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

// Retrieve form data from POST request
$name = $_POST['name'];
$surname = $_POST['surname'];
$idNumber = $_POST['idNumber'];
$email = $_POST['email'];
$phoneNumber = $_POST['phoneNumber'];
$password = $_POST['password']; // Note: You should hash the password before storing it in the database for security

// SQL query to insert user data into the database
$sql = "INSERT INTO users (name, surname, id_number, email, phonenumber, password) 
        VALUES ('$name', '$surname', '$idNumber', '$email', '$phoneNumber', '$password')";

if ($conn->query($sql) === TRUE) {
    echo "New record created successfully";

    // Create a table for the user
    $tableName = $name . '_' . $surname . '_' . $idNumber;
    $createTableSql = "CREATE TABLE $tableName (
        id INT(6) UNSIGNED AUTO_INCREMENT PRIMARY KEY,
        subject VARCHAR(30) NOT NULL,
        level VARCHAR(10) NOT NULL
    )";

    if ($conn->query($createTableSql) === TRUE) {
        echo "Table $tableName created successfully";
		
		if ($conn->query($createTableQuery) === TRUE) {
        echo "Table created successfully";

        // Send the table name to another PHP page
        header("Location: markss.php?tableName=" . urlencode($tableName));
        exit();
    } else {
        echo "Error creating table: " . $conn->error;
    }
	
    } else {
        echo "No Table created " . $conn->error;
    }

} else {
    echo "Error: " . $sql . "<br>" . $conn->error;
}

// Close connection
$conn->close();
?>


