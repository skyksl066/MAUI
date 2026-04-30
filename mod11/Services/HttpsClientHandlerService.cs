using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mod11.Services;
public class HttpsClientHandlerService
{
    public HttpMessageHandler GetPlatformMessageHandler()
    {
#if ANDROID
        var handler = new Xamarin.Android.Net.AndroidMessageHandler();
        handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) =>
        {
            if (cert != null && cert.Issuer.Equals("CN=localhost"))
                return true;
            return errors == System.Net.Security.SslPolicyErrors.None;
        };
        return handler;
#elif IOS
    var handler = new NSUrlSessionHandler
    {
        TrustOverrideForUrl = IsHttpsLocalhost
    };
    return handler;
#elif WINDOWS
     HttpClientHandler handler = new HttpClientHandler();
     handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };        
            return handler;
#else
        return new SocketsHttpHandler ();
#endif
    }

#if IOS
public bool IsHttpsLocalhost(NSUrlSessionHandler sender, string url, Security.SecTrust trust)
{
    if (url.StartsWith("https://localhost"))
        return true;
    return false;
}
#endif
}

