using System;

namespace ObmWrapper
{
    public static class Context
    {        
        public static ObmWrapper.Status Initialize(string workingDir = null)
        {
            return ObmNative.obm_initialize(workingDir);
        }

        public static void Terminate()
        {
            ObmNative.obm_terminate();
        }

        public static Status GetVersion(out int major, out int minor, out int patch)
        {
            return ObmNative.obm_get_version(out major, out minor, out patch);
        }

        public static Status SetLicense(string app_key, string app_secret, string auth_code)
        {
            return ObmNative.obm_set_license(app_key, app_secret, auth_code);
        }

        public static bool IsMattingTypeSupport(MattingType type)
        {
            return ObmNative.obm_is_matting_type_support(type);
        }

        public static Status GetAvailableMattingTypes(out MattingType[] types)
        {
            throw new NotImplementedException();
        }
    }
}

