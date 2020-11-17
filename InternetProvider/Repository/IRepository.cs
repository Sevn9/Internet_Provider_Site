using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    interface IRepository<T> : IDisposable
            where T : class
    {
        /// <summary>
        /// Получение всех объектов
        /// </summary>
        /// <returns></returns>
        IEnumerable<object> GetItemList(string type);
        /// <summary>
        /// Получение объекта
        /// </summary>
        /// <param name="id">Id объекта</param>
        /// <param name="type">Тип объекта</param>
        /// <returns></returns>
        object GetItem(Guid id, string type);
        /// <summary>
        /// Создание объекта
        /// </summary>
        /// <param name="item"></param>
        void Create(object item);
        /// <summary>
        /// Изменение объекта
        /// </summary>
        /// <param name="item"></param>
        void Update(object item);
        /// <summary>
        /// Удаление объекта
        /// </summary>
        /// <param name="id"></param>
        void Delete(object item);
    }
}
