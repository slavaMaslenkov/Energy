document.addEventListener("DOMContentLoaded", function () {
    // Получаем все элементы checkbox для статуса шаблона
    const switches = document.querySelectorAll('.form-check-input');

    switches.forEach((switchElem) => {
        switchElem.addEventListener('change', function () {
            const deviceId = switchElem.getAttribute('data-id');
            const status = switchElem.checked;  // Получаем текущее состояние чекбокса
            toggleInputFields(deviceId, status);
        });

        // Инициализируем состояние полей при загрузке
        const deviceId = switchElem.getAttribute('data-id');
        console.log(`data-id`);
        console.log(`data-name`);
        const status = switchElem.checked;  // Получаем текущее состояние чекбокса
        toggleInputFields(deviceId, status);
    });
});

function toggleInputFields(deviceId, status) {
    // Получаем все поля ввода для параметров данного устройства
    const inputFields = document.querySelectorAll(`input[name='Values[${deviceId}]']`);

    inputFields.forEach((input) => {
        if (status) {
            input.disabled = true; // Блокируем поле ввода
        } else {
            input.disabled = false;  // Включаем поле ввода
        }
    });
}