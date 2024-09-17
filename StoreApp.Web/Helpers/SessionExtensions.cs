using System.Text.Json;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace StoreApp.Web;

public static class SessionExtentions
{
    //Chart Modelini Json formatını çeviren metot
    public static void SetJson(this ISession session, string key, object value)
    {
        session.SetString(key, JsonSerializer.Serialize(value));
    }


    public static T? GetJson<T>(this ISession session, string key)
    {
        var sessionData = session.GetString(key);
        return sessionData == null ? default(T) : JsonSerializer.Deserialize<T>(sessionData);
    }
}