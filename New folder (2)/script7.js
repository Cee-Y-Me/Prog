function signUpUser() {
    var name = document.getElementById('name').value;
    var surname = document.getElementById('surname').value;
    var idNumber = document.getElementById('idNumber').value;
    var email = document.getElementById('email').value;
    var phoneNumber = document.getElementById('phoneNumber').value;
    var password = document.getElementById('password').value;

    // AJAX request to send data to signup.php
    var xhr = new XMLHttpRequest();
    xhr.open('POST', 'signup.php', true);
    xhr.setRequestHeader('Content-Type', 'application/x-www-form-urlencoded');
    xhr.onload = function() {
        if (xhr.status === 200) {
            // Handle successful response
            alert(xhr.responseText);
        } else {
            // Handle error
            alert('Request failed. Status: ' + xhr.status);
        }
    };
    xhr.send('name=' + encodeURIComponent(name) + '&surname=' + encodeURIComponent(surname) + '&idNumber=' + encodeURIComponent(idNumber) + '&email=' + encodeURIComponent(email) + '&phoneNumber=' + encodeURIComponent(phoneNumber) + '&password=' + encodeURIComponent(password));
}
