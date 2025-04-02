using UnityEngine;

public class SpielerGesundheitPunkteController : MonoBehaviour
{
    public static SpielerGesundheitPunkteController gesundheitPunkteController;

    public int maxGesundheit = 10; // Maximale Gesundheit
    private int aktGesundheit;     // Aktuelle Gesundheit
    private int punkte;            // Punkte des Spielers
    public int maxMunition = 10;   // Maximale Munition
    public int aktMunition;       // Aktuelle Munition

    private void Awake()
    {
        gesundheitPunkteController = this;
    }

    void Start()
    {
        // Gesundheit, Punkte und Munition initialisieren
        aktGesundheit = maxGesundheit;
        punkte = 0;
        aktMunition = maxMunition;

        // Anzeigen initialisieren
        AnzeigeController.anzeige.GesundheitAktualisieren(aktGesundheit, maxGesundheit);
        AnzeigeController.anzeige.MunitionAktualisieren(aktMunition, maxMunition);
        AnzeigeController.anzeige.PunkteAktualisieren(punkte);
    }

    public void Schaden(int schaden)
{
    aktGesundheit -= schaden;

    // Gesundheit darf nicht unter 0 fallen
    if (aktGesundheit < 0)
    {
        aktGesundheit = 0;
    }

    // Anzeige aktualisieren
    AnzeigeController.anzeige.GesundheitAktualisieren(aktGesundheit, maxGesundheit);

    // Überprüfen, ob der Spieler gestorben ist
    if (aktGesundheit <= 0)
    {
        Debug.Log("Game Over!");
        SpielerTod();
    }
}

// Methode für den Tod des Spielers
    private void SpielerTod()
{
    // Spielersteuerung deaktivieren
    PlayerController playerController = GetComponent<PlayerController>();
    if (playerController != null)
    {
        playerController.enabled = false; // Deaktiviert die Bewegung
    }

    // Debuggen
    Debug.Log("Game Over! Spieler ist tot.");
    AnzeigeController.anzeige.GameOverAnzeigen();
}

    public void Heilen(int heilung)
    {
        aktGesundheit += heilung;

        // Gesundheit darf die maximale Gesundheit nicht überschreiten
        if (aktGesundheit > maxGesundheit)
        {
            aktGesundheit = maxGesundheit;
        }

        // Anzeige aktualisieren
        AnzeigeController.anzeige.GesundheitAktualisieren(aktGesundheit, maxGesundheit);
    }

    public void PunkteHinzufuegen(int neuePunkte)
    {
        punkte += neuePunkte;

        // Punkteanzeige aktualisieren
        AnzeigeController.anzeige.PunkteAktualisieren(punkte);

        Debug.Log("Aktuelle Punkte: " + punkte);
    }

    public void MunitionVerbrauchen(int menge)
    {
    aktMunition -= menge;

    // Munition darf nicht negativ werden
    if (aktMunition < 0)
    {
        aktMunition = 0;
    }

    // Munition-Slider aktualisieren
    AnzeigeController.anzeige.MunitionAktualisieren(aktMunition, maxMunition);
    }

public void MunitionAuffuellen(int menge)
    {
    aktMunition += menge;

    // Munition darf maximal die maximale Munition betragen
    if (aktMunition > maxMunition)
        {
        aktMunition = maxMunition;
        }

    // Munition-Slider aktualisieren
    AnzeigeController.anzeige.MunitionAktualisieren(aktMunition, maxMunition);
    }

}
