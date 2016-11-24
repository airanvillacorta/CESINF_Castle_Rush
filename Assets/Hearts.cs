using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Hearts : MonoBehaviour {

    public Sprite[] HeartsSprites;
    public Image HeartUI;
    private Player player;
	// Use this for initialization
	void Start () {

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {

        HeartUI.sprite = HeartsSprites[player.currentHealth];
	}
}
