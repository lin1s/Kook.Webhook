using Newtonsoft.Json;
using System.Net;

namespace Tools
{
    public class HttpHelper
    {
        // Post请求
        public string PostResponse(string url, string postData, out string statusCode)
        {
            string result = string.Empty;
            //设置Http的正文
            HttpContent httpContent = new StringContent(postData);
            //设置Http的内容标头
            httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            //设置Http的内容标头的字符
            httpContent.Headers.ContentType.CharSet = "utf-8";
            using (HttpClient httpClient = new HttpClient())
            {
                //异步Post
                HttpResponseMessage response = httpClient.PostAsync(url, httpContent).Result;
                //输出Http响应状态码
                statusCode = response.StatusCode.ToString();
                //确保Http响应成功
                if (response.IsSuccessStatusCode)
                {
                    //异步读取json
                    result = response.Content.ReadAsStringAsync().Result;
                }
            }
            return result;
        }

        // 泛型：Post请求
        public T PostResponse<T>(string url, string postData) where T : class, new()
        {
            T result = default(T);

            HttpContent httpContent = new StringContent(postData);
            httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            httpContent.Headers.ContentType.CharSet = "utf-8";
            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage response = httpClient.PostAsync(url, httpContent).Result;

                if (response.IsSuccessStatusCode)
                {
                    Task<string> t = response.Content.ReadAsStringAsync();
                    string s = t.Result;
                    //Newtonsoft.Json
                    string json = JsonConvert.DeserializeObject(s).ToString();
                    result = JsonConvert.DeserializeObject<T>(json);
                }
            }
            return result;
        }

