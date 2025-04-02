using UnityEngine;

public class PilzGruenController : MonoBehaviour
{
    public int gesundheit = 3; // Gesundheit des grünen Pilzes
    public GameObject effektExplosion; // Explosionseffekt

    public void Getroffen(int schaden)
    {
        // Schaden abziehen
        gesundheit -= schaden;

        // Debugging: Zeige aktuelle Gesundheit und Größe an
        Debug.Log("Grüner Pilz getroffen. Gesundheit: " + gesundheit);

        // Spieler Punkte geben
        SpielerGesundheitPunkteController.gesundheitPunkteController.PunkteHinzufuegen(1);

        // Pilz skalieren
        transform.localScale += Vector3.one * 0.5f; // Größer machen

        // Wenn Gesundheit 0 ist, Pilz zerstören
        if (gesundheit <= 0)
        {
            if (effektExplosion != null)
            {
                Instantiate(effektExplosion, transform.position, transform.rotation);
            }
            Destroy(gameObject);
        }
    }
}
