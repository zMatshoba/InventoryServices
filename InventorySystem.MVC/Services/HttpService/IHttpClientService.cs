namespace InventorySystem.MVC.Services.HttpService;

public interface IHttpClientService
{
    Task<HttpResponseMessage> HttpPostAsync<T>(string RequestUri, T model);

    Task<HttpResponseMessage> HttpPutAsync<T>(string RequestUri, T model);

    Task<List<T>> HttpRetrieveAllAsync<T>(string RequestUri);

    Task<T> HttpRetrieveByIdAsync<T>(string RequestUri);
}