document.addEventListener('DOMContentLoaded', function () {
    // Обработчик клика по станции
    document.querySelectorAll('.station-item').forEach(function (station) {
        station.addEventListener('click', async function () {
            const plantId = station.getAttribute('data-plant-id');
            const equipmentList = station.nextElementSibling;

            if (equipmentList.style.display === 'block') {
                equipmentList.style.display = 'none';
                return;
            }

            try {
                const response = await fetch(`/Base/GetEquipmentByPlant?plantId=${plantId}`);
                const data = await response.json();

                equipmentList.innerHTML = '';

                data.forEach(equipment => {
                    const equipmentItem = document.createElement('li');
                    equipmentItem.innerHTML = `
                        <span style="cursor: pointer; display: flex; align-items: center;">
                            <i class="bi bi-caret-down-fill me-2 toggle-subsystems" data-equipment-id="${equipment.id}"></i>
                            <a href="/UnityEntities/DeviceUnity?equipmentId=${equipment.id}&sampleId=${equipment.sample[0].id}"
                            style="text-decoration: none; color: inherit;">${equipment.name}</a>
                        </span>
                        <ul class="subsystem-list" style="display: none; list-style-type: none; margin-left: 20px;"></ul>
                    `;
                    equipmentList.appendChild(equipmentItem);
                });

                equipmentList.style.display = 'block';

                // Добавляем обработчики для раскрытия подустройств
                document.querySelectorAll('.toggle-subsystems').forEach(function (icon) {
                    icon.addEventListener('click', async function (event) {
                        event.stopPropagation(); // Предотвращаем раскрытие списка устройств
                        const equipmentId = icon.getAttribute('data-equipment-id');
                        const subsystemList = icon.parentElement.nextElementSibling;

                        if (subsystemList.style.display === 'block') {
                            subsystemList.style.display = 'none';
                            return;
                        }

                        try {
                            const response = await fetch(`/Base/GetSubsystemsByEquipment?equipmentId=${equipmentId}`);
                            const data = await response.json();

                            subsystemList.innerHTML = '';

                            data.forEach(subsystem => {
                                const subsystemItem = document.createElement('li');
                                subsystemItem.innerHTML = `
                                    <a href="/SubsystemEntities/Details/${subsystem.id}">
                                        <i class="bi bi-box me-2"></i>${subsystem.name}
                                    </a>`;
                                subsystemList.appendChild(subsystemItem);
                            });

                            subsystemList.style.display = 'block';
                        } catch (error) {
                            console.error('Ошибка загрузки подсистем:', error);
                        }
                    });
                });
            } catch (error) {
                console.error('Ошибка загрузки устройств:', error);
            }
        });
    });
});