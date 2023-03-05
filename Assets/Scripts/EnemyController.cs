using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ApplyForce(Vector2 force)
    {
        StartCoroutine(ApplyForceCoroutine(force));
    }

    private IEnumerator ApplyForceCoroutine(Vector2 force)
    {
        float duration = 0.5f; // Duración de la animación
        float elapsedTime = 0f;
        Vector2 startPosition = transform.position;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / duration;

            // Interpola la posición del enemigo entre su posición inicial y la posición final después del impacto.
            Vector2 nextPosition = startPosition + force * t;
            transform.position = nextPosition;

            yield return null;
        }

        // Restablece la velocidad del NavMeshAgent a 0 después de la animación.
        transform.GetComponent<NavMeshAgent>().velocity = Vector3.zero;
    }





}
