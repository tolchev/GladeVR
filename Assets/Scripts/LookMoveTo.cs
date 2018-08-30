using UnityEngine;

public class LookMoveTo : MonoBehaviour
{
    public GameObject ground;

    void Update()
    {
        Transform camera = Camera.main.transform;

        Debug.DrawRay(camera.position, camera.rotation * Vector3.forward * 100);

        Ray ray = new Ray(camera.position, camera.rotation * Vector3.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            GameObject hitObject = hit.collider.gameObject;
            if (hitObject == ground)
            {
                transform.position = hit.point;
            }
        }
    }
}