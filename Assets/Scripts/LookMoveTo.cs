using UnityEngine;
using UnityEngine.UI;

public class LookMoveTo : MonoBehaviour
{
    public GameObject ground;
    public Transform infoBubble;
    private Text infoText;

    void Start()
    {
        if (infoBubble != null)
        {
            infoText = infoBubble.Find("Text").GetComponent<Text>();
        }
    }

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
                if (infoBubble != null)
                {
                    infoText.text = string.Format("X: {0}, Z: {1}", hit.point.x.ToString("F2"), hit.point.z.ToString("F2"));
                    infoBubble.LookAt(camera.position);
                    // После LookAt() сообщение будет развернуто в направлении от нас.
                    infoBubble.Rotate(0, 180, 0);
                }

                transform.position = hit.point;
            }
        }
    }
}