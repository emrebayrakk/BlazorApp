using Newtonsoft.Json;

namespace BlazorApp.Web;

public class ApiClient(HttpClient httpClient)
{
    public async Task<T> GetFromJsonAsync<T>(string path)
    {
        return await httpClient.GetFromJsonAsync<T>(path);
    }
    public async Task<T1> PostAsync<T1,T2>(string path,T2 postModel)
    {
        var res = await httpClient.PostAsJsonAsync(path,postModel);
        if (res != null) {
            return JsonConvert.DeserializeObject<T1>(await res.Content.ReadAsStringAsync());
        }
        return default;
    }
}
