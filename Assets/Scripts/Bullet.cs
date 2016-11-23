using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{


    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.CompareTag("Player"))
        {

            col.GetComponent<Player>().Damage(1);


            Destroy(this.gameObject);
        }

        if (col.CompareTag("GroundCheck"))
        {
            col.GetComponentInParent<Player>().Damage(1);


            Destroy(this.gameObject);
        }
        if (col.CompareTag("Wall"))
        {
            Destroy(this.gameObject);
        }

    }
}
