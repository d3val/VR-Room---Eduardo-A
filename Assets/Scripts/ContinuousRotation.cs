using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinuousRotation : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 10;

    private void Update()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
