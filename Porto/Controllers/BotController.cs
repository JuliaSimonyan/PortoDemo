using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Porto.Data.Models;
using System.Text;

namespace Porto.Controllers
{
    public class BotController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Index(string userMessage, BotTheme theme)
        {
            var response = await GetOllamaResponse(userMessage, theme);
            ViewBag.Response = response;
            ViewBag.UserMessage = userMessage;
            ViewBag.Theme = theme;
            return View();
        }


        private async Task<string> GetOllamaResponse(string userMessage, BotTheme theme)
        {
            using (var client = new HttpClient())
            {
                var prompt = $"Theme: {theme}. Question: {userMessage}";

                var requestBody = new
                {
                    model = "mistral",  // Or llama2, etc.
                    prompt = prompt,
                    stream = false
                };

                var json = JsonConvert.SerializeObject(requestBody);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync("http://localhost:11434/api/generate", content);
                var result = await response.Content.ReadAsStringAsync();

                dynamic data = JsonConvert.DeserializeObject(result);
                return data.response;
            }
        }
    }
}
