using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LoadBackground : MonoBehaviour
{
    public string imagesFolderPath = "Images"; 
    private List<Texture2D> textures = new List<Texture2D>(); 
    private int currentImageIndex = 0; 

    void Start()
    {
        LoadTexturesFromFolder(imagesFolderPath);
        if (textures.Count > 0)
        {
            UpdateBackgroundTexture(textures[currentImageIndex]);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentImageIndex = (currentImageIndex + 1) % textures.Count;
            UpdateBackgroundTexture(textures[currentImageIndex]);
        }
    }

    void LoadTexturesFromFolder(string folderPath)
    {
        string[] filePaths = Directory.GetFiles(folderPath);
        foreach (string path in filePaths)
        {
            byte[] imgData = File.ReadAllBytes(path);
            Texture2D texture = new Texture2D(0, 0, TextureFormat.RGB24, false);
            texture.LoadImage(imgData);
            texture.Apply();
            textures.Add(texture);
        }
    }

    void UpdateBackgroundTexture(Texture2D texture)
    {
        GetComponent<MeshRenderer>().material.mainTexture = texture;
    }
}