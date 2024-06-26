using System;
using System.Runtime.InteropServices;

namespace ObmWrapper
{
    public class Session : IDisposable
    {
        private IntPtr _sessionHandle;

        public Session(MattingType type, int hint)
        {
            ObmNative.obm_session_create(type, hint, out _sessionHandle);
        }

        ~Session()
        {
            Dispose();
        }

        public void Dispose()
        {
            if (_sessionHandle != IntPtr.Zero)
            {
                ObmNative.obm_session_destroy(_sessionHandle);
                _sessionHandle = IntPtr.Zero;
            }
            GC.SuppressFinalize(this);
        }

        public void SetBackgroundImages(IntPtr bgColorHandle, IntPtr bgDepthHandle)
        {
            ObmNative.obm_session_set_background_images(_sessionHandle, bgColorHandle, bgDepthHandle);
        }

        public Status Process(Image color, Image depth, int distance, out Frame frame)
        {
            Status result = ObmNative.obm_session_process(_sessionHandle, color.NativeHandle, depth.NativeHandle, distance, out IntPtr frameHandle);
            frame = new Frame(frameHandle);
            return result;
        }
    }
}

