﻿using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public float speed;
    public float spawnTime;
    public string enemy;

    public virtual void Start () 
	{
	}

	public virtual void Move(float mySpeed)
	{
		transform.position += (transform.forward * mySpeed) * Time.deltaTime;
	}

	public virtual void Update () 
	{
        checkSide();

        if (spawnTime > 0)
        {
            spawnTime -= Time.deltaTime;
        }
        else
        {
            DestroyBullet();
        }

        Move(speed);
    }

    public virtual void DestroyBullet()
    {
        Destroy(this.gameObject);
    }

    void checkSide()
    {
        if(transform.forward == new Vector3(0,0,1))
        {
            enemy = "Enemy";
        }
        else
        {
            enemy = "Player";
        }
    }

    void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.tag == enemy)
        {
                other.gameObject.GetComponent<Character>().hp = other.gameObject.GetComponent<Character>().hp - 1;
                DestroyBullet();
        }
    }
}
