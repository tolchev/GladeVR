using UnityEngine;

public class HeadGesture : MonoBehaviour 
{
    public bool isFacingDown = false;
    public bool isMovingDown = false;

    private float sweepRate = 100;
    private float previousCameraAngle;

    #region MonoBehaviour

    private void Start()
    {
        previousCameraAngle = CameraAngleFromGround();
    }

    void Update () 
    {
        isFacingDown = DetectFacingDown();
        isMovingDown = DetectMovingDown();
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

    private bool DetectMovingDown()
    {
        float angle = CameraAngleFromGround();
        float deltaAngle = previousCameraAngle - angle;
        float rate = deltaAngle / Time.deltaTime;
        previousCameraAngle = angle;
        return rate >= sweepRate;
    }
}