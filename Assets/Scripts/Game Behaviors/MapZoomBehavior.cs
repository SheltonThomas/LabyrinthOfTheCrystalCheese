using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapZoomBehavior : MonoBehaviour
{
    public Transform camera;

    // Update is called once per frame
    void Update()
    {
        Vector3 movementDirection = camera.position - gameObject.transform.position;
        movementDirection.Normalize();

        transform.Translate(movementDirection * Time.deltaTime * 5);
    }
}
