using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSpawn : MonoBehaviour
{

    
    public int random;
   
   
    
    // Start is called before the first frame update
    void Start()
    {
        random = Random.Range(1, 3);
        
        SceneManager.LoadScene(random);
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
}
