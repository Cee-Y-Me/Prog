function openAppointmentForm() {
    const appointmentForm = document.getElementById('appointment-form');
    appointmentForm.classList.remove('hidden');
}

function submitAppointment() {
    const datePicker = document.getElementById('date-picker');
    const selectedDate = datePicker.value;

    const timeInput = document.getElementById('time');
    const placeInput = document.getElementById('place');
    const subjectInput = document.getElementById('subject');

    const time = timeInput.value;
    const place = placeInput.value;
    const subject = subjectInput.value;

    // You can handle the submission of appointment here, e.g., saving to database
    console.log("Appointment Scheduled:");
    console.log("Date:", selectedDate);
    console.log("Time:", time);
    console.log("Place:", place);
    console.log("Subject:", subject);

    // Create appointment element and add to the appointment list
    const appointmentList = document.getElementById('appointment-list');
    const appointmentItem = document.createElement('div');
    appointmentItem.classList.add('appointment-item');
    appointmentItem.innerHTML = `<strong>${selectedDate}</strong>: ${time} - ${subject} @ ${place}`;
    appointmentList.appendChild(appointmentItem);

    // Reset form fields
    timeInput.value = '';
    placeInput.value = '';
    subjectInput.value = '';

    // Hide appointment form after submission
    const appointmentForm = document.getElementById('appointment-form');
    appointmentForm.classList.add('hidden');
}
