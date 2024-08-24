using medipro_patient_service.Application.DTO;
using Medipro_Patient_Service.Common.Responses;
using medipro_patient_service.Domain.Models;

namespace medipro_patient_service.Application.Interfaces.Sevices;

/// <summary>
/// A generic service interface use for communicating with the repository layer.
/// </summary>
/// <typeparam name="T">where T is of type any</typeparam>
public interface IGenericService<T> where T: class
{
    /// <summary>
    /// talks to the repository layer to insert data to the database.
    /// </summary>
    /// <param name="dto">receives a dto to be inserted in  the database.</param>
    /// <returns>returns a generic response</returns>
    Task<Response<object>> AddAsync(BaseDto dto);
    /// <summary>
    /// talks to the repository layer to update data to the database.
    /// </summary>
    /// <param name="entity">receives the dto to be updated in the database</param>
    /// <returns>returns a generic response</returns>
    Task<T> UpdateAsync(T entity);
}