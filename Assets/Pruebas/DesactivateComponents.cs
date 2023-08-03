using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesactivateComponents : MonoBehaviour
{
    public float detectionRange = 10f;

    private void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);

            if (distance <= detectionRange)
            {
                enemy.GetComponent<Animator>().enabled = true;
            }
            else
            {
                enemy.GetComponent<Animator>().enabled = false;
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        // Dibujar un gizmo esférico para visualizar el rango de detección en el editor.
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}
