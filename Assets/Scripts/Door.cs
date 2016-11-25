using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour
{
    public bool isEnd;
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
                if (isEnd)
                {

                    PlayerPrefs.SetInt("Coins", GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().coins);
                    PlayerPrefs.SetInt("Hearts", GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().currentHealth);
                    Application.LoadLevel(4);
                }
                else {

                    StartCoroutine(player.EnterDoor(isLeft, transform.position.x));
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

                if (isEnd)
                {

                    PlayerPrefs.SetInt("Coins", GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().coins);
                    PlayerPrefs.SetInt("Hearts", GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().currentHealth);
                    Application.LoadLevel(4);
                }
                else
                {

                    StartCoroutine(player.EnterDoor(isLeft, transform.position.x));
                }
            }
        }

    }

   
}
