
using UnityEngine;
using System.Collections;

public class ShopItem : MonoBehaviour
{
    public bool isHeart;// else is power up
    public int powerUpType;
    public int price;
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
                if (isHeart) {

                    if(player.BuyHeart(price))
                        Destroy(this.gameObject);
                }
                else
                {
                    if (player.BuyPowerUp(price,powerUpType))

                        Destroy(this.gameObject);
                }
            }

        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {

            if (Input.GetButtonDown("Up"))
            {
                if (isHeart)
                {

                    if (player.BuyHeart(price))
                        Destroy(this.gameObject);
                }
                else
                {
                   if (player.BuyPowerUp(price, powerUpType))

                        Destroy(this.gameObject);
                }

            }
        }

    }


}
