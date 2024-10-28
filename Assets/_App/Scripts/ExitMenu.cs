using UnityEngine;
using UnityEngine.UI;

public class ExitMenu : MonoBehaviour
{
    public GameObject exitMenu;
    public Button yesButton;
    public Button noButton;

    private void Start()
    {
        exitMenu.SetActive(false);

        yesButton.onClick.AddListener(OnYesButtonClicked);
        noButton.onClick.AddListener(OnNoButtonClicked);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (exitMenu.activeSelf)
            {
                HideExitMenu();
                Cursor.lockState = CursorLockMode.Locked;
            }
            else
            {
                ShowExitMenu();
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }


    public void ShowExitMenu()
    {
        exitMenu.SetActive(true);
    }

    private void HideExitMenu()
    {
        exitMenu.SetActive(false); 
    }

    private void OnYesButtonClicked()
    {
        Debug.Log("Выход из игры...");
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; 
#endif
    }

    private void OnNoButtonClicked()
    {
        HideExitMenu(); 
    }
}