        // 泛型：Get请求
        public T GetResponse<T>(string url) where T : class, new()
        {
            T result = default(T);

            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = httpClient.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    Task<string> t = response.Content.ReadAsStringAsync();
                    string s = t.Result;
                    string json = JsonConvert.DeserializeObject(s).ToString();
                    result = JsonConvert.DeserializeObject<T>(json);
                }
            }
            return result;
        }

        // Get请求
        public string GetResponse(string url, out string statusCode)
        {
            string result = string.Empty;

            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = httpClient.GetAsync(url).Result;
                statusCode = response.StatusCode.ToString();

                if (response.IsSuccessStatusCode)
                {
                    result = response.Content.ReadAsStringAsync().Result;
                }
            }
            return result;
        }

        // Put请求
        public string PutResponse(string url, string putData, out string statusCode)
        {
            string result = string.Empty;
            HttpContent httpContent = new StringContent(putData);
            httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            httpContent.Headers.ContentType.CharSet = "utf-8";
            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage response = httpClient.PutAsync(url, httpContent).Result;
                statusCode = response.StatusCode.ToString();
                if (response.IsSuccessStatusCode)
                {
                    result = response.Content.ReadAsStringAsync().Result;
                }
            }
            return result;
        }

        // 泛型：Put请求
        public T PutResponse<T>(string url, string putData) where T : class, new()
        {
            T result = default(T);
            HttpContent httpContent = new StringContent(putData);
            httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            httpContent.Headers.ContentType.CharSet = "utf-8";
            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage response = httpClient.PutAsync(url, httpContent).Result;

                if (response.IsSuccessStatusCode)
                {
                    Task<string> t = response.Content.ReadAsStringAsync();
                    string s = t.Result;
                    string json = JsonConvert.DeserializeObject(s).ToString();
                    result = JsonConvert.DeserializeObject<T>(json);
                }
            }
            return result;
        }

        #region HttpClient

        /// <summary>
        /// Get请求指定的URL地址
        /// </summary>
        /// <param name="url">URL地址</param>
        /// <returns></returns>
        public static string GetWebAPI(string url)
        {
            string result = "";
            string strOut = "";
            try
            {
                result = GetWebAPI(url, out strOut);
            }
            catch (Exception ex)
            {
                LogHelper.Default.Error("调用后台服务出现异常！", ex);
            }
            return result;
        }

        /// <summary>
        /// Get请求指定的URL地址
        /// </summary>
        /// <param name="url">URL地址</param>
        /// <param name="statusCode">Response返回的状态</param>
        /// <returns></returns>
        public static string GetWebAPI(string url, out string statusCode)
        {
            string result = string.Empty;
            statusCode = string.Empty;
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = httpClient.GetAsync(url).Result;
                    statusCode = response.StatusCode.ToString();

                    if (response.IsSuccessStatusCode)
                    {
                        result = response.Content.ReadAsStringAsync().Result;
                    }
                    else
                    {
                        LogHelper.Default.Warn("调用后台服务返回失败：" + url + Environment.NewLine + JsonConvert.SerializeObject(response));
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.Default.Error("调用后台服务出现异常！", ex);
            }
            return result;
        }

        /// <summary>
        /// Get请求指定的URL地址
        /// </summary>
        /// <typeparam name="T">返回的json转换成指定实体对象</typeparam>
        /// <param name="url">URL地址</param>
        /// <returns></returns>
        public static T GetWebAPI<T>(string url) where T : class, new()
        {
            T result = default(T);
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response = httpClient.GetAsync(url).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        Task<string> t = response.Content.ReadAsStringAsync();
                        string s = t.Result;
                        string jsonNamespace = JsonConvert.DeserializeObject<T>(s).ToString();
                        result = JsonConvert.DeserializeObject<T>(s);
                    }
                    else
                    {
                        LogHelper.Default.Warn("调用后台服务返回失败：" + url + Environment.NewLine + JsonConvert.SerializeObject(response));
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.Default.Error("调用后台服务出现异常！", ex);
            }

            return result;
        }

        /// <summary>
        /// Post请求指定的URL地址
        /// </summary>
        /// <param name="url">URL地址</param>
        /// <param name="postData">提交到Web的Json格式的数据：如:{"ErrCode":"FileErr"}</param>
        /// <returns></returns>
        public static string PostWebAPI(string url, string postData)
        {
            string result = "";
            HttpStatusCode strOut = HttpStatusCode.BadRequest;
            try
            {
                result = PostWebAPI(url, postData, out strOut);
            }
            catch (Exception ex)
            {
                LogHelper.Default.Error("调用后台服务出现异常！", ex);
            }
            return result;

        }

        /// <summary>
        /// Post请求指定的URL地址
        /// </summary>
        /// <param name="url">URL地址</param>
        /// <param name="postData">提交到Web的Json格式的数据：如:{"ErrCode":"FileErr"}</param>
        /// <param name="statusCode">Response返回的状态</param>
        /// <returns></returns>
        public static string PostWebAPI(string url, string postData, out HttpStatusCode httpStatusCode)
        {
            string result = string.Empty;
            httpStatusCode = HttpStatusCode.BadRequest;
            //设置Http的正文
            HttpContent httpContent = new StringContent(postData);
            //设置Http的内容标头
            httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            //设置Http的内容标头的字符
            httpContent.Headers.ContentType.CharSet = "utf-8";

            HttpClientHandler httpHandler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip };
            try
            {
                //using (HttpClient httpClient = new HttpClient(httpHandler))
                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.Timeout = new TimeSpan(0, 0, 5);
                    //异步Post
                    HttpResponseMessage response = httpClient.PostAsync(url, httpContent).Result;
                    //输出Http响应状态码
                    httpStatusCode = response.StatusCode;
                    //确保Http响应成功
                    if (response.IsSuccessStatusCode)
                    {
                        //异步读取json
                        result = response.Content.ReadAsStringAsync().Result;
                    }
                    else
                    {
                        LogHelper.Default.Warn("调用后台服务返回失败：" + url + Environment.NewLine + JsonConvert.SerializeObject(response));
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.Default.Error("调用后台服务出现异常！", ex);
            }
            return result;
        }

        /// <summary>
        /// Post请求指定的URL地址
        /// </summary>
        /// <typeparam name="T">返回的json转换成指定实体对象</typeparam>
        /// <param name="url">URL地址</param>
        /// <param name="postData">提交到Web的Json格式的数据：如:{"ErrCode":"FileErr"}</param>
        /// <returns></returns>
        public static T PostWebAPI<T>(string url, string postData) where T : class, new()
        {
            T result = default(T);

            HttpContent httpContent = new StringContent(postData);
            httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            httpContent.Headers.ContentType.CharSet = "utf-8";

            HttpClientHandler httpHandler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip };
            try
            {
                using (HttpClient httpClient = new HttpClient(httpHandler))
                {
                    HttpResponseMessage response = httpClient.PostAsync(url, httpContent).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        Task<string> t = response.Content.ReadAsStringAsync();
                        string s = t.Result;
                        //Newtonsoft.Json
                        string jsonNamespace = JsonConvert.DeserializeObject<T>(s).ToString();
                        result = JsonConvert.DeserializeObject<T>(s);
                    }
                    else
                    {
                        LogHelper.Default.Warn("调用后台服务返回失败：" + url + Environment.NewLine + JsonConvert.SerializeObject(response));
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.Default.Error("调用后台服务出现异常！", ex);
            }
            return result;
        }

        /// <summary>
        /// Put请求指定的URL地址
        /// </summary>
        /// <param name="url">URL地址</param>
        /// <param name="putData">提交到Web的Json格式的数据：如:{"ErrCode":"FileErr"}</param>
        /// <returns></returns>
        public static string PutWebAPI(string url, string putData)
        {
            string result = "";
            string strOut = "";
            result = PutWebAPI(url, putData, out strOut);
            return result;
        }

        /// <summary>
        /// Put请求指定的URL地址
        /// </summary>
        /// <param name="url">URL地址</param>
        /// <param name="putData">提交到Web的Json格式的数据：如:{"ErrCode":"FileErr"}</param>
        /// <param name="statusCode">Response返回的状态</param>
        /// <returns></returns>
        public static string PutWebAPI(string url, string putData, out string statusCode)
        {
            string result = statusCode = string.Empty;
            HttpContent httpContent = new StringContent(putData);
            httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            httpContent.Headers.ContentType.CharSet = "utf-8";
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    HttpResponseMessage response = httpClient.PutAsync(url, httpContent).Result;
                    statusCode = response.StatusCode.ToString();
                    if (response.IsSuccessStatusCode)
                    {
                        result = response.Content.ReadAsStringAsync().Result;
                    }
                    else
                    {
                        LogHelper.Default.Warn("调用后台服务返回失败：" + url + Environment.NewLine + JsonConvert.SerializeObject(response));
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.Default.Error("调用后台服务出现异常！", ex);
            }
            return result;
        }

        /// <summary>
        /// Put请求指定的URL地址
        /// </summary>
        /// <typeparam name="T">返回的json转换成指定实体对象</typeparam>
        /// <param name="url">URL地址</param>
        /// <param name="putData">提交到Web的Json格式的数据：如:{"ErrCode":"FileErr"}</param>
        /// <returns></returns>
        public static T PutWebAPI<T>(string url, string putData) where T : class, new()
        {
            T result = default(T);
            HttpContent httpContent = new StringContent(putData);
            httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            httpContent.Headers.ContentType.CharSet = "utf-8";
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    HttpResponseMessage response = httpClient.PutAsync(url, httpContent).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        Task<string> t = response.Content.ReadAsStringAsync();
                        string s = t.Result;
                        string jsonNamespace = JsonConvert.DeserializeObject<T>(s).ToString();
                        result = JsonConvert.DeserializeObject<T>(s);
                    }
                    else
                    {
                        LogHelper.Default.Warn("调用后台服务返回失败：" + url + Environment.NewLine + JsonConvert.SerializeObject(response));
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.Default.Error("调用后台服务出现异常！", ex);
            }
            return result;
        }

        #endregion

        private static HttpResponseMessage HttpPost(string url, HttpContent httpContent)
        {
            HttpResponseMessage response = null;
            HttpClientHandler httpHandler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip };
            try
            {
                //using (HttpClient httpClient = new HttpClient(httpHandler))
                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.Timeout = new TimeSpan(0, 0, 5);
                    //异步Post
                    response = httpClient.PostAsync(url, httpContent).Result;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Default.Error("调用后台服务出现异常！", ex);
            }
            return response;
        }
    }
}
