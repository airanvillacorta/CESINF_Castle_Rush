using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public MovieTexture movTexture;
    void Start()
    {
        GetComponent<RawImage>().texture = movTexture as MovieTexture;
        movTexture.Play();

        StartCoroutine(Wait(movTexture.duration));
    }



    private IEnumerator Wait(float duration)
    {

        yield return new WaitForSeconds(duration);

        LoadGame();
    }

    public void LoadGame()
    {

        Application.LoadLevel(2);
    }
}




