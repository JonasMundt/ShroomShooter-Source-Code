using UnityEngine;

public class WasserKapselController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Prüfen, ob das Objekt, das die Kapsel berührt der Spieler ist
        if (other.gameObject.CompareTag("Player"))
        {
            // Munition auffüllen
            SpielerGesundheitPunkteController.gesundheitPunkteController.MunitionAuffuellen(5);

            // Debuggen
            Debug.Log("Munition aufgefüllt durch Wasserkapsel!");

            // Kapsel zerstören
            Destroy(gameObject);
        }
    }
}
