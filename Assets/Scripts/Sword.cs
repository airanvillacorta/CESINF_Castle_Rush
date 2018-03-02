
using UnityEngine;
using System.Collections;

public class Sword : MonoBehaviour
{

    private Player player;
    private AISword aisword;

    void Start()
    {
		
			
        aisword = transform.parent.GetComponent<AISword>();
		if(!aisword.menu)
			player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.CompareTag("Player") || col.CompareTag("GroundCheck"))
        {

            player.Damage(1);

            StartCoroutine(player.Knockback(0.05f, 350,transform.position));

        }
        if (col.CompareTag("Wall") || col.CompareTag("Player") || col.CompareTag("GroundCheck") )
        {

            aisword.isLeft = !aisword.isLeft;

        }

    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Wall") )
        {

            aisword.isLeft = !aisword.isLeft;

        }

    }



}