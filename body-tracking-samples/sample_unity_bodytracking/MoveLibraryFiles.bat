if not exist Assets\Plugins mkdir Assets\Plugins
copy packages\Microsoft.Azure.Kinect.BodyTracking.1.0.0\lib\netstandard2.0\Microsoft.Azure.Kinect.BodyTracking.dll Assets\Plugins
copy packages\Microsoft.Azure.Kinect.BodyTracking.1.0.0\lib\netstandard2.0\Microsoft.Azure.Kinect.BodyTracking.pdb Assets\Plugins
copy packages\Microsoft.Azure.Kinect.BodyTracking.1.0.0\lib\netstandard2.0\Microsoft.Azure.Kinect.BodyTracking.deps.json Assets\Plugins
copy packages\Microsoft.Azure.Kinect.BodyTracking.1.0.0\lib\netstandard2.0\Microsoft.Azure.Kinect.BodyTracking.xml Assets\Plugins
copy packages\Microsoft.Azure.Kinect.Sensor.1.3.0\lib\netstandard2.0\Microsoft.Azure.Kinect.Sensor.dll Assets\Plugins
copy packages\Microsoft.Azure.Kinect.Sensor.1.3.0\lib\netstandard2.0\Microsoft.Azure.Kinect.Sensor.pdb Assets\Plugins
copy packages\Microsoft.Azure.Kinect.Sensor.1.3.0\lib\netstandard2.0\Microsoft.Azure.Kinect.Sensor.deps.json Assets\Plugins
copy packages\Microsoft.Azure.Kinect.Sensor.1.3.0\lib\netstandard2.0\Microsoft.Azure.Kinect.Sensor.xml Assets\Plugins
copy packages\Microsoft.Azure.Kinect.BodyTracking.Dependencies.0.9.1\lib\native\amd64\release\cublas64_100.dll .\
copy packages\Microsoft.Azure.Kinect.BodyTracking.Dependencies.0.9.1\lib\native\amd64\release\cudart64_100.dll .\
copy packages\Microsoft.Azure.Kinect.BodyTracking.Dependencies.0.9.1\lib\native\amd64\release\vcomp140.dll Assets\Plugins
copy packages\System.Buffers.4.4.0\lib\netstandard2.0\System.Buffers.dll Assets\Plugins
copy packages\System.Memory.4.5.3\lib\netstandard2.0\System.Memory.dll Assets\Plugins
copy packages\System.Runtime.CompilerServices.Unsafe.4.5.2\lib\netstandard2.0\System.Runtime.CompilerServices.Unsafe.dll Assets\Plugins
copy packages\System.Reflection.Emit.Lightweight.4.6.0\lib\netstandard2.0\System.Reflection.Emit.Lightweight.dll Assets\Plugins
copy packages\Microsoft.Azure.Kinect.Sensor.1.3.0\lib\native\amd64\release\depthengine_2_0.dll Assets\Plugins
copy packages\Microsoft.Azure.Kinect.Sensor.1.3.0\lib\native\amd64\release\k4a.dll Assets\Plugins
copy packages\Microsoft.Azure.Kinect.Sensor.1.3.0\lib\native\amd64\release\k4arecord.dll Assets\Plugins
copy packages\Microsoft.Azure.Kinect.BodyTracking.Dependencies.cuDNN.0.9.1\lib\native\amd64\release\cudnn64_7.dll .\
copy packages\Microsoft.Azure.Kinect.BodyTracking.1.0.0\lib\native\amd64\release\onnxruntime.dll .\
copy packages\Microsoft.Azure.Kinect.BodyTracking.1.0.0\lib\native\amd64\release\k4abt.dll Assets\Plugins
copy packages\Microsoft.Azure.Kinect.BodyTracking.1.0.0\content\dnn_model_2_0.onnx .\