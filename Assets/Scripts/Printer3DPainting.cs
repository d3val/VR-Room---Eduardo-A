using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Printer3DPainting : MonoBehaviour
{
    [SerializeField] GameObject meshContainer;
    [SerializeField] Transform bakedMeshesParent;
    [SerializeField] Camera printerCamera;
    [SerializeField] float scaleFactor;
    private Vector3 originalScale;

    // Start is called before the first frame update
    private void Start()
    {
        originalScale = bakedMeshesParent.localScale;
    }

    // Makes a "print" of the currents trail renderers in scene.
    public void MakePrint()
    {
        Clear();
        GameObject[] trialsObjects = GameObject.FindGameObjectsWithTag("Trail");
        foreach (GameObject trail in trialsObjects)
        {
            // Creates a new container that will store the trail mesh.
            GameObject trailMeshContainer = CreateMeshContainer();
            ApplyMeshProperties(trail, trailMeshContainer);
        }

        // Print resize
        bakedMeshesParent.localScale /= scaleFactor;
    }

    // Destroys previous print result ant return to original scale to aviod scale mistakes
    // during the next print.
    private void Clear()
    {
        GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag("Baked Trail");

        foreach (GameObject targetObject in taggedObjects)
            Destroy(targetObject);
        bakedMeshesParent.localScale = originalScale;
    }

    // Applies properties from the original trail renderer to its baked mesh
    private void ApplyMeshProperties(GameObject origin, GameObject tarjet)
    {
        MeshFilter trailMeshFilter = tarjet.GetComponent<MeshFilter>();
        MeshRenderer trailMeshRenderer = tarjet.GetComponent<MeshRenderer>();
        TrailRenderer trailRenderer = origin.GetComponent<TrailRenderer>();

        trailRenderer.BakeMesh(trailMeshFilter.mesh, printerCamera, true);
        trailMeshRenderer.material.color = trailRenderer.endColor;
    }

    public GameObject CreateMeshContainer()
    {
        GameObject newMeshContainer = Instantiate(meshContainer, bakedMeshesParent);
        return newMeshContainer;
    }
}
