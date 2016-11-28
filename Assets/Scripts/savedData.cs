using UnityEngine;
using System.Collections;

public class savedData : MonoBehaviour {
    private Player player;
    public int level;
	// Use this for initialization
	void Start () {
        if (level != 0) {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().coins = PlayerPrefs.GetInt("Coins");
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().currentHealth = PlayerPrefs.GetInt("Hearts");
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().actualPowerUp = PlayerPrefs.GetInt("Power");
        }
        else
        {

            PlayerPrefs.SetInt("Level", 0);
            PlayerPrefs.SetInt("Coins", GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().coins);
            PlayerPrefs.SetInt("Hearts", GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().currentHealth);
            PlayerPrefs.SetInt("Power", GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().actualPowerUp);
        }
         

    }
	
}
