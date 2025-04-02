using UnityEngine;

public class PilzRotController : MonoBehaviour
{
    public int gesundheit = 5;

    public void Getroffen(int schaden)
    {
        // Schaden von der Gesundheit abziehen
        gesundheit -= schaden;

        // Die Transform-Komponente skalieren
        gameObject.GetComponent<Transform>().localScale += Vector3.one * 0.5f;

        // Wenn die Gesundheit kleiner gleich 0 ist, wird das Game-Objekt zerstört
        if (gesundheit <= 0)
        {
            Destroy(gameObject);
            Instantiate(effektExplosion, transform.position, transform.rotation);
        }
    }

    public GameObject effektExplosion;
}
