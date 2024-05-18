const selectedItems = new Set();

document.addEventListener("DOMContentLoaded", function () {
    // Retrieve userAnswers from localStorage
    const storedUserAnswers = localStorage.getItem('userAnswers');

    if (storedUserAnswers) {
        const userAnswers = JSON.parse(storedUserAnswers);

        // Now you can use the userAnswers array on this page as needed
        console.log("Retrieved User Answers:", userAnswers);

        // For example, if you want to display the userAnswers in a list
        const selected2List = document.querySelector('.selected2 ul');
        // Clear the existing list
        selected2List.innerHTML = '';

        userAnswers.forEach((answers, index) => {
            const listItem = document.createElement("li");
            listItem.textContent = `Question ${index + 1}: ${answers.join(", ")}`;
            selected2List.appendChild(listItem);
        });
    }

    // Function to handle image button click
    function handleButtonClick(id) {
        const button = document.querySelector(`.image-button[data-id="${id}"]`);
        const imageAlt = button.querySelector('.images').alt;

        if (selectedItems.has(imageAlt)) {
            // If already selected, remove from the list
            selectedItems.delete(imageAlt);
        } else {
            // If not selected, check the limit before adding to the list
            if (selectedItems.size < 3) {
                selectedItems.add(imageAlt);
            } else {
                alert("You can only select up to 3 items.");
            }
        }

        updateSelectedList();
    }

    // Function to handle confirm button click
    function handleConfirmClick() {
        // Check if the selected items are exactly 3
        if (selectedItems.size === 3) {
            // Convert Set to an array for storage
            const selectedItemsArray = Array.from(selectedItems);

            // Store selected items in localStorage
            localStorage.setItem('selectedItems', JSON.stringify(selectedItemsArray));

            // Redirect to a new page
            window.location.href = 'dashboard.html';
        } else {
            alert("Please select exactly 3 items.");
        }
    }

    // Function to update the selected list in the DOM
    function updateSelectedList() {
        const selectedList = document.querySelector('.selected ul');
        // Clear the existing list
        selectedList.innerHTML = '';

        // Populate the list with selected items
        selectedItems.forEach(item => {
            const listItem = document.createElement('li');
            listItem.textContent = item;
            selectedList.appendChild(listItem);
        });
    }

    // Function to update the selected2 list in the DOM
    function updateSelected2List() {
        const selected2List = document.querySelector('.selected2 ul');
        // Clear the existing list
        selected2List.innerHTML = '';

        // Populate the list with selected items
        selectedItems.forEach(item => {
            const listItem = document.createElement('li');
            listItem.textContent = item;
            selected2List.appendChild(listItem);
        });
    }

    // Initial update of the selected2 list
    updateSelected2List();
});
