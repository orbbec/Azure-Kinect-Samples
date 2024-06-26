using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LoadBackground : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var imgData = File.ReadAllBytes("Images/background.jpg");
        Texture2D texture = new Texture2D(0, 0, TextureFormat.RGB24, false);
        texture.LoadImage(imgData);
        texture.Apply();
        GetComponent<MeshRenderer>().material.mainTexture = texture;
    }
}
