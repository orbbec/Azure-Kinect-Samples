using Microsoft.Azure.Kinect.BodyTracking;
using Microsoft.Azure.Kinect.Sensor;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using UnityEngine;

public class DepthDataProvider : BackgroundDataProvider
{
    public DepthDataProvider(int id) : base(id)
    {
        
    }

    protected override void RunBackgroundThreadAsync(int id, CancellationToken token)
    {
        throw new NotImplementedException();
    }
}