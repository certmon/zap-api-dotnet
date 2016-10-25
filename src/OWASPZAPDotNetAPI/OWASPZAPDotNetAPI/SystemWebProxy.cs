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
 * 
 * PS - This is a port of the original project - Certmon
 */

using System;
using System.Net;

namespace OWASPZAPDotNetAPI
{
    class SystemWebProxy : IWebProxy
    {
         public SystemWebProxy(string proxyUri)
        : this(new Uri(proxyUri))
    {
    }

    public SystemWebProxy(Uri proxyUri)
    {
        this.ProxyUri = proxyUri;
    }

    public Uri ProxyUri { get; set; }

    public ICredentials Credentials { get; set; }

    public Uri GetProxy(Uri destination)
    {
        return this.ProxyUri;
    }

    public bool IsBypassed(Uri host)
    {
        return false; /* Proxy all requests */
    }
    }
}