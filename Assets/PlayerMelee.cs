using UnityEngine;
using System.Collections;

public class PlayerMelee : MonoBehaviour
{

    public int dmg = 1;

    void OnTriggerEnter2D(Collider2D col)
    {

        if (!col.isTrigger && col.CompareTag("Enemy"))
        {


            col.SendMessageUpwards("Damage", dmg);

        }

    }
}
