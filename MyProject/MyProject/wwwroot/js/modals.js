document.addEventListener('DOMContentLoaded', function () {
    const selectAllCheckbox = document.getElementById('select-all');
    const deleteSelectedButton = document.getElementById('delete-selected');
    const massDeleteModal = document.getElementById('massDeleteModal');
    const deviceCountElement = document.getElementById('deviceCount');
    const deleteSelectedForm = document.getElementById('deleteSelectedForm');

    // Отметить все чекбоксы при выборе "выбрать все"
    selectAllCheckbox.addEventListener('change', function () {
        const checkboxes = document.querySelectorAll('.select-item');
        checkboxes.forEach(function (checkbox) {
            checkbox.checked = selectAllCheckbox.checked;
        });
    });

    // Обработка кнопки "Удалить"
    deleteSelectedButton.addEventListener('click', function () {
        const selectedIds = [];
        const checkboxes = document.querySelectorAll('.select-item:checked');
        checkboxes.forEach(function (checkbox) {
            selectedIds.push(checkbox.value);
        });

        if (selectedIds.length > 0) {
            // Получаем URL для действия из атрибута data-delete-action
            const deleteAction = deleteSelectedButton.getAttribute('data-delete-action');

            // Обновляем action формы с передачей выбранных ID
            deleteSelectedForm.action = `${deleteAction}?ids=${selectedIds.join(',')}`;

            // Показать модальное окно с количеством выбранных устройств
            deviceCountElement.textContent = selectedIds.length;

            // Показать модальное окно
            var modal = new bootstrap.Modal(massDeleteModal);
            modal.show();
        } else {
            alert("Не выбрано ни одного устройства.");
        }
    });
});

// Настройка модального окна для одиночного удаления
document.addEventListener('DOMContentLoaded', function () {
    const deleteModal = document.getElementById('deleteModal');
    deleteModal.addEventListener('show.bs.modal', function (event) {
        const button = event.relatedTarget; // Кнопка, которая вызвала модальное окно
        const deviceName = button.getAttribute('data-device-name');
        const deleteUrl = button.getAttribute('data-delete-url');

        // Установить имя устройства в модальное окно
        const modalDeviceName = deleteModal.querySelector('#deviceName');
        modalDeviceName.textContent = deviceName;

        // Установить URL для формы удаления
        const deleteForm = deleteModal.querySelector('#deleteForm');
        deleteForm.action = deleteUrl;
    });
});