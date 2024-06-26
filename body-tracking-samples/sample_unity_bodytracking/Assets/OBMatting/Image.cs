using System;
using System.Runtime.InteropServices;

namespace ObmWrapper
{
    public class Image : IDisposable
    {
        private IntPtr _imageHandle;

        public IntPtr NativeHandle
        {
            get
            {
                return _imageHandle;
            }
        }

        public Image(ImageFormat format, int width, int height, int stride, byte[] data)
        {
            ObmNative.obm_image_create(format, width, height, stride, data, out _imageHandle);
        }

        public Image(IntPtr handle)
        {
            _imageHandle = handle;
        }

        ~Image()
        {
            Dispose();
        }

        public void Dispose()
        {
            if (_imageHandle != IntPtr.Zero)
            {
                ObmNative.obm_image_release(_imageHandle);
                _imageHandle = IntPtr.Zero;
            }
            GC.SuppressFinalize(this);
        }

        public IntPtr GetBuffer() => ObmNative.obm_image_get_buffer(_imageHandle);
        public ulong GetSize() => ObmNative.obm_image_get_size(_imageHandle);
        public ImageFormat GetFormat() => ObmNative.obm_image_get_format(_imageHandle);
        public int GetWidth() => ObmNative.obm_image_get_width(_imageHandle);
        public int GetHeight() => ObmNative.obm_image_get_height(_imageHandle);
        public int GetStride() => ObmNative.obm_image_get_stride(_imageHandle);
    }
}

