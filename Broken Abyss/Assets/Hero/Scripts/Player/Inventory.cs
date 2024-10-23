using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int activeSlotIndexNum = 0;

    private Controls playerControls;

    private void Awake()
    {
        playerControls = new Controls();
    }

    private void Start()
    {
        playerControls.Inventory.Keyboard.performed += ctx => ToggleActiveSlot((int)ctx.ReadValue<float>());

        foreach(Transform inventorySlot in this.transform)
        {
            inventorySlot.GetChild(0).gameObject.SetActive(false);
        }
        this.transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void ToggleActiveSlot(int numValue)
    {
        ToggleActiveHighLight(numValue - 1);
    }

    private void ToggleActiveHighLight(int indexNum)
    {
        activeSlotIndexNum = indexNum;

        foreach(Transform inventorySlot in this.transform)
        {
            inventorySlot.GetChild(0).gameObject.SetActive(false);
        }

        this.transform.GetChild(indexNum).GetChild(0).gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
