using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KunaiBehaviour : MonoBehaviour
{
    public float direction;
    private float flyingSpeed = 10f;
    private bool hitSomething;
    private Rigidbody2D _rb;
    public bool canDamage;
    public float dmg;

    [SerializeField]
    private AudioClip _clip;
    // Use this for initialization
    void Start()
    {
        canDamage = true;
        _rb = GetComponent<Rigidbody2D>();
        
        hitSomething = false;
        _rb.gravityScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (hitSomething == false)
        {
            if (direction == -1)
            {
                transform.localScale = new Vector2(transform.localScale.x, -transform.localScale.y);
            }
            else if (direction == 1)
            {
                transform.localScale = new Vector2(transform.localScale.x, transform.localScale.y);
            }
            transform.Translate(Vector2.up * direction * Time.deltaTime * flyingSpeed);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log(this.tag + " Collided with " + col.transform.tag);
        

        if (col.transform.tag == "Player" && canDamage == true)
        {
            AudioSource.PlayClipAtPoint(_clip, Camera.main.transform.position, 0.4f);
            Player player = col.gameObject.GetComponent<Player>();
            player.decreaseLife(dmg);
            Destroy(this.gameObject);
            
        }
        canDamage = false;
        _rb.gravityScale = 1;
        hitSomething = true;
        



    }

   
}
