using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Felder für den Spieler
    public float geschwindigkeit = 5f;
    public float mausGeschwindigkeit = 2f;
    public float schwerkraft = 2f;
    public float geschwindigkeitRennen = 20f;

    // Für den CharacterController
    public CharacterController spieler;

    // Für die Kamera des Spielers
    public Transform spielerKamera;

    // Für das Schießen
    public GameObject kugel;
    public Transform abschussPunkt;

    // Interne Variable für die Bewegung
    private Vector3 bewegungSpieler;

    void Update()
    {
        // Bewegung des Spielers berechnen
        BewegungBerechnen();

        // Maussteuerung: Drehung des Spielers und der Kamera
        MausSteuerung();

        // Schießen
        Feuern();
    }

    private void BewegungBerechnen()
    {
        Vector3 vertikaleBewegung = transform.forward * Input.GetAxis("Vertical");
        Vector3 horizontaleBewegung = transform.right * Input.GetAxis("Horizontal");

        bewegungSpieler = horizontaleBewegung + vertikaleBewegung;
        bewegungSpieler.Normalize(); // Richtung beibehalten, Länge = 1

        // Sprinten mit der Taste R
        if (Input.GetKey(KeyCode.R))
        {
            bewegungSpieler *= geschwindigkeitRennen;
        }
        else
        {
            bewegungSpieler *= geschwindigkeit;
        }

        // Schwerkraft hinzufügen
        bewegungSpieler.y += Physics.gravity.y * schwerkraft;

        // Spielerbewegung anwenden
        spieler.Move(bewegungSpieler * Time.deltaTime);
    }

    private void MausSteuerung()
    {
        Vector2 mausBewegung = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")) * mausGeschwindigkeit;

        // Spieler um die y-Achse drehen
        transform.rotation = Quaternion.Euler(
            transform.rotation.eulerAngles.x,
            transform.rotation.eulerAngles.y + mausBewegung.x,
            transform.rotation.eulerAngles.z
        );

        // Kamera um die x-Achse drehen
        spielerKamera.rotation = Quaternion.Euler(
            spielerKamera.rotation.eulerAngles + new Vector3(-mausBewegung.y, 0f, 0f)
        );
    }

    private void Feuern()
    {
        // Prüfen ob die linke Maustaste gedrückt wird
        if (Input.GetMouseButtonDown(0))
        {
            // Munition prüfen
            if (SpielerGesundheitPunkteController.gesundheitPunkteController.aktMunition > 0)
            {
                // Kugel erzeugen
                Instantiate(kugel, abschussPunkt.position, abschussPunkt.rotation);

                // Munition verringern
                SpielerGesundheitPunkteController.gesundheitPunkteController.MunitionVerbrauchen(1);

                Debug.Log("Schuss abgefeuert! Verbleibende Munition: " +
                SpielerGesundheitPunkteController.gesundheitPunkteController.aktMunition);
            }
            else
            {
                // Debuggen
                Debug.Log("Keine Munition mehr! Sammle Wasserkapseln.");
            }
        }
    }
}
