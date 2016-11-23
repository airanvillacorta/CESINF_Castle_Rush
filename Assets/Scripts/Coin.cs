using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour
{

    public int value = 1;
    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.CompareTag("Player"))
        {

            col.GetComponent<Player>().addCoins(value);


            Destroy(this.gameObject);
        }

        if (col.CompareTag("GroundCheck"))
        {
            col.GetComponentInParent<Player>().addCoins(value);

            Destroy(this.gameObject);
        }

    }
}
