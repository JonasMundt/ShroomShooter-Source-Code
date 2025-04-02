using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelWechsel : MonoBehaviour
{
    public GameObject levelTor;

    void Start()
    {
        // Debuggen
        levelTor.SetActive(false);
        Debug.Log("LevelTor wurde deaktiviert.");
    }

    void Update()
{
    int rotePilze = GameObject.FindGameObjectsWithTag("Pilz Rot").Length;
    int gruenePilze = GameObject.FindGameObjectsWithTag("Pilz Grün").Length;

    if (rotePilze <= 0 && gruenePilze <= 0)
    {
        if (!levelTor.activeSelf)
        {
            levelTor.SetActive(true);
            Debug.Log("LevelTor wurde aktiviert!"); //Debuggen
        }
    }
}



    private void OnTriggerEnter(Collider other)
    {
        // Debuggen
        Debug.Log("Objekt hat das LevelTor berührt: " + other.gameObject.name);

        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Level 2 wird geladen!"); //Debuggen
            SceneManager.LoadScene("Level 2");
        }
    }
}
