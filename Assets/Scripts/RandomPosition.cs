using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class RandomPosition : MonoBehaviour
{
    public GameObject centerObject;
    public float radius = 5;
    public Transform visorCanvas;
    private Text infoText;

    void Start()
    {
        if (visorCanvas != null)
        {
            infoText = visorCanvas.Find("Text").GetComponent<Text>();
        }

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

        if (visorCanvas != null)
        {
            infoText.text = string.Format("X: {0}, Z: {1}", x.ToString("F2"), z.ToString("F2"));
        }
    }

    void Restart()
    {
        StopCoroutine("RePositionWithDelay");
        StartCoroutine("RePositionWithDelay");
    }
}