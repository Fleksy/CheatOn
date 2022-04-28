using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingScript : MonoBehaviour
{
    public Transform MainMenu;
    public Slider slider;

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape)) { Back(); };
    }
    public void FullScreen()
    {

        Screen.fullScreen = !Screen.fullScreen;
    }
     void Back()
    {
        MainMenu.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
    public AudioMixer GameMixer;
    public void AudioVolume()
    {
        GameMixer.SetFloat("GameMixer", slider.value);
    }
}
