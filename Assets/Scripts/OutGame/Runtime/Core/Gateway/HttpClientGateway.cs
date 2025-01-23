using Cysharp.Threading.Tasks;
using Newtonsoft.Json;

namespace OutGame.Runtime.Core.Gateway
{
    public class HttpClientGateway : IHttpClientGateway
    {
        public async UniTask<TResponse> RequestAsync<TRequest, TResponse>(string url, TRequest requestData)
        {
            string jsonRequest = JsonConvert.SerializeObject(requestData); // 직렬화
            string jsonResponse = "{}"; // 서버에서 받은 JSON 응답
            await UniTask.Delay(1000); // 서버 통신 대신 1초 대기
            return JsonConvert.DeserializeObject<TResponse>(jsonResponse); // 역직렬화
        }
    }
}