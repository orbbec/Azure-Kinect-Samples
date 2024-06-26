using System;
using System.Runtime.InteropServices;

namespace ObmWrapper
{
    public enum Status
    {
        OBM_STATUS_OK = 0,
        OBM_STATUS_INVALID_ARGUMENT = 1,
        OBM_STATUS_INVALID_LICENSE = 2,
        OBM_STATUS_NOT_INITIALIZED = 3,
        OBM_STATUS_NOT_IMPLEMENTED = 4,
    }

    public enum ImageFormat
    {
        OBM_IMAGE_FORMAT_RGB888,
        OBM_IMAGE_FORMAT_RGBA8888,
        OBM_IMAGE_FORMAT_DEPTH16,
        OBM_IMAGE_FORMAT_IR16,
        OBM_IMAGE_FORMAT_GRAY8,
        OBM_IMAGE_FORMAT_MAX
    }

    public enum MattingType
    {
        OBM_MEETING_MATTING = 0,     /**< meeting matting. */
        OBM_PERSON_MATTING = 1,      /**< person matting. */
        OBM_BACKGROUND_MATTING = 2,  /**< background matting. */
        OBM_DRAGON_MATTING = 3,      /**< dragon matting. */
        OBM_IMAGE_MATTING = 4,       /**< image matting. */
        OBM_HALF_PERSON_MATTING = 5, /**< half person matting. */
    }
}