using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GamePlay.InventoryTab;

public class InventoryTableScript : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;
    private List<Supply> supplies;



    // Start is called before the first frame update
    void Awake()
    {
        entryContainer = transform.Find("Inventory Table");
        entryTemplate = transform.Find("Inventory Item Template");
        createInventoryTable();
    }
    public void createInventoryTable()
    {
       supplies = new List<Supply>();

        Supply flour = new Flour();
        supplies.Add(flour);

        int i = 0;
        foreach (Supply supply in supplies)
        {
            Transform entryTransform = Instantiate(entryTemplate, entryContainer);
            entryTransform.Find("txtItemName").GetComponent<Text>().text = supply.supplyName;
            entryTransform.Find("txtPrice").GetComponent<Text>().text = supply.price.ToString();
            i++;
        }
    }

    public List<Supply> getSupplies()
    {
        return supplies;
    }

    public Supply getSupply(int index)
    {
        return supplies[index];
    }
}
