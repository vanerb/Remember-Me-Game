using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisapearDialogue : MonoBehaviour
{

    public bool isEnabled;
    public ParticleSystem particleSystem;

    private void Start()
    {
        particleSystem.enableEmission = false;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (FindObjectOfType<DialogueManager>().dialogueCount == 0)
            {
                Debug.Log("DESAPARECE");
                particleSystem.enableEmission = true;
                Invoke("ActivateParticle", 1f);
            }
        }
    }

    public void ActivateParticle()
    {
        Destroy(this.gameObject);
    }
}
