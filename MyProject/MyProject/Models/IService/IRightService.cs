namespace MyProject.Models.IService
{
    public interface IRightService
    {
        /// <summary>
        /// Метод создает экземпляр класса />.
        /// </summary>
        ///<param name="unityId">Id объекта.</param>
        ///<param name="roleIds">Ids объекта.</param>
        /// <returns>Лист RightEntity/>.</returns>
        Task AttachRoleToUnity(int unityId, List<int> roleIds);
    }
}
