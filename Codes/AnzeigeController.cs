using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AnzeigeController : MonoBehaviour
{
    public static AnzeigeController anzeige;
    public Slider gesundheitSlider;   // Slider für die Gesundheit
    public Slider munitionSlider; // Slider für die Munition
    public TMP_Text gesundheitText;   // Text für die Gesundheit
    public TMP_Text punkteText;       // Text für die Punkte
    public TMP_Text munitionText;     // Text für die Munition


    public void GameOverAnzeigen()
{
    // Zeige eine Game-Over-Meldung
    Debug.Log("Spiel beendet! Game Over."); //Debuggen
}
    private void Awake()
    {
        anzeige = this;

        if (gesundheitSlider == null)
            gesundheitSlider = GetComponentInChildren<Slider>();

        if (gesundheitText == null)
            gesundheitText = transform.Find("GesundheitText")?.GetComponent<TMP_Text>();

        if (punkteText == null)
            punkteText = transform.Find("PunkteText")?.GetComponent<TMP_Text>();

        if (munitionText == null)
            munitionText = transform.Find("MunitionText")?.GetComponent<TMP_Text>();

        if (munitionSlider == null)
        munitionSlider = transform.Find("MunitionSlider")?.GetComponent<Slider>();

    }

    public void GesundheitAktualisieren(int aktuelleGesundheit, int maxGesundheit)
    {
        if (gesundheitSlider != null)
        {
            gesundheitSlider.maxValue = maxGesundheit;
            gesundheitSlider.value = aktuelleGesundheit;
        }

        if (gesundheitText != null)
        {
            gesundheitText.text = aktuelleGesundheit + " / " + maxGesundheit;
        }
    }

    public void PunkteAktualisieren(int punkte)
    {
        if (punkteText != null)
        {
            punkteText.text = "Punkte: " + punkte;
        }
    }

    public void MunitionAktualisieren(int aktuelleMunition, int maxMunition)
{
    if (munitionSlider != null)
    {
        munitionSlider.maxValue = maxMunition;
        munitionSlider.value = aktuelleMunition;
    }
    else
    {
        Debug.LogError("MunitionSlider ist nicht zugewiesen!"); //Debuggen
    }

    if (munitionText != null)
    {
        munitionText.text = aktuelleMunition + " / " + maxMunition;
    }
    else
    {
        Debug.LogError("MunitionText ist nicht zugewiesen!"); //Debuggen
    }
}

}

public static class DebugExtensions
{
    public static void LogReferenzStatus(string name, Object referenz)
    {
        if (referenz != null)
        {
            Debug.Log($"{name} erfolgreich zugewiesen.");
        }
        else
        {
            Debug.LogError($"{name} konnte nicht zugewiesen werden!");
        }
    }

    
}
