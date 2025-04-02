using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform spielerKamera;

    void Update()
    {
        transform.position = spielerKamera.position;
        transform.rotation = spielerKamera.rotation;
    }
}
