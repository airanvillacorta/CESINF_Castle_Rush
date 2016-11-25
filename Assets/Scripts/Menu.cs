using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

    public GameObject about;
    
    public void Play() {
        Application.LoadLevel(2);

    }
    public void Back() {

        about.SetActive(false);
    }

    public void About()
    {

        about.SetActive(true);

    }
}
