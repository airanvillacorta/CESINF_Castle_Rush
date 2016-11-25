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
        }
        else
        {
            PlayerPrefs.SetInt("Coins", GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().coins);
            PlayerPrefs.SetInt("Hearts", GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().currentHealth);
        }
         

    }
	
}
