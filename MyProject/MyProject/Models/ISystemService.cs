namespace MyProject.Models
{
    public interface ISystemService
    {
        /// <summary>
        /// Метод создает экземпляр класса />.
        /// </summary>
        ///<param name="equipmentId">Имя объекта.</param>
        ///<param name="subsystemIds">Имя объекта.</param>
        /// <returns>Лист SystemEntity/>.</returns>
        Task AttachSubsystemsToEquipment(int equipmentId, List<int> subsystemIds);
    }
}
