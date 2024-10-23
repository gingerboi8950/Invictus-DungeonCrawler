using UnityEngine;
using UnityEngine.UI;

public class SlotClickHandler : MonoBehaviour
{
    public GameObject ItemMenu;  // 

    void Start()
    {
        // Ensure the ItemMenu is hidden at the start
        ItemMenu.SetActive(false);
    }

    // triggered when the slot is clicked
    public void OnSlotClick()
    {
        // Make the ItemMenu visible
        ItemMenu.SetActive(true);
        Debug.Log("Item slot clicked. ItemMenu is now visible.");
    }
}

