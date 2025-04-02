using UnityEngine;

public class KugelController : MonoBehaviour
{
    public GameObject effektExplosion; // Explosionseffekt
    public float geschwindigkeit = 10f; // Geschwindigkeit der Kugel

    private Rigidbody rb; // Referenz für den Rigidbody

    private void Start()
    {
        // Rigidbody der Kugel getten
        rb = GetComponent<Rigidbody>();

        if (rb != null)
        {
            // Setze die Geschwindigkeit der Kugel
            rb.velocity = transform.forward * geschwindigkeit;
        }
        else
        {
            Debug.LogError("Kein Rigidbody gefunden! Bitte sicherstellen, dass die Kugel einen Rigidbody hat."); //Debuggen
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Überprüfen ob ein roter Pilz getroffen wurde
        if (other.tag == "Pilz Rot")
        {
            Debug.Log("Roter Pilz wurde getroffen: " + other.gameObject.name); //Debuggen

            // Spieler verliert Gesundheit
            SpielerGesundheitPunkteController.gesundheitPunkteController.Schaden(1);

            // Roten Pilz treffen
            PilzRotController pilz = other.gameObject.GetComponent<PilzRotController>();
            if (pilz != null)
            {
                pilz.Getroffen(1); // 1 Schaden zufügen
            }
        }
        // Überprüfen, ob ein grüner Pilz getroffen wurde
        else if (other.tag == "Pilz Grün")
        {
            Debug.Log("Grüner Pilz wurde getroffen: " + other.gameObject.name); //Debuggen

            // Grünen Pilz treffen
            PilzGruenController pilz = other.gameObject.GetComponent<PilzGruenController>();
            if (pilz != null)
            {
                pilz.Getroffen(1); // 1 Schaden zufügen
            }
        }

        // Explosionseffekt anzeigen
        if (effektExplosion != null)
        {
            Instantiate(effektExplosion, transform.position, transform.rotation);
        }

        // Kugel zerstören nachdem sie getroffen hat
        Destroy(gameObject);
    }
}
