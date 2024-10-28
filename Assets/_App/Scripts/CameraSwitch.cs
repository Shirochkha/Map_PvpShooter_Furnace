using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public Camera playerCamera;
    public Camera flyCamera;
    public FirstPersonController playerController;

    private void Start()
    {
        flyCamera.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            bool isPlayerCameraActive = playerCamera.gameObject.activeSelf;
            playerCamera.gameObject.SetActive(!isPlayerCameraActive);
            flyCamera.gameObject.SetActive(isPlayerCameraActive);

            playerController.playerCanMove = !isPlayerCameraActive;
        }
    }
}
