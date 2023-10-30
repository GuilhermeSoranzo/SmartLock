using System;
using System.Net;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Net.Http;

public class ConexaoESPSmartLock
{
    public void RequestToEsp(string acao)
    {
        string address = "192.168.4.1";

        string token = "ACB5"; 

        string url = $"http://{address}/?token={token}&led={acao}";

        HttpClient httpClient = new HttpClient();

        try
        {
            HttpResponseMessage response = httpClient.PostAsync(url, null).Result;
            string responseContent = response.Content.ReadAsStringAsync().Result;

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Solicitação bem-sucedida: " + responseContent);
            }
            else
            {
                Console.WriteLine("Erro na solicitação: " + responseContent);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao enviar a solicitação: " + ex.Message);
        }
    }
}
