using System.Collections.Generic;

namespace Business.Interfaces
{
    public interface ICrudAppService<TRequest, TResponse>
        where TRequest : class
        where TResponse : class
    {
        List<TResponse> Select();
        List<TResponse> Select(int id);
        int Insert(TRequest request);
        void Update(TRequest request);
        void Delete(int id);
    }
}
