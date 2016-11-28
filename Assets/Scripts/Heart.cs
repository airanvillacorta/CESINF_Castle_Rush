using UnityEngine;
using System.Collections;

public class Heart : MonoBehaviour
{

    private int value = 2;
    
    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.CompareTag("Player"))
        {

            col.GetComponent<Player>().addHealth(value);


            Destroy(this.gameObject);
        }

        if (col.CompareTag("GroundCheck"))
        {
            col.GetComponentInParent<Player>().addCoins(value);

            Destroy(this.gameObject);
        }

    }
}
