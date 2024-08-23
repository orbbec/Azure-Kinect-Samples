using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using AOT;
using Microsoft.Azure.Kinect.Sensor;
using ObmWrapper;
using UnityEngine;
using UnityEngine.UI;

public class OBMattingDemo : MonoBehaviour
{
    public Material maskImageMat;

    private Device device;

    private ObmWrapper.Session session;

    private Texture2D colorTexture;
    private Texture2D maskTexture;


    // Start is called before the first frame update
    void Start()
    {
        ObmWrapper.Context.GetVersion(out int major, out int minor, out int patch);
        Debug.Log(string.Format("Version: {0}.{1}.{2}", major, minor, patch));

        ObmWrapper.Context.SetLicense("20230309299085092", "12ab3cea48cda85525e81d2a78758291d400eb13", "4480e117-69a9-48a0-bddc-443d11d7de31");
        ObmWrapper.Context.Initialize();
        
        session = new ObmWrapper.Session(ObmWrapper.MattingType.OBM_PERSON_MATTING, 0);

        device = Device.Open(0);
        DeviceConfiguration config = new DeviceConfiguration()
        {
            ColorFormat = Microsoft.Azure.Kinect.Sensor.ImageFormat.ColorYUY2,
            ColorResolution = ColorResolution.R720p,
            DepthMode = DepthMode.WFOV_2x2Binned,
            CameraFPS = FPS.FPS30
        };
        device.StartCameras(config);
    }

    void Update()
    {
        var capture = device.GetCapture();
        if (capture != null)
        {
            var color = capture.Color;
            var depth = capture.Depth;
            if (color != null && depth != null)
            {
                var colorData = color.Memory.ToArray();
                if (colorTexture == null)
                {
                    colorTexture = new Texture2D(color.WidthPixels, color.HeightPixels, TextureFormat.RGB24, false);
                }
                var rgbData = new byte[color.WidthPixels * color.HeightPixels * 3];
                ObmUtils.ConvertYUY2ToRGB24(colorData, rgbData, color.WidthPixels, color.HeightPixels);
                colorTexture.LoadRawTextureData(rgbData);
                colorTexture.Apply();

                var depthData = depth.Memory.ToArray();

                ObmWrapper.Image colorImg = new ObmWrapper.Image(ObmWrapper.ImageFormat.OBM_IMAGE_FORMAT_RGB888, color.WidthPixels, color.HeightPixels, 0, rgbData);
                ObmWrapper.Image depthImg = new ObmWrapper.Image(ObmWrapper.ImageFormat.OBM_IMAGE_FORMAT_DEPTH16, depth.WidthPixels, depth.HeightPixels, 0, depthData);
                
                session.Process(colorImg, depthImg, 1000, out ObmWrapper.Frame frame);

                var maskImg = frame.GetMask();
                var outColorImg = frame.GetColor();
                var outDepthImg = frame.GetDepth();
                if(maskTexture == null)
                {
                    maskTexture = new Texture2D(maskImg.GetWidth(), maskImg.GetHeight(), TextureFormat.Alpha8, false);
                }
                maskTexture.LoadRawTextureData(maskImg.GetBuffer(), (int)maskImg.GetSize());
                maskTexture.Apply();

                maskImageMat.SetTexture("_MainTex", colorTexture);
                maskImageMat.SetTexture("_MaskTex", maskTexture);

                colorImg.Dispose();
                depthImg.Dispose();
                maskImg.Dispose();
                outColorImg.Dispose();
                outDepthImg.Dispose();

            }
            if(color != null)
            {
                color.Dispose();
            }
            if(depth != null)
            {
                depth.Dispose();
            }
        }
        capture.Dispose();
    }

    void OnDestroy()
    {
        session.Dispose();

        ObmWrapper.Context.Terminate();

        device.Dispose();
    }
}
