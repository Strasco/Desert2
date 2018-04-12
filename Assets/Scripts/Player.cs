using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    private Rigidbody2D _rb;
    private float _move;
    private bool facingRight;
    [SerializeField]
    private float _jumpForce;
    private bool canDoubleJump;
    [SerializeField]
    private KunaiBehaviour _kunai;
    
    [SerializeField]
    private float fireRate = 0.1f;
    private float canFire = 0.0f;
    
    public float damagePower;

    [SerializeField]
    private float hitPoints;
    [SerializeField]
    private AudioSource _source;
    private GameManager gm;
    private Animator anim;


    private bool isDead;

    [SerializeField]
    public int playerNumber;

    private GameManager gameManager;
    // Use this for initialization
    void Start()
    {
        this.hitPoints = 100;
        _rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        facingRight = transform.localScale.x != -1;
        canDoubleJump = false;
        _source = GetComponent<AudioSource>();

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

        Movement();
        Attack();

    }

    void FixedUpdate()
    {
        if (_move != 0)
        {
            anim.SetBool("moving", true);
        }
        else
        {
            anim.SetBool("moving", false);
        }
        _rb.velocity = new Vector2(_move * _speed, _rb.velocity.y);
     }
    void Flip()
    {
        //Flipping the character by inverting the x-scale.
        facingRight = !facingRight;
        transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
    }

    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.tag == "Platform" || col.gameObject.tag == "Kunai")
        {
            Debug.Log(this.tag + " Collided with " + col.transform.tag);
            canDoubleJump = false;
            anim.SetBool("grounded", true);

        }
    }

    void OnCollisionStay2D(Collision2D col)
    {

        if (col.gameObject.tag == "Kunai")
        {
            canDoubleJump = false;
            anim.SetBool("grounded", true);

        }
    }
    void OnCollisionExit2D(Collision2D col)
    {
        if(col.gameObject.tag == "Platform")
        {
            anim.SetBool("grounded", false);
        }
        
    }


    void Movement()
    {

        if (transform.position.x < -8.3f)
        {
            transform.position = new Vector2(-8.3f, transform.position.y);
        }
        else if (transform.position.x > 8.41f)
        {
            transform.position = new Vector2(8.41f, transform.position.y);
        }

        if (!isDead)
        {
            if (this.tag == "Player")
            {
                _move = Input.GetAxis("K_Horizontal"+playerNumber);
                
                if (_move > 0 && !facingRight) Flip();
                else if (_move < 0 && facingRight) Flip();

                if (Input.GetButtonDown("K_Jump" + playerNumber))
                {
                    if (anim.GetBool("grounded"))
                    {
                        _rb.velocity = new Vector2(_rb.velocity.x, _jumpForce);
                        anim.SetTrigger("Jump");
                        anim.SetBool("grounded", false);
                        canDoubleJump = true;
                    }
                    else
                    {
                        if (canDoubleJump)
                        {
                            
                            _rb.velocity = new Vector2(_rb.velocity.x, _jumpForce);
                            canDoubleJump = false;
                            anim.SetTrigger("Jump");
                            anim.SetBool("grounded", false);
                        }
                    }
                }

            }
           
        }


    }
    void Attack()

    {

        if (!anim.GetBool("isDead"))
        {
            if (this.tag == "Player")
            {
                if (Input.GetButtonDown("K_Fire" + playerNumber) && Time.time > canFire)
                {
                    anim.SetTrigger("throw");
                    _source.Play();

                    if (facingRight)
                    {
                        Vector2 v2 = new Vector2(transform.position.x + 1f, transform.position.y);
                        
                        KunaiBehaviour kunai = (KunaiBehaviour)Instantiate(_kunai, v2, Quaternion.Euler(new Vector3(0, 0, -90)));
                        kunai.dmg = damagePower;

                    }
                    else
                    {
                        Vector2 v2 = new Vector2(transform.position.x - 1f, transform.position.y);
                        KunaiBehaviour kunai =(KunaiBehaviour) Instantiate(_kunai, v2, Quaternion.Euler(new Vector3(0, 0, 90f)));
                        kunai.dmg = damagePower;
                        
                        


                    }
                    canFire = Time.time + fireRate;
                }
            }
            
        }
    }

    public void decreaseLife(float dmg)
    {
        if (!isDead) { 
        Debug.Log(this.tag + " has" + hitPoints + " hitpoints left");
        hitPoints -= dmg;
        Transform child = this.gameObject.transform.GetChild(0);
        child.localScale = new Vector2(child.localScale.x - (dmg/100f), child.localScale.y);
            Debug.Log(damagePower / 10);
        if (hitPoints <= 0)
        {
            gameManager.notFighting = true;
            gameManager.deadCount++;
            gameManager.Restart();
            anim.SetBool("isDead", true);
            child.localScale = new Vector2(0f, 0f);
                isDead = true;
            
        }
        }
    }



}

