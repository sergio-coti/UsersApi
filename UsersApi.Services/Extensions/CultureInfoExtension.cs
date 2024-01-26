using Microsoft.AspNetCore.Localization;
using System.Globalization;

namespace UsersApi.Services.Extensions
{
    public static class CultureInfoExtension
    {
        public static IServiceCollection AddCultureInfo(this IServiceCollection services)
        {
            var cultureInfo = new CultureInfo("pt-BR");
            cultureInfo.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";
            cultureInfo.DateTimeFormat.LongDatePattern = "dd/MM/yyyy HH:mm:ss";
            cultureInfo.NumberFormat.CurrencySymbol = "R$";

            services.Configure<RequestLocalizationOptions>(options =>
            {
                options.DefaultRequestCulture = new RequestCulture(cultureInfo);
                options.SupportedCultures = new List<CultureInfo> { cultureInfo };
                options.SupportedUICultures = new List<CultureInfo> { cultureInfo };
            });

            return services;
        }
    }
}
