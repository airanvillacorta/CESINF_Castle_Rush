
using UnityEngine;
using System.Collections;

public class DamageCollider : MonoBehaviour
{

    private Player player;

    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

    }

    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.CompareTag("Player") || col.CompareTag("GroundCheck"))
        {

            player.Damage(1);

            //StartCoroutine(player.Knockback(0.05f, 350, transform.position));

        }

    }
}