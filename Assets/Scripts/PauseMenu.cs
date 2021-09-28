using System;
using System.Collections; 
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    private bool b_isPaused;
    private bool b_Inventory;
    //[SerializeField] private Text hideShowButtonText;
    [SerializeField] private KeyCode pauseKey = KeyCode.Escape;
    [SerializeField] private KeyCode inventoryKey = KeyCode.I;
    [SerializeField] private GameObject pausePanel, inventoryUI;
    [SerializeField] private Inventory InventoryManager;

    private CursorLockMode _cursorLockMode;
 
    private void Update()
    {
        if (Input.GetKeyDown(pauseKey))
        {
            b_isPaused = !b_isPaused;
            Pause(b_isPaused);
        }

        if (Input.GetKeyDown(inventoryKey) && !b_isPaused)
        {
            ShowHideInventory();
        }
    }

    private void Pause(bool pause)
    {
        pausePanel.SetActive(pause); // test in build
        if (pause)
        {
            Time.timeScale = 0f;
            Cursor.visible = true;
            _cursorLockMode = Cursor.lockState;
            Cursor.lockState = CursorLockMode.Confined;
            inventoryUI.gameObject.SetActive(false);
        }
        else
        {
            Time.timeScale = 1f;
            Cursor.visible = false;
            Cursor.lockState = _cursorLockMode;
        }
    }

    public void ShowHideInventory()
    {
        b_Inventory = !b_Inventory;
        inventoryUI.SetActive(b_Inventory);
        if (b_Inventory)
        {
            Cursor.visible = true;
            _cursorLockMode = Cursor.lockState;
            Cursor.lockState = CursorLockMode.Confined;
            //hideShowButtonText.text = "Hide";
            InventoryManager.UpdateUI();
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = _cursorLockMode;
            //hideShowButtonText.text = "Show";
        }
    }

    public void Quit()
    {
        Application.Quit();
    }
} 