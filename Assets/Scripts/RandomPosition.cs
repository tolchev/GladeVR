using System.Collections;
using UnityEngine;

public class RandomPosition : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(RePositionWithDelay());
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
        float x = Random.Range(8, 42);
        float z = Random.Range(8, 42);
        Debug.Log("x, z = " + x.ToString("F2") + ", " + z.ToString("F2"));
        transform.position = new Vector3(x, 0, z);
    }
}