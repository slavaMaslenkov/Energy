document.querySelectorAll('.form-check-input-info').forEach(checkbox => {
    checkbox.addEventListener('change', function () {
        const id = this.getAttribute('data-id'); // Получаем ID шаблона
        const status = this.checked; // Новый статус
        const templateName = checkbox?.getAttribute('data-name') || id; // Имя шаблона (опционально)

        // Устанавливаем данные в модальное окно
        document.getElementById('templateName').innerText = templateName;
        document.getElementById('newStatus').innerText = status ? 'Зафиксирован' : 'В редакции';

        // Показываем модальное окно
        const modal = new bootstrap.Modal(document.getElementById('statusChangeModal'));
        modal.show();

        // Обработчик подтверждения
        document.getElementById('confirmStatusChange').onclick = () => {
            const payload = {};
            payload[id] = status;

            // AJAX запрос на сервер
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
                        console.log(`Status for ID ${id} updated to ${status}`);
                    } else {
                        console.error(`Failed to update status for ID ${id}`);
                        alert('Ошибка обновления статуса.');
                    }
                })
                .catch(error => {
                    console.error('Error:', error);
                    alert('Произошла ошибка при отправке данных.');
                });

            // Закрытие модального окна
            modal.hide();
        };

        // Обработчик отмены
        document.querySelector('.btn-close').onclick = () => {
            this.checked = !status; // Отменяем изменение тумблера
        };
    });
});