using System.Collections;
using UnityEngine;

public class RandomPosition : MonoBehaviour
{
    public GameObject centerObject;
    public float radius = 10;

    void Start()
    {
        StartCoroutine("RePositionWithDelay");
    }

    IEnumerator RePositionWithDelay()
    {
        while (true)
        {
            SetRandomPosition();
            yield return new WaitForSeconds(20);
        }
    }

    void SetRandomPosition()
    {
        float alfa = Random.Range(0, 2 * Mathf.PI);
        float x = radius * Mathf.Sin(alfa) + centerObject.transform.position.x;
        float z = radius * Mathf.Cos(alfa) + centerObject.transform.position.z;
        transform.position = new Vector3(x, centerObject.transform.position.y, z);

        // Для отладки.
        /*float x = Random.Range(0, 0.5f) + transform.position.x;
        float z = Random.Range(0, 0.5f) + transform.position.z;
        transform.position = new Vector3(x, 1.5f, z);*/
    }

    void Restart()
    {
        StopCoroutine("RePositionWithDelay");
        StartCoroutine("RePositionWithDelay");
    }
}