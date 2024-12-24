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
                                <span class="equipment-item" data-equipment-id="${equipment.id}" style="cursor: pointer;">
                                    <i class="bi bi-cpu me-2"></i>${equipment.name}
                                </span>
                                <ul class="subsystem-list" style="display: none; list-style-type: none; margin-left: 20px;"></ul>
                            `;
                    equipmentList.appendChild(equipmentItem);
                });

                equipmentList.style.display = 'block';

                // Добавляем обработчики для устройств
                document.querySelectorAll('.equipment-item').forEach(function (equipment) {
                    equipment.addEventListener('click', async function () {
                        const equipmentId = equipment.getAttribute('data-equipment-id');
                        const subsystemList = equipment.nextElementSibling;

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