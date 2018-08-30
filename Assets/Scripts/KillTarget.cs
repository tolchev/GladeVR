using System.Collections;
using UnityEngine;

public class KillTarget : MonoBehaviour
{
    // Объект для уничтожения.
    public GameObject target;
    // Эмиттер частиц.
    public ParticleSystem hitEffect;
    // Эффект при взрыве.
    public GameObject killEffect;
    // Время для обратного отчета.
    public float timeToSelect = 3;
    // Счет.
    public int score;

    private float countDown;

    void Start()
    {
        score = 0;
        countDown = timeToSelect;
        hitEffect.enableEmission = false;
    }

    void Update()
    {
        Transform camera = Camera.main.transform;
        Ray ray = new Ray(camera.position, camera.rotation * Vector3.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == target)
        {
            if (countDown > 0)
            {
                countDown -= Time.deltaTime;
                hitEffect.transform.position = hit.point;
                hitEffect.enableEmission = true;
            }
            else
            {
                StartCoroutine(StartKillEffect());
                
                score += 1;
                countDown = timeToSelect;
                target.SendMessage("Restart");
            }
        }
        else
        {
            countDown = timeToSelect;
            hitEffect.enableEmission = false;
        }
    }

    private IEnumerator StartKillEffect()
    {
        GameObject killObj = Instantiate(killEffect, target.transform.position, target.transform.rotation);
        yield return new WaitForSeconds(2);
        Destroy(killObj);
    }
}
