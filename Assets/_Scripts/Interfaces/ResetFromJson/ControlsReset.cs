using System.Globalization;
using TMPro;
using UnityEngine;

public class ControlsReset : MonoBehaviour
{
    // Komponenty TextMeshPro przypisane z Inspektora
    public TextMeshProUGUI mouseSensitivity;    // Tekst dla wyświetlania czułości myszy
    public TextMeshProUGUI autoReload;    // Tekst dla wyświetlania informacji o automatycznym przeładowaniu 
    public TextMeshProUGUI runMode;    // Tekst dla wyświetlania informacji o trybie biegu

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
        // Debug.Log("ControlsReset");
        // Wyświetlanie informacji o trybie biegu
        runMode.text = settingsManager.settingsData.defaults.controlsDefault.runMode;

        // Wyświetlanie czułości myszy z kropką jako separator dziesiętny
        mouseSensitivity.text = settingsManager.settingsData.defaults.controlsDefault.mouseSensitivity.ToString("F1", CultureInfo.InvariantCulture);

        // Wyświetlanie informacji o automatycznym przeładowaniu 
        //autoReload.text = settingsManager.settingsData.defaults.controlsDefault.autoReload ? "TAK" : "NIE";

    }
}
