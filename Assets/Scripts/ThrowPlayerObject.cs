using UnityEngine;
using System.Collections;

public class ThrowPlayerObject : MonoBehaviour
{

    public int damage = 1;
    public float timer = 0;
    public float timeAlive = 4;

    void OnTriggerEnter2D(Collider2D col)
    {

        if (!col.isTrigger && col.CompareTag("Enemy"))
        {


            col.SendMessageUpwards("Damage", damage);
            Destroy(this.gameObject);
        }


		if (col.CompareTag("Wall") ||col.CompareTag("Ground") )
        {
            Destroy(this.gameObject);
        }
    }

    void Update()
    {


        timer += Time.deltaTime;

        if (timer >= timeAlive)
        {

            Destroy(this.gameObject);


        }


    }

}

