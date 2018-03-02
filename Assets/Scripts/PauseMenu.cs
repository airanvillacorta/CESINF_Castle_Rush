using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour
{

    public GameObject PauseUI;
    public bool Paused = false;

    // Use this for initialization
    void Start()
    {
        PauseUI.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

		if (ETCInput.GetButtonDown("Pause"))
            Paused = !Paused;

        if (Paused)
        {
            PauseUI.SetActive(true);
            Time.timeScale = 0;

        }
        if (!Paused)
        {
            PauseUI.SetActive(false);
            Time.timeScale = 1;

        }

    }
    public void Resume()
    {
        Paused = !Paused;
    }
    public void Restart()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
    public void MainMenu()
    {
        Application.LoadLevel(1);
    }
}
