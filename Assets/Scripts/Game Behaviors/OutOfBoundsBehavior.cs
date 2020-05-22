using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBoundsBehavior : MonoBehaviour
{
    [SerializeField]
    private List<Collider> targets;
    [SerializeField]
    private Camera cam;

    private Plane[] planes;

    private void Start()
    {
        planes = GeometryUtility.CalculateFrustumPlanes(cam);
    }

    // Update is called once per frame
    void Update()
    {
        foreach(Collider target in targets)
        {
            if (!target.gameObject.activeInHierarchy)
                continue;

            if(!GeometryUtility.TestPlanesAABB(planes, target.bounds))
            {
                Debug.Log(target.gameObject.name + " is off the screen.");
                target.gameObject.SetActive(false);
            }
        }
    }
}
