using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolaroidCamera : MonoBehaviour
{
    [SerializeField] Camera snapshotCamera;
    [SerializeField] Material photoMaterial = null;
    [SerializeField] GameObject polaroidPrefab;
    public Transform polaroidExitPoint;
    private bool isPrinting;

    private void Start()
    {
        isPrinting = false;
    }

    public void Snapshot()
    {
        snapshotCamera.Render();
        // The Render Texture in RenderTexture.active is the one
        // that will be read by ReadPixels.
        RenderTexture.active = snapshotCamera.targetTexture;

        // Render the camera's view.


        // Make a new texture and read the active Render Texture into it.
        Texture2D image = new Texture2D(snapshotCamera.targetTexture.width, snapshotCamera.targetTexture.height, TextureFormat.RGB24, false);
        image.ReadPixels(new Rect(0, 0, snapshotCamera.targetTexture.width, snapshotCamera.targetTexture.height), 0, 0);
        image.Apply();

        // Replace the original active Render Texture.

        PrintPhotograph(image);
    }

    public void PrintPhotograph(Texture2D photoImage)
    {


        GameObject PolaroidPrefab = Instantiate(polaroidPrefab, polaroidExitPoint.position, Quaternion.identity);

        Polaroid currentPolaroid = PolaroidPrefab.GetComponent<Polaroid>();
        currentPolaroid.cameraObject = this;
        currentPolaroid.SetImage(photoImage);

    }

    private void OnValidate()
    {
        Material mat = new Material(Shader.Find("Universal Render Pipeline/Lit"));
        photoMaterial = mat;
    }
}