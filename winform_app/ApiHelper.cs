using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;


namespace WinformDemoV01
{
    internal class ApiHelper
    {
        public string base_url = "http://localhost:5001";


        public JObject ValidateUser(string inputAccount, string inputPassword)
        {
            var url = base_url + "/api/validate_user";
            var post_data = new { account = inputAccount, password = inputPassword };
            string post_content = JsonConvert.SerializeObject(post_data);
            HttpClient client = new HttpClient();
            StringContent content = new StringContent(post_content, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(url, content).Result;
            string strResponse = response.Content.ReadAsStringAsync().Result;
            client.Dispose();
            return JObject.Parse(strResponse);
        }

        public JArray GetHoldingLatestRecords()
        {
            var httpClient = new HttpClient();
            string api_url = base_url + "/api/holding_latest_records";
            var result = httpClient.GetAsync(api_url).GetAwaiter().GetResult();
            string res = result.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            JArray list_records = JArray.Parse(res);
            return list_records;
        }

        public JArray GetHoldingDates()
        {
            var httpClient = new HttpClient();
            string api_url = base_url + "/api/holding_dates";
            var result = httpClient.GetAsync(api_url).GetAwaiter().GetResult();
            string res = result.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            JArray list_dates = JArray.Parse(res);
            return list_dates;
        }

        public JObject GetStockMv(string chooseDate)
        {
            var url = base_url + "/api/mv_stock";
            var post_data = new { holdingdate=chooseDate };
            string post_content = JsonConvert.SerializeObject(post_data);
            HttpClient client = new HttpClient();
            StringContent content = new StringContent(post_content, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(url, content).Result;
            string strResponse = response.Content.ReadAsStringAsync().Result;
            client.Dispose();
            return JObject.Parse(strResponse);
        }

        public JObject GetStockCounts(string chooseDate)
        {
            var url = base_url + "/api/counts_stock";
            var post_data = new { holdingdate = chooseDate };
            string post_content = JsonConvert.SerializeObject(post_data);
            HttpClient client = new HttpClient();
            StringContent content = new StringContent(post_content, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(url, content).Result;
            string strResponse = response.Content.ReadAsStringAsync().Result;
            client.Dispose();
            return JObject.Parse(strResponse);
        }

        public JObject GetBondAmount(string chooseDate)
        {
            var url = base_url + "/api/amount_bond";
            var post_data = new { holdingdate = chooseDate };
            string post_content = JsonConvert.SerializeObject(post_data);
            HttpClient client = new HttpClient();
            StringContent content = new StringContent(post_content, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(url, content).Result;
            string strResponse = response.Content.ReadAsStringAsync().Result;
            client.Dispose();
            return JObject.Parse(strResponse);
        }

        public JObject GetCashAmount(string chooseDate)
        {
            var url = base_url + "/api/amount_cash";
            var post_data = new { holdingdate = chooseDate };
            string post_content = JsonConvert.SerializeObject(post_data);
            HttpClient client = new HttpClient();
            StringContent content = new StringContent(post_content, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(url, content).Result;
            string strResponse = response.Content.ReadAsStringAsync().Result;
            client.Dispose();
            return JObject.Parse(strResponse);
        }

        public JObject GetPercentageIndustry(string chooseDate)
        {
            var url = base_url + "/api/percentage_industry";
            var post_data = new { holdingdate = chooseDate };
            string post_content = JsonConvert.SerializeObject(post_data);
            HttpClient client = new HttpClient();
            StringContent content = new StringContent(post_content, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(url, content).Result;
            string strResponse = response.Content.ReadAsStringAsync().Result;
            client.Dispose();
            return JObject.Parse(strResponse);
        }

        public JObject GetMvStockInEtfs(string chooseDate)
        {
            var url = base_url + "/api/mv_stock_in_etfs";
            var post_data = new { holdingdate = chooseDate };
            string post_content = JsonConvert.SerializeObject(post_data);
            HttpClient client = new HttpClient();
            StringContent content = new StringContent(post_content, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(url, content).Result;
            string strResponse = response.Content.ReadAsStringAsync().Result;
            client.Dispose();
            return JObject.Parse(strResponse);
        }

        public JArray GetAllUsers()
        {
            var httpClient = new HttpClient();
            string api_url = base_url + "/api/users";
            var result = httpClient.GetAsync(api_url).GetAwaiter().GetResult();
            string res = result.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            JArray list_records = JArray.Parse(res);
            return list_records;
        }

       
        public JObject ReviseUser(string inputAction, int inputUserId, string inputUsername, string inputEmail, string inputPassword, string inputAuthority)
        {            
            var url = base_url + "/api/revise_user";
            var post_data = new { action = inputAction, user_id = inputUserId, username = inputUsername, email = inputEmail, password = inputPassword, authority=inputAuthority};
            string post_content = JsonConvert.SerializeObject(post_data);
            HttpClient client = new HttpClient();
            StringContent content = new StringContent(post_content, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(url, content).Result;
            string strResponse = response.Content.ReadAsStringAsync().Result;
            client.Dispose();
            return JObject.Parse(strResponse);
        }
    }
}
