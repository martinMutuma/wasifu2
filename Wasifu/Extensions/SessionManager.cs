using Newtonsoft.Json;
using Wasifu.Dtos;

namespace Wasifu.Extensions
{
    public static class SessionManager
    {
    

        public static readonly string LoggedInUserDtoKey = "LoggedInUser";

        public static LoginDto GetLoggedInUser(this ISession session)
        {
            try
            {
                return GetSession<LoginDto>(session, LoggedInUserDtoKey) ?? new LoginDto();
            }
            catch (Exception)
            {
                return new LoginDto();
            }
        }
     
        public static void SetLoggedInUser(this ISession session, LoginDto LoggedInUser)
        {
            try
            {
                SaveSession(session, LoggedInUserDtoKey, LoggedInUser);
            }
            catch (Exception)
            {

            }
        }


        static void SetObject(this ISession session, string key, object value)
        {
            if (session == null) return;
            var json = JsonConfig();
            session.SetString(key, JsonConvert.SerializeObject(value, json));
        }

        private static JsonSerializerSettings JsonConfig()
        {
            return new JsonSerializerSettings
            {
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                Formatting = Formatting.None,
                NullValueHandling = NullValueHandling.Ignore,
                DefaultValueHandling = DefaultValueHandling.Ignore
            };
        }

        static T GetObject<T>(this ISession session, string key)
        {
            if (session == null) return default(T);
            var value = session.GetString(key);
            var json = JsonConfig();

            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value, json);
        }


        public static T GetSession<T>(this ISession session, string key)
        {
            try
            {
                T sessionData = session.GetObject<T>(key);
                if (sessionData == null)
                {
                    return default(T);
                }

                object sessionObject = sessionData;
                if (sessionObject == null)
                {
                    return default(T);
                }
                return (T)sessionData;
            }
            catch (Exception)
            {
                return default(T);
            }


        }

        public static T GetSession<T>(this ISession session, string key, T defaultValue)
        {
            try
            {
                object sessionObject = session.GetObject<T>(key);
                if (sessionObject == null)
                {
                    session.SetObject(key, defaultValue);
                }
                return session.GetObject<T>(key);
            }
            catch (Exception)
            {
                return defaultValue;
            }

        }


        public static void SaveSession<T>(this ISession session, string key, T entity)
        {
            try
            {
                session.RemoveSession(key);
                session.SetObject(key, entity);
            }
            catch (Exception)
            {
            }
        }

        public static void RemoveSession(this ISession session, string key)
        {
            try
            {

                session.Remove(key);
            }
            catch (Exception)
            {
            }
        }

    }

}
