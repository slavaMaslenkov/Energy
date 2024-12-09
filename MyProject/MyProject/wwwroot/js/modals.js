// Обработка кнопки "Удалить"
document.addEventListener('DOMContentLoaded', function () {
    const deleteSelectedButton = document.getElementById('delete-selected');
    const deleteSelectedForm = document.getElementById('deleteSelectedForm');
    const deviceCountElement = document.getElementById('deviceCount');
    const massDeleteModal = document.getElementById('massDeleteModal');
    const deleteModal = document.getElementById('deleteModal');
    const selectAllCheckbox = document.getElementById('select-all');

    selectAllCheckbox.addEventListener('change', function () {
        const checkboxes = document.querySelectorAll('.select-item');
        checkboxes.forEach(function (checkbox) {
            checkbox.checked = selectAllCheckbox.checked;
        });
    });

    // Обработчик для кнопки массового удаления
    deleteSelectedButton.addEventListener('click', function () {
        const selectedIds = [];
        const checkboxes = document.querySelectorAll('.select-item:checked');
        checkboxes.forEach(function (checkbox) {
            selectedIds.push(checkbox.value);
        });

        if (selectedIds.length > 0) {
            const deleteAction = deleteSelectedButton.getAttribute('data-delete-action');
            const deviceName = document.querySelector('input[name="DeviceName"]').value;

            // Обновляем action формы с передачей выбранных ID и DeviceName
            deleteSelectedForm.action = `${deleteAction}?ids=${selectedIds.join(',')}&deviceName=${encodeURIComponent(deviceName)}`;

            // Показать модальное окно с количеством выбранных объектов
            deviceCountElement.textContent = selectedIds.length;

            // Показать модальное окно
            var modal = new bootstrap.Modal(massDeleteModal);
            modal.show();
        } else {
            alert("Не выбрано ни одного устройства.");
        }
    });

    // Настройка модального окна для одиночного удаления
    deleteModal.addEventListener('show.bs.modal', function (event) {
        const button = event.relatedTarget; // Кнопка, которая вызвала модальное окно
        const deviceName = button.getAttribute('data-device-name');
        const deleteUrl = button.getAttribute('data-delete-url');
        const globalDeviceName = document.querySelector('input[name="DeviceName"]').value;

        // Установить имя устройства в модальное окно
        const modalDeviceName = deleteModal.querySelector('#deviceName');
        modalDeviceName.textContent = deviceName;

        // Установить URL для формы удаления с добавлением DeviceName
        const deleteForm = deleteModal.querySelector('#deleteForm');
        deleteForm.action = `${deleteUrl}&deviceName=${encodeURIComponent(globalDeviceName)}`;
    });
});