using UnityEngine;

public class DestroyTimeout : MonoBehaviour
{
    public float timer = 5f;
    
    void Start()
    {
        Destroy(gameObject, timer);
    }
}