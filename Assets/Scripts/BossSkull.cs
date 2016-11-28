using UnityEngine;
using System.Collections;

public class BossSkull : MonoBehaviour {

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
    public Transform shootPoint2;
    public Transform shootPoint3;

    public Transform[] teleports;
    private Animator animator;
    private bool shoot;
    public bool death;

    private float attaclCd = 1f;
    private float attackTimer = 0;

    public float teleportTimer = 0;

    public Collider2D attackTrigger;
    void Awake()
    {
        //anim=gameObject.GetComponent<Animator>();


    }




    // Use this for initialization
    void Start()
    {


        animator = gameObject.GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        currentHealth = maxHealth;

        teleportTimer = Random.Range(2, 7);
    }

    // Update is called once per frame
    void Update()
    {

        animator.SetBool("Shoot", shoot);

        animator.SetBool("Death", death);

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


        if (target.transform.position.x - transform.position.x <= -0.001 && awake )
        {
            transform.localScale = new Vector3(1, 1, 1);
            if ( !shoot && !death)
            {
                shoot = true;
                attackTimer = attaclCd;
                attackTrigger.enabled = true;
                Attack();
            }

            if (shoot)
            {
                if (attackTimer > 0)
                {
                    attackTimer -= Time.deltaTime;
                }
                else
                {
                    shoot = false;
                    attackTrigger.enabled = false;
                }


            }
        }
        if (target.transform.position.x - transform.position.x >= 0.001 && awake )
        {
            transform.localScale = new Vector3(-1, 1, 1);
            if (!shoot && !death)
            {
                shoot = true;
                attackTimer = attaclCd;
                attackTrigger.enabled = true;
                Attack();
            }

            if (shoot)
            {
                if (attackTimer > 0)
                {
                    attackTimer -= Time.deltaTime;
                }
                else
                {
                    shoot = false;
                    attackTrigger.enabled = false;
                }


            }
        }

        if (currentHealth <= 0) {

            StartCoroutine(Die());

        }

        if (teleportTimer > 0 )
        {
            teleportTimer -= Time.deltaTime;
        }
        else
        {
            if (!death) { 
            transform.position = teleports[Random.Range(0, teleports.Length)].position;
            teleportTimer = Random.Range(2, 7);
            }
        }


    }
    IEnumerator Die()
    {
        death = true;

        yield return new WaitForSeconds(3f);

        PlayerPrefs.SetInt("Coins", GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().coins);
        PlayerPrefs.SetInt("Hearts", 6);
        PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level")+1);
        Application.LoadLevel(5);
    }
    public void Attack()
    {
        bulletTimer += Time.deltaTime;

     
            
        Vector2 direction = target.transform.position - transform.position;
        direction.Normalize();


        GameObject BulletClone;
        BulletClone = Instantiate(bullet, shootPoint.transform.position, shootPoint.transform.rotation) as GameObject;
        BulletClone.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;

        BulletClone = Instantiate(bullet, shootPoint2.transform.position, shootPoint.transform.rotation) as GameObject;
        BulletClone.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;

        BulletClone = Instantiate(bullet, shootPoint3.transform.position, shootPoint.transform.rotation) as GameObject;
        BulletClone.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;


        bulletTimer = 0;


        
    }


    public void Damage(int damage)
    {

        currentHealth -= damage;
        gameObject.GetComponent<Animation>().Play("Player_RedFlash");

    }
}
