using UnityEngine;

public class MedizinController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            SpielerGesundheitPunkteController.gesundheitPunkteController.Heilen(5);
            Destroy(gameObject);
        }
    }
}
