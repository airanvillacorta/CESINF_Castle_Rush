using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour
{

    public bool isLeft;
    private Player player;
    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if (Input.GetButtonDown("Up"))
            {
                StartCoroutine(player.EnterDoor(isLeft, transform.position.x));

            }

        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
			
            if (Input.GetButtonDown("Up"))
            {

                StartCoroutine(player.EnterDoor(isLeft, transform.position.x));
            }
        }

    }

   
}
