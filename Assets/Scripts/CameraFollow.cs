using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
       target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(target.transform.position.x, target.transform.position.y, -10);
    }

    public void ShakeCamera(float d, float i)
    {
        StartCoroutine(ShakeCameraCoroutine(d,i));
    }

    private IEnumerator ShakeCameraCoroutine(float duration, float intensity)
    {
        Vector3 originalPos = transform.position;
        float elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            float x = Random.Range(-1f, 1f) * intensity;
            float y = Random.Range(-1f, 1f) * intensity;
            transform.position = originalPos + new Vector3(x, y, 0f);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.position = originalPos;
    }
}
