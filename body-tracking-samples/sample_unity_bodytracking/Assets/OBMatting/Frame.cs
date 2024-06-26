using System;
using System.Runtime.InteropServices;

namespace ObmWrapper
{
    public class Frame : IDisposable
    {
        private IntPtr _frameHandle;

        public Frame(IntPtr frameHandle)
        {
            _frameHandle = frameHandle;
        }

        ~Frame()
        {
            Dispose();
        }

        public void Dispose()
        {
            if (_frameHandle != IntPtr.Zero)
            {
                ObmNative.obm_frame_release(_frameHandle);
                _frameHandle = IntPtr.Zero;
            }
            GC.SuppressFinalize(this);
        }

        public Image GetColor() 
        {
            IntPtr colorHandle = ObmNative.obm_frame_get_color(_frameHandle);
            return new Image(colorHandle);
        }

        public Image GetDepth()
        {
            IntPtr depthHandle = ObmNative.obm_frame_get_depth(_frameHandle);
            return new Image(depthHandle);
        }

        public Image GetMask()
        {
            IntPtr maskHandle = ObmNative.obm_frame_get_mask(_frameHandle);
            return new Image(maskHandle);
        }
    }
}

