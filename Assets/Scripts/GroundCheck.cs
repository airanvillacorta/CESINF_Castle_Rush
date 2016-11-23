using UnityEngine;
using System.Collections;

public class GroundCheck : MonoBehaviour
{

    private Player player;
    // Use this for initialization
    void Start()
    {

        player = gameObject.GetComponentInParent<Player>();
    }

    // Update is called once per frame


    void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.isTrigger && (col.CompareTag("Ground") || col.CompareTag("Platform")))
        {
            player.grounded = true;
        }

    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (!col.isTrigger && col.CompareTag("Ground"))
        {
            player.grounded = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (!col.isTrigger && (col.CompareTag("Ground") || col.CompareTag("Platform")))
        {
            player.grounded = false;
        }
    }
}
