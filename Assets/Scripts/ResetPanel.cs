using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

public class ResetPanel : MonoBehaviour
{
    public GameObject resetPanel;

    private void Start()
    {
        resetPanel.SetActive(false);
    }

    public void ShowResetPanel()
    {
        resetPanel.SetActive(true);
    }

    public void HideResetPanel()
    {
        resetPanel.SetActive(false);
    }

    public void ReloadScene()
    {
        GameManager.Instance.ResetGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}