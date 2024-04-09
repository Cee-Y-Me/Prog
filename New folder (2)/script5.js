
// Assuming you have the 'subjects' array defined in your JavaScript
var subjects = [
    "Accounting", "Agricultural Management Practices", "Agricultural Sciences",
    "Agricultural Technology", "Business Studies", "Civil Technology",
    "Computer Applications Technology", "Consumer Studies", "Dance Studies",
    "Design", "Dramatic Arts", "Economics", "Electrical Technology",
    "Engineering Graphics and Design", "Geography", "History", "Hospitality Studies",
    "Information Technology", "Life Orientation", "Life Sciences", "Biology",
    "Mathematical Literacy", "Mathematics", "Technical Mathematics", "Mechanical Technology",
    "Music", "Physical Sciences", "Technical Sciences", "Religion Studies", "Tourism",
    "Visual Arts", "Afrikaans Home Language", "Afrikaans First Additional Language",
    "English", "isiZulu Home Language", "isiZulu First Additional Language",
    "Sesotho Home Language", "Sesotho First Additional Language", "Setswana Home Language",
    "Setswana First Additional Language", "Xhosa Home Language", "Xhosa First Additional Language",
    "Sepedi Home Language", "Sepedi First Additional Language", "Tshivenda Home Language",
    "Tshivenda First Additional Language", "Siswati Home Language", "Siswati First Additional Language",
    "IsiNdebele Home Language", "IsiNdebele First Additional Language", "Sign Language Home Language",
    "Sign Language First Additional Language"
];

// Function to add new fields
function addNewFields() {
    // Create new elements for the dropdown, input field, and remove button
    var newDiv = document.createElement('div');
    newDiv.className = 'marks';

    var newSelect = document.createElement('select');
    newSelect.className = 'Options';

    var newInput = document.createElement('input');
    newInput.type = 'text';
    newInput.className = 'level';

    var removeButton = document.createElement('button');
    removeButton.textContent = '-';
    removeButton.className = 'removeButton'; // Assign the class to the remove button

    // Populate the dropdown with options
    subjects.forEach(function(subject) {
        var option = document.createElement('option');
        option.value = subject;
        option.text = subject;
        newSelect.appendChild(option);
    });

    // Append the new elements to the container
    newDiv.appendChild(newSelect);
    newDiv.appendChild(newInput);
    newDiv.appendChild(removeButton);
    document.getElementById('fieldsContainer').appendChild(newDiv);

    // Add event listener for the remove button
    removeButton.addEventListener('click', function() {
        newDiv.remove(); // Remove the corresponding set of fields
    });

    // Event listener for input validation
    newInput.addEventListener('input', function() {
        // Allow only numbers between 1 and 7
        this.value = this.value.replace(/[^1-7]/g, '');
    });

    // Event listener for select change
    newSelect.addEventListener('change', function() {
        // Check if the same subject is selected in any other dropdown
        var selectedSubjects = [];
        document.querySelectorAll('.Options').forEach(function(select) {
            if (select !== newSelect && select.value !== '') {
                selectedSubjects.push(select.value);
            }
        });
        if (selectedSubjects.includes(this.value)) {
            alert('Each subject must be unique.');
            this.value = ''; // Reset the selected value
        }
    });
}

// Call addNewFields function whenever needed, for example, on button click
document.getElementById('addFieldsButton').addEventListener('click', function(event) {
    event.preventDefault(); // Prevent default form submission
    addNewFields(); // Add new dropdown and input fields
});

// Event listener for form submission
document.getElementById('submitButton').addEventListener('click', function(event) {
   event.preventDefault(); // Prevent the default form submission

    // Count the number of subjects with selected values
    var selectedCount = 0;
    var validLevels = true;
    var selectedSubjects = [];
    var selectedLevels = [];
    document.querySelectorAll('.marks').forEach(function(marksDiv) {
        var select = marksDiv.querySelector('select');
        var input = marksDiv.querySelector('input');

        var selectedSubject = select.value;
        var enteredMarks = input.value;

        if (selectedSubject !== "") {
            selectedCount++;
            selectedSubjects.push(selectedSubject);
        }
        if (enteredMarks < 1 || enteredMarks > 7) {
            validLevels = false;
        }
        selectedLevels.push(enteredMarks);
    });

    // Check if the selected count is less than 7
    if (selectedCount < 7) {
        alert("Please select at least 7 subjects.");
        return; // Exit the function to prevent further execution
    }
    // Check if each subject is unique
    if (new Set(selectedSubjects).size !== selectedSubjects.length) {
        alert("Each subject must be unique.");
        return; // Exit the function to prevent further execution
    }
    // Check if all levels are valid (between 1 and 7)
    if (!validLevels) {
        alert("Levels must be between 1 and 7.");
        return; // Exit the function to prevent further execution
    }

    // Collect subjects and marks from all input fields
    var data = [];
    document.querySelectorAll('.marks').forEach(function(marksDiv) {
        var select = marksDiv.querySelector('select');
        var input = marksDiv.querySelector('input');

        var selectedSubject = select.value;
        var enteredMarks = input.value;

        data.push({ subject: selectedSubject, marks: enteredMarks });
    });

    // Send data to the server using fetch API
    fetch('markss.php', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ data: data })
    })
    .then(response => response.text())
    .then(data => {
        console.log(data); // Log the response from the server
        if (data === 'Data inserted successfully') {
            // Redirect to the next page
            window.location.href = 'searchbar.html'; // Replace with the actual URL
        }
    })
    .catch(error => {
        console.error('Error:', error);
    });
});

