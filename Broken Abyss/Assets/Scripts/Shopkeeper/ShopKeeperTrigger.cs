using UnityEngine;

public class ShopkeeperTrigger : MonoBehaviour
{
    public GameObject MainOptionPanel;  // Drag your panel here in the inspector

    private bool playerInRange = false;  // To track if player is near shopkeeper

    // Start is called before the first frame update
    void Start()
    {
        // Make the MainOptionPanel invisible at the start of the game
        MainOptionPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // If the player is in range and presses "E", toggle the panel visibility
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            // Toggle visibility of the panel
            MainOptionPanel.SetActive(!MainOptionPanel.activeSelf);
        }
    }

    // Detect when the player enters the shopkeeper's trigger collider
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;  // Player is in range
        }
    }

    // Detect when the player leaves the shopkeeper's trigger collider
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;  // Player is out of range
            MainOptionPanel.SetActive(false);  // Automatically close the panel when leaving range
        }
    }
}


