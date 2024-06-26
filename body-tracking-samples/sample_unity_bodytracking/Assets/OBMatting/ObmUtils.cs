public class ObmUtils
{
    public static void ConvertYUY2ToRGB24(byte[] yuyv, byte[] rgb, int width, int height)
    {
        int frameSize = width * height * 2;
        int pixelIndex = 0;

        for (int i = 0; i < frameSize; i += 4)
        {
            // YUYV Format
            byte y0 = yuyv[i];
            byte u = yuyv[i + 1];
            byte y1 = yuyv[i + 2];
            byte v = yuyv[i + 3];

            // Convert the first pixel (y0, u, v) to RGB
            ConvertYUVToRGB(y0, u, v, out byte r0, out byte g0, out byte b0);
            rgb[pixelIndex++] = r0;
            rgb[pixelIndex++] = g0;
            rgb[pixelIndex++] = b0;

            // Convert the second pixel (y1, u, v) to RGB
            ConvertYUVToRGB(y1, u, v, out byte r1, out byte g1, out byte b1);
            rgb[pixelIndex++] = r1;
            rgb[pixelIndex++] = g1;
            rgb[pixelIndex++] = b1;
        }
    }

    public static void ConvertYUVToRGB(byte y, byte u, byte v, out byte r, out byte g, out byte b)
    {
        int c = y - 16;
        int d = u - 128;
        int e = v - 128;

        int rTemp = (298 * c + 409 * e + 128) >> 8;
        int gTemp = (298 * c - 100 * d - 208 * e + 128) >> 8;
        int bTemp = (298 * c + 516 * d + 128) >> 8;

        r = (byte)(Clamp(rTemp, 0, 255));
        g = (byte)(Clamp(gTemp, 0, 255));
        b = (byte)(Clamp(bTemp, 0, 255));
    }

    public static int Clamp(int value, int min, int max)
    {
        return (value < min) ? min : (value > max) ? max : value;
    }
}