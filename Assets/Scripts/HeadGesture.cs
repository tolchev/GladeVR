using UnityEngine;

public class HeadGesture : MonoBehaviour 
{
    public bool isFacingDown = false;

    #region MonoBehaviour

    void Update () 
    {
        isFacingDown = DetectFacingDown();
    }

    #endregion

    private bool DetectFacingDown()
    {
        return CameraAngleFromGround() < 60;
    }

    private float CameraAngleFromGround()
    {
        return Vector3.Angle(Vector3.down, Camera.main.transform.rotation * Vector3.forward);
    }
}