using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SoundReset : MonoBehaviour
{
    // Komponenty TextMeshPro przypisane z Inspektora
    public TextMeshProUGUI audioDevice;    // Tekst dla wyświetlania urządzenia audio
    public TextMeshProUGUI musicVolume;    // Tekst dla wyświetlania głośności muzyki (%)
    public TextMeshProUGUI recordsVolume;    // Tekst dla wyświetlania głośności nagrań (%)
    public TextMeshProUGUI effectsVolume;    // Tekst dla wyświetlania głośności efektów (%)

    // Klasa zarządzająca ustawieniami
    private SettingsDataSerialization settingsManager;

    void Start()
    {
        // Znalezienie SettingsDataSerialization i zaktualizowanie UI na podstawie obecnych ustawień
        settingsManager = FindObjectOfType<SettingsDataSerialization>();
    }

    private void OnMouseDown()
    {
        if (!AudioSystem.Instance.audioSources.effectsAudioSource.isPlaying)
        {
            AudioSystem.Instance.PlaySound(AudioSystem.Instance.audioSources.effectsAudioSource, AudioSystem.Instance.buttonForwardSound, false);
        }
        // Debug.Log("SoundReset");
        // Wyświetlanie urządzenia audio
        audioDevice.text = settingsManager.settingsData.defaults.soundDefault.audioDevice;

        // Wyświetlanie głośności muzyki (%)
        musicVolume.text = (settingsManager.settingsData.defaults.soundDefault.musicVolume * 100).ToString("F0") + "%";

        // Wyświetlanie głośności nagrań (%)
        recordsVolume.text = (settingsManager.settingsData.defaults.soundDefault.recordsVolume * 100).ToString("F0") + "%";

        // Wyświetlanie głośności efektów (%)
        effectsVolume.text = (settingsManager.settingsData.defaults.soundDefault.effectsVolume * 100).ToString("F0") + "%";
    }
}
