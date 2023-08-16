using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace BDOBook.Application.Middleware
{
    public class SecurityHeadersMiddleware : IMiddleware
	{
        private const string ContentSecurityPolicy = "default-src 'self'; media-src 'none'; object-src 'none'; child-src 'none'; frame-src 'none'; worker-src 'none'; frame-ancestors 'none'; form-action 'self'; upgrade-insecure-requests; block-all-mixed-content; base-uri 'self'; script-src 'self'; style-src 'self' cdn.jsdelivr.net; img-src 'self' data:; connect-src 'self'; font-src cdn.jsdelivr.net";
        private const string PermissionsPolicy = "accelerometer=(), autoplay=(), camera=(), cross-origin-isolated=(), display-capture=(), encrypted-media=(), fullscreen=(), geolocation=(), gyroscope=(), keyboard-map=(), magnetometer=(), microphone=(), midi=(), payment=(), picture-in-picture=(), publickey-credentials-get=(), screen-wake-lock=(), sync-xhr=(), usb=(), web-share=(), xr-spatial-tracking=()";

        public Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            context.Response.Headers.Add("Strict-Transport-Security", "max-age=31536000");
            context.Response.Headers.Add("Content-Security-Policy", ContentSecurityPolicy);
            context.Response.Headers.Add("X-Frame-Options", "DENY");
            context.Response.Headers.Add("X-Content-Type-Options", "nosniff");
            context.Response.Headers.Add("Referrer-Policy", "no-referrer-when-downgrade");
            context.Response.Headers.Add("Permissions-Policy", PermissionsPolicy);
            context.Response.Headers.Add("Cross-Origin-Embedder-Policy", "require-corp");
            context.Response.Headers.Add("Cross-Origin-Opener-Policy", "same-orgin");
            context.Response.Headers.Add("Cross-Origin-Resource-Policy", "same-origin");

            return next(context);
        }
    }
}

