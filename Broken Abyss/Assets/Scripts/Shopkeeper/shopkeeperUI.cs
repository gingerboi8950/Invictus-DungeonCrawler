using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ShopkeeperUI : MonoBehaviour
{
    public GameObject MainOptionPanel;   // Panel with "Buy" and "Sell" options
    public GameObject panelBackground;   // Panel with shop item slots
    public Button buyButton;             // Reference to Buy button
    public Button sellButton;            // Reference to Sell button
    public Button backButton;            // Reference to Back button in panelBackground
    public Button exitButton;            // Reference to Exit button in panelBackground
    public GameObject ItemMenu;
    public Item selectedItem; // represent currently selected item

    private Color defaultColor;
    public Color hoverColor = Color.yellow;  // Color to change to on hover

    void Start()
    {
        // Ensure both panels start hidden
        MainOptionPanel.SetActive(false);
        panelBackground.SetActive(false);
        ItemMenu.SetActive(false);

        // Add listeners for button clicks
        buyButton.onClick.AddListener(BuyItemAction);
        sellButton.onClick.AddListener(SellItemAction);
        backButton.onClick.AddListener(BackAction);  // Add Back button listener
        exitButton.onClick.AddListener(ExitAction);  // Add Exit button listener

        // Store the original color of the buttons
        defaultColor = buyButton.GetComponent<Image>().color;

        // Add EventTriggers for hover effects on Buy button
        AddEventTrigger(buyButton, OnBuyButtonHoverEnter, EventTriggerType.PointerEnter);
        AddEventTrigger(buyButton, OnBuyButtonHoverExit, EventTriggerType.PointerExit);

        // Add EventTriggers for hover effects on Sell button
        AddEventTrigger(sellButton, OnSellButtonHoverEnter, EventTriggerType.PointerEnter);
        AddEventTrigger(sellButton, OnSellButtonHoverExit, EventTriggerType.PointerExit);
    }

    void Update()
    {
        // Toggle the MainOptionPanel visibility when the player presses 'E'
        if (Input.GetKeyDown(KeyCode.E))
        {
            MainOptionPanel.SetActive(!MainOptionPanel.activeSelf);
        }

        // Check if player clicks outside of the MainOptionPanel to close it
        if (MainOptionPanel.activeSelf && Input.GetMouseButtonDown(0))
        {
            // Detect if the mouse is not clicking on any UI element
            if (!IsPointerOverUIObject())
            {
                MainOptionPanel.SetActive(false);  // Hide the MainOptionPanel
            }
        }
    }

    void BuyItemAction()
    {
        // Hide MainOptionPanel and show the shop item panel (panelBackground)
        MainOptionPanel.SetActive(false);
        panelBackground.SetActive(true);  // Show shop inventory
        Debug.Log("Buy Item selected. Showing item slots.");

        // Find the player (TempHeroMovement) and the HotBar manager
        TempHeroMovement player = FindObjectOfType<TempHeroMovement>(); // Find the player character

        // Check if the player was found
        if (player != null)
        {
            // Check if the player has enough gold to buy the selected item
            if (selectedItem != null) // Ensure an item has been selected
            {
                if (player.BuyItem(selectedItem))  // Use player instance to handle the purchase
                {
                    Debug.Log("Item added to hotbar.");
                }
                else
                {
                    Debug.Log("Not enough gold to buy the item.");
                }
            }
            else
            {
                Debug.Log("No item selected.");
            }
        }
        else
        {
            Debug.Log("Player not found.");
        }
    }

    void SellItemAction()
    {
        // Hide the panel as per your logic. For now, just hide MainOptionPanel
        MainOptionPanel.SetActive(false);
        Debug.Log("Sell Item selected.");
    }

    void BackAction()
    {
        // Hide the shop item panel and show the MainOptionPanel again
        panelBackground.SetActive(false);
        MainOptionPanel.SetActive(true);
        Debug.Log("Back button clicked. Returning to Main Option Panel.");
    }

    void ExitAction()
    {
        // Hide the shop item panel
        panelBackground.SetActive(false);
        Debug.Log("Exit button clicked. Closing the shop inventory.");
    }

    // Method to add an EventTrigger to a button
    void AddEventTrigger(Button button, System.Action<BaseEventData> action, EventTriggerType triggerType)
    {
        EventTrigger trigger = button.gameObject.GetComponent<EventTrigger>();
        if (trigger == null)
        {
            trigger = button.gameObject.AddComponent<EventTrigger>();
        }

        EventTrigger.Entry entry = new EventTrigger.Entry
        {
            eventID = triggerType
        };
        entry.callback.AddListener((eventData) => action(eventData));
        trigger.triggers.Add(entry);
    }

    // Method called when mouse enters Buy button area
    void OnBuyButtonHoverEnter(BaseEventData eventData)
    {
        buyButton.GetComponent<Image>().color = hoverColor;  // Change color on hover
    }

    // Method called when mouse exits Buy button area
    void OnBuyButtonHoverExit(BaseEventData eventData)
    {
        buyButton.GetComponent<Image>().color = defaultColor;  // Revert to default color
    }

    // Method called when mouse enters Sell button area
    void OnSellButtonHoverEnter(BaseEventData eventData)
    {
        sellButton.GetComponent<Image>().color = hoverColor;  // Change color on hover
    }

    // Method called when mouse exits Sell button area
    void OnSellButtonHoverExit(BaseEventData eventData)
    {
        sellButton.GetComponent<Image>().color = defaultColor;  // Revert to default color
    }

    // Helper function to detect if the mouse is over a UI object
    private bool IsPointerOverUIObject()
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = Input.mousePosition;

        // Raycast to check if the pointer is over any UI element
        var results = new System.Collections.Generic.List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);
        return results.Count > 0;
    }
}
