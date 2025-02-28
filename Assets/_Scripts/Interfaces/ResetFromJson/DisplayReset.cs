using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

public class DisplayReset : MonoBehaviour
{
    // Komponenty TextMeshPro przypisane z Inspektora
    public TextMeshProUGUI resolution;    // Tekst dla informacji o rozdzielczości
    public TextMeshProUGUI refreshRate;    // Tekst dla informacji o częstotliwości odświeżania
    public TextMeshProUGUI brightness; // Tekst dla informacji o jasności
    public TextMeshProUGUI contrast;    // Tekst dla informacji o kontraście
    public TextMeshProUGUI gamma;    // Tekst dla informacji o gamma
    public TextMeshProUGUI displayGuides; // Tekst dla informacji czy wyświetlać samouczek
    public TextMeshProUGUI displayHints;    // Tekst dla informacji czy wyświetlać podpowiedzi

    // Klasa zarządzająca ustawieniami
    private SettingsDataSerialization settingsManager;
    public ResolutionsController resolutionsController; // Referencja do ResolutionsController

    void Start()
    {
        // Znalezienie SettingsDataSerialization i zaktualizowanie UI na podstawie obecnych ustawień
        settingsManager = FindObjectOfType<SettingsDataSerialization>();
        if (resolutionsController == null)
        {
            // Próba znalezienia ResolutionsController w scenie
            resolutionsController = FindObjectOfType<ResolutionsController>();
        }
    }

    private void OnMouseDown()
    {
        if (!AudioSystem.Instance.audioSources.effectsAudioSource.isPlaying)
        {
            AudioSystem.Instance.PlaySound(AudioSystem.Instance.audioSources.effectsAudioSource, AudioSystem.Instance.buttonForwardSound, false);
        }
        // Debug.Log("DisplayReset");
        // Wyświetlenie informacji o rozdzielczości
        if (resolutionsController != null)
        {
            resolutionsController.SetSelectedResolution(settingsManager.settingsData.defaults.displayDefault.resolution);
        }

        // Wyświetlanie informacji o częstotliwości odświeżania
        refreshRate.text = (settingsManager.settingsData.defaults.displayDefault.refreshRate).ToString("F0") + " Hz";

        // Wyświetlanie informacji o jasności
        brightness.text = (settingsManager.settingsData.defaults.displayDefault.brightness * 100).ToString("F0") + "%";

        // Wyświetlanie informacji o kontraście
        contrast.text = (settingsManager.settingsData.defaults.displayDefault.contrast * 100).ToString("F0") + "%";

        // Wyświetlanie informacji o gamma
        gamma.text = (settingsManager.settingsData.defaults.displayDefault.gamma * 100).ToString("F0") + "%";

        // Wyświetlenie informacji czy wyświetlać samouczek
        displayGuides.text = settingsManager.settingsData.defaults.displayDefault.displayGuides ? "TAK" : "NIE";

        // Wyświetlenie informacji czy wyświetlać podpowiedzi 
        displayHints.text = settingsManager.settingsData.defaults.displayDefault.displayHints ? "TAK" : "NIE";

    }
}
