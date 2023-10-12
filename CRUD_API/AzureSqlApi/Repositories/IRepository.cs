// AzureSqlApi/Repositories/IRepository.cs
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AzureSqlApi.Repositories
{
    /// <summary>
    /// Represents a generic repository interface for basic CRUD operations on entities.
    /// </summary>
    /// <typeparam name="TEntity">The type of entity managed by the repository.</typeparam>
    public interface IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Asynchronously retrieves an entity by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the entity.</param>
        /// <returns>The entity with the specified ID, or null if not found.</returns>
        Task<TEntity> GetByIdAsync(int id);

        /// <summary>
        /// Asynchronously retrieves a list of all entities of the specified type.
        /// </summary>
        /// <returns>A list of entities.</returns>
        Task<List<TEntity>> GetAllAsync();

        /// <summary>
        /// Asynchronously finds entities that match the given predicate.
        /// </summary>
        /// <param name="predicate">The predicate to filter entities.</param>
        /// <returns>A list of matching entities.</returns>
        Task<List<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Asynchronously adds a new entity to the repository.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        /// <returns>The added entity.</returns>
        Task<TEntity> AddAsync(TEntity entity);

        /// <summary>
        /// Asynchronously updates an existing entity in the repository.
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        /// <returns>The updated entity.</returns>
        Task<TEntity> UpdateAsync(TEntity entity);

        /// <summary>
        /// Asynchronously deletes an entity by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the entity to delete.</param>
        /// <returns>The deleted entity, or null if not found.</returns>
        Task<TEntity> DeleteAsync(int id);
    }
}
