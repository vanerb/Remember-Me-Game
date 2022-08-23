using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FIreBullets : MonoBehaviour
{

    [SerializeField]
    public int bulletAmount = 10;

    [SerializeField]
    public float startAngle = 90f, endAngle = 270f;

    private Vector2 bulletMoveDir;

    public float repeatTime;
    public Transform player;

    

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Fire", 0f, repeatTime);
       
    }

   

    private void Fire()
    {
        float angleStep = (endAngle - startAngle) / bulletAmount;
        float angle = startAngle;

        for(int i = 0; i < bulletAmount + 1; i++)
        {
            if (player.transform.position.x > transform.position.x)
            {
                float bulDirx = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
                float bulDiry = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);

                Vector3 bullMoveVector = new Vector3(bulDirx, bulDiry, 0f);
                Vector2 bulDir = (bullMoveVector - transform.position).normalized;

                GameObject bul = BulletPool.bulletPoolInstance.GetBullet();
                bul.transform.position = transform.position;
                bul.transform.rotation = transform.rotation;
                bul.SetActive(true);
                bul.GetComponent<BulletDIrections>().SetMoveDir(bulDir);

                angle += angleStep;
            }

            else
            {
                float bulDirx = transform.position.x + Mathf.Sin((angle * Mathf.PI) / -180f);
                float bulDiry = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);

                Vector3 bullMoveVector = new Vector3(bulDirx, bulDiry, 0f);
                Vector2 bulDir = (bullMoveVector - transform.position).normalized;

                GameObject bul = BulletPool.bulletPoolInstance.GetBullet();
                bul.transform.position = transform.position;
                bul.transform.rotation = transform.rotation;
                bul.SetActive(true);
                bul.GetComponent<BulletDIrections>().SetMoveDir(bulDir);

                angle += angleStep;
            }
          
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
