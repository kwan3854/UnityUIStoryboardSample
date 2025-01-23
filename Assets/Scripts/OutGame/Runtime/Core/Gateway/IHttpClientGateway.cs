using Cysharp.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace OutGame.Runtime.Core.Gateway
{
    public interface IHttpClientGateway
    {
        // Return json object from server using newtonsoft json
        public UniTask<TResponse> RequestAsync<TRequest, TResponse>(string url, TRequest requestData);
    }
}