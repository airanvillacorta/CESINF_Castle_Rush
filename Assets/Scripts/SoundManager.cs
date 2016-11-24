
/// <summary>
/// Sound manager.
/// This script use for manager all sound(bgm,sfx) in game
/// </summary>

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundManager : MonoBehaviour
{

    [System.Serializable]
    public class SoundGroup
    {
        public AudioClip audioClip;
        public string soundName;
    }

    public GameObject camera;
    public AudioSource bgmSound;

    public List<SoundGroup> sound_List = new List<SoundGroup>();

    public static SoundManager instance;

    public void Start()
    {
        instance = this;
        StartCoroutine(StartBGM());
    }

    public void Play()
    {
        bgmSound.Play();

    }
    public void Stop()
    {

        bgmSound.Stop();

    }
    public void PlayUI()
    {

        bgmSound.Play();

    }
    public void StopUI()
    {

        bgmSound.Stop();

    }
    public void PlayingSound(string _soundName)
    {
        AudioSource.PlayClipAtPoint(sound_List[FindSound(_soundName)].audioClip, camera.transform.position);
    }

    private int FindSound(string _soundName)
    {
        int i = 0;
        while (i < sound_List.Count)
        {
            if (sound_List[i].soundName == _soundName)
            {
                return i;
            }
            i++;
        }
        return i;
    }

    void ManageBGM()
    {
        StartCoroutine(StartBGM());
    }

    //Start BGM when loading complete
    IEnumerator StartBGM()
    {
        yield return new WaitForSeconds(0.5f);

   
        bgmSound.Play();
    }

}
