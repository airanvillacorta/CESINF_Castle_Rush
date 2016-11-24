using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float MaxSpeed = 1f;
    public float speed = 15f;
    public float jumpPower = 15f;
    public bool grounded;
    private bool attacking = false;
    private bool doorIn = false;
    private bool doorOut = false;
    private bool dead = false;
    private float attackTimer = 0;
    private float attaclCd = 0.3f;

    public Collider2D attackTrigger;
    //public Collider2D playerCollectTrigger;

    public int currentHealth;
    public int maxHealth;

    private Rigidbody2D rib2d;
    private Animator animator;

    public int coins = 0;
    public Text coinsText;

    public float shootInterval;
    public float bulletSpeed = 100;
    public float bulletTimer;

    public GameObject bullet;

    private bool isLeftDoor;
    private float timer = 0;

    // Use this for initialization
    void Awake()
    {
        attackTrigger.enabled = false;

    }



    void Start()
    {
        rib2d = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

        animator.SetBool("Grounded", grounded);
        animator.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal")));
        animator.SetBool("Throw", attacking);
        animator.SetBool("DoorIn", doorIn);
        animator.SetBool("DoorOut", doorOut);

        animator.SetBool("Dead", dead);
        if (Input.GetAxis("Horizontal") < -0.1f && !doorIn && !doorOut && !dead)
            transform.localScale = new Vector3(1, 1, 1);
        if (Input.GetAxis("Horizontal") > 0.1f && !doorIn && !doorOut && !dead)
            transform.localScale = new Vector3(-1, 1, 1);

        if (Input.GetButtonDown("Jump") && grounded && !doorIn && !doorOut && !dead)
        {
            rib2d.AddForce(Vector2.up * jumpPower);
        }

        if (currentHealth > maxHealth)
            currentHealth = maxHealth;
        if (currentHealth <= 0)
            StartCoroutine(Die());



        if (Input.GetButtonDown("Fire1") && !attacking && !doorIn && !doorOut && !dead)
        {
            attacking = true;
            attackTimer = attaclCd;
            attackTrigger.enabled = true;
            if (coins >= 1)
            {
                Throw();
                coins -= 1;
            }
        }

        if (attacking)
        {
            if (attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;
            }
            else
            {
                attacking = false;
                attackTrigger.enabled = false;
            }


        }

        if (doorIn)
        {

            if (0.3f > timer)
            {

                timer += Time.deltaTime;
            }
            else
            {
                if (isLeftDoor)
                {
                    transform.position = new Vector3(transform.position.x - 0.8f, transform.position.y, 0.5f);
                }
                else
                {
                    transform.position = new Vector3(transform.position.x + 0.8f, transform.position.y, 0.5f);
                }
                doorOut = true;
                doorIn = false;

                animator.SetBool("DoorIn", doorIn);
                animator.SetBool("DoorOut", doorOut);
                animator.Play("DoorOut");
                timer = 0;

            }

        }

        if (doorOut)
        {


            if (0.3f > timer)
            {

                timer += Time.deltaTime;
            }
            else
            {

                doorOut = false;
                timer = 0;
            }
        }


        coinsText.text = (coins.ToString());

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (!doorIn && !doorOut && !dead)
        {
            float h = Input.GetAxis("Horizontal");

            rib2d.AddForce(Vector2.right * speed * h);
           if (rib2d.velocity.x >= MaxSpeed)
                rib2d.velocity = new Vector2(MaxSpeed, rib2d.velocity.y);

            if (rib2d.velocity.x <= -MaxSpeed)
                rib2d.velocity = new Vector2(-MaxSpeed, rib2d.velocity.y);
        }

    }

    IEnumerator Die()
    {
        dead = true;

        yield return new WaitForSeconds(2f);
        Application.LoadLevel(3);
    }

    public void Damage(int dmg)
    {
        if (!doorIn && !doorOut && !dead)
        {
            if (currentHealth - dmg > 0)
            {
                currentHealth -= dmg;
            }
            else {
                currentHealth = 0;
            }
            gameObject.GetComponent<Animation>().Play("Player_RedFlash");
          
        }

    }


    public IEnumerator Knockback(float knockDur, float knockbackPwr, Vector3 knockbackDir)
    {

        float timer = 0;
        rib2d.velocity = new Vector2(rib2d.velocity.x, 0);
        while (knockDur > timer)
        {

            timer += Time.deltaTime;

            rib2d.AddForce(new Vector3(knockbackDir.x * -20, knockbackDir.y * knockbackPwr, transform.position.z));

        }

        yield return 0;

    }

    public void addCoins(int c)
    {

        coins += c;

    }

    public void Throw()
    {
        bulletTimer += Time.deltaTime;

        /*if(bulletTimer>=shootInterval)
		{*/
        Vector3 pos = new Vector3(transform.position.x, attackTrigger.transform.position.y - 0.1f, 0);
        Vector2 direction = attackTrigger.transform.position - pos;
        direction.Normalize();


        GameObject BulletClone;
        BulletClone = Instantiate(bullet, attackTrigger.transform.position, attackTrigger.transform.rotation) as GameObject;
        BulletClone.GetComponent<Rigidbody2D>().velocity = rib2d.velocity + direction * bulletSpeed;

        bulletTimer = 0;



        //}
    }

    public IEnumerator EnterDoor(bool isLeft, float xCord)
    {

        doorIn = true;
        isLeftDoor = isLeft;

        rib2d.velocity = new Vector2(0, 0);
        transform.position = new Vector3(xCord, transform.position.y, 0.5f);


        yield return 0;
    }

}
