using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Polaroid : MonoBehaviour
{
    public PolaroidCamera cameraObject;
    public MeshRenderer imageRenderer;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (cameraObject != null)
            AttachToCamera();
    }

    public void AttachToCamera()
    {
        transform.position = cameraObject.polaroidExitPoint.position;
        transform.rotation = cameraObject.polaroidExitPoint.rotation;
    }

    public void ReleasePhoto()
    {
        cameraObject = null;
    }

    public void SetImage(Texture2D ImageTexture)
    {
        imageRenderer.material.color = Color.white;
        imageRenderer.material.mainTexture = ImageTexture;
    }
}