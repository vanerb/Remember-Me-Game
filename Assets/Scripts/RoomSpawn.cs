using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawn : MonoBehaviour
{
    public GameObject[] rooms;
    public static int random;

    // Start is called before the first frame update
    void Start()
    {
        random = Random.Range(0, rooms.Length);
        Instantiate(rooms[random], rooms[random].transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
