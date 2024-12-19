document.querySelectorAll('.form-check-input-info').forEach(checkbox => {
    checkbox.addEventListener('change', function () {
        const id = this.getAttribute('data-id');
        const initialStatus = this.checked;
        const templateName = this.getAttribute('data-name') || id;
        let actionConfirmed = false; // Флаг для отслеживания подтверждения

        // Обновление данных в модальном окне
        document.getElementById('templateName').innerText = templateName;
        document.getElementById('newStatus').innerText = initialStatus ? 'Зафиксирован' : 'В редакции';

        // Показ модального окна
        const modalElement = document.getElementById('statusChangeModal');
        const modal = new bootstrap.Modal(modalElement);
        modal.show();

        // Восстановление состояния переключателя, если пользователь закроет окно
        modalElement.addEventListener('hidden.bs.modal', () => {
            if (!actionConfirmed) {
                this.checked = !initialStatus; // Возвращаем переключатель в исходное состояние только при отмене
            }
        });

        // Подтверждение действия
        document.getElementById('confirmStatusChange').onclick = () => {
            actionConfirmed = true; // Отмечаем, что действие подтверждено
            const payload = {};
            payload[id] = initialStatus;

            // AJAX-запрос
            fetch('/SampleEntities/UpdateValues', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                    'RequestVerificationToken': document.querySelector('input[name="__RequestVerificationToken"]').value
                },
                body: JSON.stringify(payload)
            })
                .then(response => {
                    if (response.ok) {
                        console.log(`Status for ID ${id} updated to ${initialStatus}`);
                    } else {
                        console.error(`Failed to update status for ID ${id}`);
                        alert('Ошибка обновления статуса.');
                        this.checked = !initialStatus; // Восстанавливаем исходное состояние
                    }
                })
                .catch(error => {
                    console.error('Error:', error);
                    alert('Произошла ошибка при отправке данных.');
                    this.checked = !initialStatus; // Восстанавливаем исходное состояние
                });

            modal.hide(); // Закрытие модального окна
        };
    });
});

