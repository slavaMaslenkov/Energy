document.addEventListener('DOMContentLoaded', function () {
    const subsystemDropdown = document.getElementById('SubsystemID');
    const parameterDropdown = document.getElementById('ParameterId');

    subsystemDropdown.addEventListener('change', async function () {
        const subsystemId = subsystemDropdown.value;

        if (subsystemId) {
            try {
                const response = await fetch(`/UnityEntities/GetParametersBySubsystem?subsystemId=${subsystemId}`);
                if (!response.ok) {
                    throw new Error('Ошибка при загрузке данных');
                }

                const data = await response.json();

                // Очистка и заполнение списка параметров
                parameterDropdown.innerHTML = '<option value="">Выберите параметр</option>';
                data.forEach(param => {
                    const option = document.createElement('option');
                    option.value = param.id;  // Используйте ID параметра
                    option.textContent = param.name;
                    parameterDropdown.appendChild(option);
                });
            } catch (error) {
                console.error('Ошибка загрузки параметров:', error);
                parameterDropdown.innerHTML = '<option value="">Ошибка загрузки</option>';
            }
        } else {
            parameterDropdown.innerHTML = '<option value="">Выберите параметр</option>';
        }
    });
});