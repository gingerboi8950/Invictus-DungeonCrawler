using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ShopkeeperUI : MonoBehaviour
{
    public GameObject MainOptionPanel;   // Panel with "Buy" and "Sell" options
    public GameObject panelBackground;   // Panel with shop item slots
    public Button buyButton;             // Reference to Buy button
    public Button sellButton;            // Reference to Sell button

    private Color defaultColor;
    public Color hoverColor = Color.yellow;  // Color to change to on hover

    void Start()
    {
        // Ensure both panels start hidden
        MainOptionPanel.SetActive(false);
        panelBackground.SetActive(false);

        // Add listeners for button clicks
        buyButton.onClick.AddListener(BuyItemAction);
        sellButton.onClick.AddListener(SellItemAction);

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
    }

    void SellItemAction()
    {
        // Hide the panel as per your logic. For now, just hide MainOptionPanel
        MainOptionPanel.SetActive(false);
        Debug.Log("Sell Item selected.");
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
