using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiController : MonoBehaviour
{

    public GameObject inventory;
    public GameObject items;
    public GameObject pause;
    public float inventoryCooldown;

    private float nextInventoryUse;
    private bool inventoryCheck;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("p") && Time.time > nextInventoryUse)
        {
            OpenInventory(inventoryCheck);
            StartCoroutine(DelayItemVisibility(inventoryCheck));

            nextInventoryUse = Time.time + inventoryCooldown;
        }
        if(Input.GetKeyDown(KeyCode.Escape) && pause.activeInHierarchy)
        {
            PauseGame(false);
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && !pause.activeInHierarchy)
        {
            PauseGame(true);
        }
        if(inventory.activeInHierarchy)
        {
            inventoryCheck = false;
        }
        else
        {
            inventoryCheck = true;
        }
    }

    public void OpenInventory(bool check)
    {
        inventory.SetActive(check);
    }
    public void CloseInventory()
    {
        inventory.SetActive(false);
    }
    public void PauseGame(bool check)
    {
        pause.SetActive(check);  
        Time.timeScale = (check) ? 0 : 1f;
    }

    IEnumerator DelayItemVisibility(bool check)
    {

        if(check)
        {
            yield return new WaitForSeconds(0.4f);
        }


        items.SetActive(check);

    }
}
