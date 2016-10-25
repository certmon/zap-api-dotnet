/* Zed Attack Proxy (ZAP) and its related class files.
 *
 * ZAP is an HTTP/HTTPS proxy for assessing web application security.
 *
 * Copyright the ZAP development team
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *   http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OWASPZAPDotNetAPI
{
    class SystemWebClient : IWebClient, IDisposable
    {
        HttpClient httpClient;
        //WebProxy webProxy;

        public SystemWebClient(string proxyHost, int proxyPort)
        {
            var handler = new HttpClientHandler {
                Proxy = new SystemWebProxy(string.Format("{0}:{1}",  proxyHost, proxyPort)),
                UseProxy = true
            };

            httpClient =  new HttpClient(handler);
        }

        public string DownloadString(string address)
        {
            return DownloadString(new Uri(address));            
        }

        public string DownloadString(Uri uri)
        {
            string response = null;
            var task = httpClient.GetStringAsync(uri).ContinueWith(r => response = r.Result);
            task.Wait();
            return response;
        }

        public byte[] DownloadData(Uri uri)
        {
            byte[] bits = null;
            var task = httpClient.GetByteArrayAsync(uri).ContinueWith(r => bits = r.Result);
            task.Wait();
            return bits;
        }

        public void Dispose()
        {
            httpClient.Dispose();
        }
    }
}
