using UnityEngine;

public class FlippinDashboard : MonoBehaviour 
{
    HeadGesture gesture;
    GameObject dashboard;
    bool isOpen = true;
    Vector3 startRotation;

    #region MonoBehaviour

    void Start () 
    {
        gesture = GetComponent<HeadGesture>();
        dashboard = GameObject.Find("Dashboard");
        startRotation = dashboard.transform.eulerAngles;
        CloseDashboard();
    }
	
    void Update () 
    {
        if (gesture.isFacingDown)
        {
            OpenDashboard();
        }
        else
        {
            CloseDashboard();
        }
    }
	
    #endregion

    private void CloseDashboard()
    {
        if (isOpen)
        {
            dashboard.transform.eulerAngles = new Vector3(180, startRotation.y, startRotation.z);
            isOpen = false;
        }
    }

    private void OpenDashboard()
    {
        if (!isOpen)
        {
            dashboard.transform.eulerAngles = startRotation;
            isOpen = true;
        }
    }
}
