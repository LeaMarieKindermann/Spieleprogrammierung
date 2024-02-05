using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public Button tryAgainButton;   // Referenz auf den "Try Again" Button
    public Button menuButton;       // Referenz auf den "Menu" Button
    public Checkpoint checkpoint;   // Referenz auf das Checkpoint-Skript
    public GameObject player;
    public GameObject defeatUI;

    void Start()
    {
        // Füge Listener für Mausklick-Ereignisse hinzu
        tryAgainButton.onClick.AddListener(OnTryAgainButtonClick);
        menuButton.onClick.AddListener(OnMenuButtonClick);
    }

    // Methode, die aufgerufen wird, wenn der "Try Again" Button geklickt wird
    void OnTryAgainButtonClick()
    {
        if (checkpoint.activated)
        {
            PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
            playerHealth.SetFullHealth();

            // Hole die Respawn-Position vom Checkpoint
            Vector3 respawnPosition = checkpoint.GetRespawnPosition();

            // Setze die Position des Spielers auf die Respawn-Position
            player.transform.position = respawnPosition;

            defeatUI.SetActive(false);

            Debug.Log("Respawn at checkpoint!");
        }
        else 
        {
            SceneManager.LoadScene("Level 1");
        }
    }

    // Methode, die aufgerufen wird, wenn der "Menu" Button geklickt wird
    void OnMenuButtonClick()
    {
        SceneManager.LoadScene("Level-Menu");
    }
}
