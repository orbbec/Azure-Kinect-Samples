using System;
using System.Runtime.InteropServices;

namespace ObmWrapper
{
class ObmNative
{
    private const string obm = "obm";

    [DllImport(obm, CallingConvention = CallingConvention.Cdecl)]
    public static extern Status obm_initialize(string working_directory);

    [DllImport(obm, CallingConvention = CallingConvention.Cdecl)]
    public static extern void obm_terminate();

    [DllImport(obm, CallingConvention = CallingConvention.Cdecl)]
    public static extern Status obm_get_version(out int major, out int minor, out int patch);

    [DllImport(obm, CallingConvention = CallingConvention.Cdecl)]
    public static extern Status obm_set_license(string app_key, string app_secret, string auth_code);

    [DllImport(obm, CallingConvention = CallingConvention.Cdecl)]
    public static extern Status obm_image_create(ImageFormat format, int width_pixels, int height_pixels, int stride_bytes, byte[] data, out IntPtr image_handle);

    [DllImport(obm, CallingConvention = CallingConvention.Cdecl)]
    public static extern void obm_image_reference(IntPtr image_handle);

    [DllImport(obm, CallingConvention = CallingConvention.Cdecl)]
    public static extern void obm_image_release(IntPtr image_handle);

    [DllImport(obm, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr obm_image_get_buffer(IntPtr image_handle);

    [DllImport(obm, CallingConvention = CallingConvention.Cdecl)]
    public static extern ulong obm_image_get_size(IntPtr image_handle);

    [DllImport(obm, CallingConvention = CallingConvention.Cdecl)]
    public static extern ImageFormat obm_image_get_format(IntPtr image_handle);

    [DllImport(obm, CallingConvention = CallingConvention.Cdecl)]
    public static extern int obm_image_get_width(IntPtr image_handle);

    [DllImport(obm, CallingConvention = CallingConvention.Cdecl)]
    public static extern int obm_image_get_height(IntPtr image_handle);

    [DllImport(obm, CallingConvention = CallingConvention.Cdecl)]
    public static extern int obm_image_get_stride(IntPtr image_handle);

    [DllImport(obm, CallingConvention = CallingConvention.Cdecl)]
    public static extern void obm_frame_reference(IntPtr frame_handle);

    [DllImport(obm, CallingConvention = CallingConvention.Cdecl)]
    public static extern void obm_frame_release(IntPtr frame_handle);

    [DllImport(obm, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr obm_frame_get_color(IntPtr frame_handle);

    [DllImport(obm, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr obm_frame_get_depth(IntPtr frame_handle);

    [DllImport(obm, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr obm_frame_get_mask(IntPtr frame_handle);

    [DllImport(obm, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool obm_is_matting_type_support(MattingType type);

    // [DllImport(obm, CallingConvention = CallingConvention.Cdecl)]
    // public static extern Status obm_get_available_matting_types(out MattingType[] types, out int count);

    [DllImport(obm, CallingConvention = CallingConvention.Cdecl)]
    public static extern Status obm_session_create(MattingType type, int hint, out IntPtr session_handle);

    [DllImport(obm, CallingConvention = CallingConvention.Cdecl)]
    public static extern void obm_session_set_background_images(IntPtr session_handle, IntPtr bg_color_handle, IntPtr bg_depth_handle);

    [DllImport(obm, CallingConvention = CallingConvention.Cdecl)]
    public static extern void obm_session_destroy(IntPtr session_handle);

    [DllImport(obm, CallingConvention = CallingConvention.Cdecl)]
    public static extern Status obm_session_process(IntPtr session_handle, IntPtr color_handle, IntPtr depth_handle, int distance, out IntPtr frame_handle);
}
}
