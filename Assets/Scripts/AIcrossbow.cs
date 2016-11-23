using UnityEngine;
using System.Collections;

public class AIcrossbow : MonoBehaviour
{

    public int currentHealth;
    public int maxHealth;

    public float distance;
    public float wakeRange;
    public float shootInterval;
    public float bulletSpeed = 100;
    public float bulletTimer;

    public bool awake = false;
    public bool lookingRight = true;

    public GameObject bullet;
    public Transform target;
    public Transform shootPoint;
    

    void Awake()
    {
        //anim=gameObject.GetComponent<Animator>();

    }


    // Use this for initialization
    void Start()
    {


        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

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


        if (target.transform.position.x - transform.position.x <= -0.001 && awake)
        {
            transform.localScale = new Vector3(1, 1, 1);
            Attack();
        }
        if (target.transform.position.x - transform.position.x >= 0.001 && awake)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            Attack();
        }

        if (currentHealth <= 0)
            Destroy(gameObject);

    }

    public void Attack()
    {
        bulletTimer += Time.deltaTime;

        if (bulletTimer >= shootInterval)
        {
            Vector2 direction = target.transform.position - transform.position;
            direction.Normalize();


            GameObject BulletClone;
            BulletClone = Instantiate(bullet, shootPoint.transform.position, shootPoint.transform.rotation) as GameObject;
            BulletClone.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;

            bulletTimer = 0;



        }
    }


    public void Damage(int damage)
    {

        currentHealth -= damage;
        gameObject.GetComponent<Animation>().Play("Player_RedFlash");

    }

}
