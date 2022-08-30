using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Step : MonoBehaviour
{

    private AudioSource audioSource;
    [SerializeField] AudioClip[] audioclip;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void StepP()
    {
        AudioClip clip = GetRandomClip();
        audioSource.PlayOneShot(clip);
    }

    private AudioClip GetRandomClip()
    {
        int index = Random.Range(0, audioclip.Length - 1);
        return audioclip[index];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
