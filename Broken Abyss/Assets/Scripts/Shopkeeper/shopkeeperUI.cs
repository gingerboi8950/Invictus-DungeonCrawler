using UnityEngine;

public class ShopkeeperUI : MonoBehaviour
{
    public GameObject panelBackground; // This reference the options panel 

    void Start()
    {
        panelBackground.SetActive(false); // This ensure the panel starts hidden
    }

    void Update()
    {
        // This toggles the panel when the player presses 'E' near the shopkeeper
        if (Input.GetKeyDown(KeyCode.E))
        {
            panelBackground.SetActive(!panelBackground.activeSelf);
        }
    }
}
