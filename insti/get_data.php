<?php
// Replace 'your_username' and 'your_password' with your actual database username and password
$databaseUsername = "root";
$databasePassword = "";
$dbname = $_GET['institution'];

$conn = new mysqli("localhost", $databaseUsername, $databasePassword,$dbname);

// Check connection
if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
}

if (isset($_GET['institution']) && isset($_GET['table'])) {
    $institution = $_GET['institution'];
    $table = $_GET['table'];

    // Query to get the data from a specific column within the table
    $query = "SELECT Programme FROM $table"; 
    
    // Execute the query
    $result = mysqli_query($conn, $query);

    // Check if the query was successful
    if ($result) {
        $courses = array();

        // Fetch the data from the specified column and store them in an array
        while ($row = mysqli_fetch_array($result)) {
            // Assuming the column name containing courses data is 'Programme'
            $courses[] = $row['Programme'];
        }

        // Output the data as JSON
        echo json_encode(array('courses' => $courses));
    } else {
        // If query fails, output an error message
        echo json_encode(array('error' => 'Failed to retrieve data.'));
    }
} else {
    // If institution or table parameters are not provided, output an error message
    echo json_encode(array('error' => 'Institution or table parameter not provided.'));
}
?>

