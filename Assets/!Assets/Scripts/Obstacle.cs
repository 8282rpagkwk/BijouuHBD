using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MovingObject
{
    public int damage = 0;
    public Vector2 StartPos;
    public AudioClip hitSound;
    CapsuleCollider2D coll;

    private void Awake()
    {
        coll = GetComponent<CapsuleCollider2D>();
    }

    private void OnEnable()
    {
        transform.position = StartPos;
        coll.enabled = true;
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        DisableMovingObject();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            gm.GetDamage(damage);
            StartCoroutine(gm.Hit());
            gm.audioSource.PlayOneShot(hitSound);
            collision.gameObject.GetComponent<PlayerControl>().hp -= damage;
            coll.enabled = false;
        }
    }
}
