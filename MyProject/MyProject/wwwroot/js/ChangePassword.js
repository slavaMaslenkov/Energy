document.addEventListener('DOMContentLoaded', function () {
    var successModal = document.getElementById('successModal');
    var unsuccessModal = document.getElementById('unsuccessModal');
    var passwordChanged = document.getElementById('data-change').getAttribute('data-password-changed');

    if (passwordChanged === 'True') { // Строковое значение "True"
        var modal = new bootstrap.Modal(successModal);
        modal.show();
    }
    if (passwordChanged === 'False') {
        var modal = new bootstrap.Modal(unsuccessModal);
        modal.show()
    }
});