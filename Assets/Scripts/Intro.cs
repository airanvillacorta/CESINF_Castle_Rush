using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Intro : MonoBehaviour {
    public MovieTexture movTexture;
    void Start()
    {
        GetComponent<RawImage>().texture = movTexture as MovieTexture;
        movTexture.Play();

        StartCoroutine(Wait(movTexture.duration));
    }

    void Update()
    {

        if (Input.GetButtonDown("Pause"))
            LoadMenu();
    }

    private IEnumerator Wait(float duration)
    {
        
        yield return new WaitForSeconds(duration);

        LoadMenu();
    }

    public void LoadMenu() {

        Application.LoadLevel(1);
    }
}
 
 

    
