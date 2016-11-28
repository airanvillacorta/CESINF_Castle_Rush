using UnityEngine;
using System.Collections;

public class AISword : MonoBehaviour
{

    public int currentHealth;
    public int maxHealth;

    public float distance;
    public float wakeRange;
    public int speed;
    public bool awake = false;
    
    public Transform target;
    public bool isLeft=true;

    private Rigidbody2D rib2d;
    private Animator animator;



    // Use this for initialization
    void Start()
    {


        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        animator = gameObject.GetComponent<Animator>();
        rib2d = gameObject.GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

        animator.SetFloat("Speed", Mathf.Abs(rib2d.velocity.x));
        RangeCheck();

    }

    void RangeCheck()
    {

        distance = Vector3.Distance(transform.position, target.transform.position);

        if (distance < wakeRange)
        {
            awake = true;

        }
        if (distance > wakeRange)
        {
            awake = false;

        }


        if (awake)
        {
            Move();
        }

        if (currentHealth <= 0)
            Destroy(gameObject);

    }

    public void Move()
    {
        if (isLeft)
        {
            transform.localScale = new Vector3(1, 1, 1);
          
           

                rib2d.AddForce(Vector2.right * -speed);
            
                if (rib2d.velocity.x <= -1f)
                    rib2d.velocity = new Vector2(-1f, rib2d.velocity.y);
            
        }
        else
        {
            transform.localScale = new Vector3(-1, 1, 1);
            rib2d.AddForce(Vector2.right * speed);

            if (rib2d.velocity.x >= 1f)
                rib2d.velocity = new Vector2(1f, rib2d.velocity.y);

            
        }
    }


    public void Damage(int damage)
    {

        currentHealth -= damage;
        gameObject.GetComponent<Animation>().Play("Player_RedFlash");

    }

}
