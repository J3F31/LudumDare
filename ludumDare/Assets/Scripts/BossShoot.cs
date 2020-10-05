using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShoot : MonoBehaviour
{
    [SerializeField]
    private int bulletsAmount1 = 10;
    [SerializeField]
    private int bulletsAmount2 = 10;

    [SerializeField]
    private float startAngle1 = 90f, endAngle1 = 270f;
    [SerializeField]
    private float startAngle2 = 90f, endAngle2 = 270f;

    private Vector2 bulletMoveDirection;

    private int counter;
    public int stage;
    public int timeInStage;
    public AudioSource audioSource;
    void Start()
    {
        InvokeRepeating("Fire", 0f, 1.2f);
        stage = 1;
    }

    private void Fire()
    {
        
        counter ++;
    
        if (counter >= timeInStage)
        {
            stage ++;
            counter = 0;
        }
        if (stage == 3)
        {
            stage = 1;
        }
        if (stage == 1)
        {
            _Stage1();
        }
        if (stage == 2)
        {
            _Stage2();
        }
    }
    void _Stage1()
    {

        float angleStep1 = (endAngle1 - startAngle1) / bulletsAmount1;
        float angle1 = startAngle1;

        for (int i = 0; i < bulletsAmount1 + 1; i++)
        {
            float bulDirX = transform.position.x + Mathf.Sin((angle1 * Mathf.PI) / 180f);
            float bulDirY = transform.position.y + Mathf.Cos((angle1 * Mathf.PI) / 180f);

            Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
            Vector2 bulDir = (bulMoveVector - transform.position).normalized;

            GameObject bul = BulletPool.bulletPoolInstanse.GetBullet();
                bul.transform.position = transform.position;
                bul.transform.rotation = transform.rotation;
                bul.SetActive(true);
                bul.GetComponent<BossBullet>().SetMoveDirection(bulDir);
            
            angle1 += angleStep1;
        }
        audioSource.Play();
    }

    void _Stage2()
    {
        startAngle2 = Random.Range(0,180);
        float angleStep2 = (endAngle2 - startAngle2) / bulletsAmount2;
        float angle2 = startAngle2;

        for (int i = 0; i < bulletsAmount2 + 1; i++)
        {
            float bulDirX = transform.position.x + Mathf.Sin((angle2 * Mathf.PI) / 180);
            float bulDirY = transform.position.y + Mathf.Cos((angle2 * Mathf.PI) / 180);

            Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
            Vector2 bulDir = (bulMoveVector - transform.position).normalized;

            GameObject bul = BulletPool.bulletPoolInstanse.GetBullet();
                bul.transform.position = transform.position;
                bul.transform.rotation = transform.rotation;
                bul.SetActive(true);
                bul.GetComponent<BossBullet>().SetMoveDirection(bulDir);
            
            angle2 += angleStep2;
        }
        audioSource.Play();
    }
}
