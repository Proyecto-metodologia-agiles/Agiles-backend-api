/**
 * Woin 
 *
 * Woin DDD architecture
 * use of Hexagonal Programming and DDD
 *
 * Hexagonal Architecture that allows us to develop and test our application in isolation from the framework,
 * the database, third-party packages and all those elements that are around our application
 *
 * @link https://dev-woin@dev.azure.com/dev-woin/app.woin/_git/app.woin.back-core
 * @since  0.1 rev
 * @author Carlos Andrés Castilla García <carlos-ac97@hotmail.com>
 * @name Iservice
 * @file Base/Interface
 * @observations use Base Service for Applications
 * @HU 0: Dominio
 * @task 7 Crear Servicios genericos
 */

namespace Application.Interface
{
    public interface IService<T> where T : class
    {

        public T Find(object id);
        public T Create(T entity);
        public bool Delete(T entity);
        public bool Delete(object id);
        public T Update(T entity);
    }
}
