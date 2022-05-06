using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_fighting : MonoBehaviour
{
    public GameObject bullet_prefab;
    private GameObject bullet;
    private Rigidbody2D rigidBody;
    private Vector3 dir;
    private GameObject[] bullets;
    private Vector3 force;

    private GameObject[] BulletCreate(int count, GameObject prefab)
    {
        GameObject[] bullets = new GameObject[count];
        for (int i = 0; i < count; i++)
        {
            bullets[i] = Instantiate(prefab) as GameObject;
            bullets[i].AddComponent<Rigidbody2D>();
        }
        return bullets;
    }

    private void BulletAddForce(ref GameObject[] bullets, Vector3 force)
    {
        Rigidbody2D rb;

        for (int i = 0; i < bullets.Length; i++)
        {
            rb = bullets[i].GetComponent<Rigidbody2D>();
            rb.AddForce(force);
        }
    }
    void Start()
    {
        bullet = Instantiate(bullet_prefab, Vector3.zero, Quaternion.Euler(0, 0, 0)) as GameObject;
        bullet.AddComponent<Rigidbody2D>();
        //bullet.transform.position = transform.TransformPoint(Vector3.forward * 6.4f);
        rigidBody = bullet.GetComponent<Rigidbody2D>();
        bullet.transform.rotation = Quaternion.Euler(0, 0, -90);
        dir.y = 0.55f;
        dir.x = 500.0f;
        
        //bullets = BulletCreate(10, bullet_prefab);
        force = new Vector3(211.0f, 150f, 0);
        rigidBody.AddForce(force);
    }

    void Update()
    {
        if (Time.frameCount % 500 == 0)
        {
            bullet.transform.position = new Vector3(0, 2, 0);
            bullet.transform.rotation = Quaternion.Euler(0, 0, -90);
            rigidBody.AddForce(force);
            //BulletAddForce(ref bullets, force);
        }
    }
}
