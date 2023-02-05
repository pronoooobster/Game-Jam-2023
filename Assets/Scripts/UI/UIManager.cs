using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : SingletonPersistent<UIManager>
{
    /*
     * Game Panels Indexes:
     *       0. Main Menu
     *       1. How To Play
     *       2. Game Over
     */

    [Header("UI Panels References")]
    public GameObject[] gamePanels;

    [Header("Sound Panel References")]
    public Slider masterSlider;
    public Slider musicSlider;
    public Slider ambienceSlider;
    public Slider soundEffectsSlider;

    private void Start()
    {
        masterSlider.onValueChanged.AddListener(delegate { MasterValueChanged(); });
        musicSlider.onValueChanged.AddListener(delegate { MusicValueChanged(); });
        ambienceSlider.onValueChanged.AddListener(delegate { AmbienceValueChanged(); });
        soundEffectsSlider.onValueChanged.AddListener(delegate { SoundsValueChanged(); });
    }

    #region Main Menu and Pause Panels
    public void ShowUpPanel(int index)
    {
        for (int i = 0; i < gamePanels.Length; i++)
        {
            bool setActive = i == index;

            gamePanels[i].SetActive(setActive);
        }
    }

    public void ShowMainMenuPanel()
    {
        ShowUpPanel(0);
    }

    public void ShowHowToPlayPanel()
    {
        ShowUpPanel(1);
    }

    public void ShowSoundsPanel()
    {
        ShowUpPanel(2);
    }

    public IEnumerator ShowGameOverPanel()
    {
        yield return new WaitForSecondsRealtime(0.5f);

        ShowUpPanel(2);
    }

    public void TogglePausePanel()
    {
        GameManager.Instance.ToggleGamePause();
    }
    #endregion

    #region Sound Effects Panel

    public void MasterValueChanged()
    {
        SoundManager.Instance.SetMasterVolume(masterSlider.value);
    }

    public void MusicValueChanged()
    {
        SoundManager.Instance.SetMusicVolume(musicSlider.value);

    }
    public void AmbienceValueChanged()
    {
        SoundManager.Instance.SetAmbienceVolume(ambienceSlider.value);

    }
    public void SoundsValueChanged()
    {
        SoundManager.Instance.SetSoundEffectsVolume(soundEffectsSlider.value);

    }

    public void SetMasterVolume(float volume)
    {
        Debug.Log("Master Volume " + volume);
        //GameManager.Instance.SetVolume("MasterVolume", volume);
    }

    public void SetMusicVolume(float volume)
    {
        Debug.Log("Music Volume " + volume);
        //GameManager.Instance.SetVolume("MusicVolume", volume);
    }

    public void SetSFXVolume(float volume)
    {
        Debug.Log("SFX Volume " + volume);

        //GameManager.Instance.SetVolume("SFXVolume", volume);
    }
    public void SetAmbienceVolume(float volume)
    {
        Debug.Log("Ambience Volume " + volume);

        //GameManager.Instance.SetVolume("SFXVolume", volume);
    }
    #endregion

    public void LoadLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }

    public void RestartLevel()
    {
        GameManager.Instance.RestartLevel();
    }

    public void YouTubeLink()
    {
        Application.OpenURL("https://www.youtube.com/MultsElMesco");
    }
}
