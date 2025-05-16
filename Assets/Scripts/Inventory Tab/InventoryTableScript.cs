using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GamePlay.InventoryTab;
using System.Numerics;
using TMPro;

public class InventoryTableScript : MonoBehaviour
{
    public Transform entryContainer;
    public GameObject entryTemplate;
    private List<Supply> supplies;
    private List<Supply> combinedSupplies;

    private TMP_Dropdown ddCategory;

    private Text txtName;
    private Text txtAmount;


    // Start is called before the first frame update
    void Awake()
    {
        //entryContainer = transform.Find("Inventory Content");
        ddCategory = GameObject.Find("ddCategory").GetComponent<TMP_Dropdown>();
        //ddCategory.onValueChanged.AddListener((value) => createInventoryTable());
        supplies = new List<Supply>();
        createInventoryTable();
    }

    public List<string[,]> getQuantities(int category)
    {
        int arrayLength = 0;
        if (category == 0)
        {
            arrayLength = 61;
        }
        else if (category == 1)
        {
            arrayLength = 20;
        }
        else if (category == 2)
        {
            arrayLength = 20;
        }
        else
        {
            arrayLength = 20;
        }

        List<string[,]> supplyQuantities = new List<string[,]>();
        string[] supplyList = new string[arrayLength];

        if (category == 0)
        {
            supplyList = new string[] {"Bowl", "Cleaning Solution", "Cup", "Cutting Board", "Dish Soap", "Gloves",
            "Hand Soap", "Kettle", "Mixing Bowl", "Mop Pad", "Napkin", "Pan", "Paper Towel", "Plate", "Pot",
            "Spatula", "Sponge", "Toilet Paper", "Towel", "Utensils", "Whisk", "Blanket", "Carrier", "Cat Bed",
            "Cat Tree", "Collar", "Dry Food", "Avocado", "Banana", "Carrot", "Cherry", "Chocolate",
            "Food Bowl", "Hair Brush", "Litter", "Litter Box", "Mouse", "Nail Trimmers", "Scratching Post",
            "Shampoo", "Toothbrush", "Toothpaste", "Treat", "Wand Toy", "Water Bowl", "Wet Food", "Almond Flour",
            "Cinnamon", "Coffee", "Cream", "Cream Cheese", "Egg", "Flour", "Lemon", "Maple Syrup", "Milk",
            "Mixed Berries", "Raspberry", "Sandwich Cookies", "Strawberry", "Turkey"};
        }
        else if(category == 1)
        {
            supplyList = new string[] {"Bowl", "Cleaning Solution", "Cup", "Cutting Board", "Dish Soap", "Gloves",
            "Hand Soap", "Kettle", "Mixing Bowl", "Mop Pad", "Napkin", "Pan", "Paper Towel", "Plate", "Pot",
            "Spatula", "Sponge", "Toilet Paper", "Towel", "Utensils", "Whisk"};
        }
        else if (category == 2)
        {
            supplyList = new string[] {"Blanket", "Carrier", "Cat Bed", "Cat Tree", "Collar", "Dry Food", 
                "Food Bowl", "Hair Brush", "Litter", "Litter Box", "Mouse", "Nail Trimmers", "Scratching Post", 
                "Shampoo", "Toothbrush", "Toothpaste", "Treat", "Wand Toy", "Water Bowl", "Wet Food"};

        }
        else if (category == 3)
        {
            supplyList = new string[]{ "Almond Flour" , "Avocado", "Banana", "Carrot", "Cherry", "Chocolate",
            "Cinnamon", "Coffee", "Cream", "Cream Cheese", "Egg", "Flour", "Lemon", "Maple Syrup", "Milk",
            "Mixed Berries", "Raspberry", "Sandwich Cookies", "Strawberry", "Turkey"};
        }

        List<Supply> temp = new List<Supply>();

        int index = 0;
        for (int i = 0; i < supplyList.Length; i++)
        {
            temp = supplies.FindAll(s => s.supplyName == supplyList[i]);
            Debug.Log(supplyList[i]);
            int amount = 0;
            foreach (Supply supply in temp)
            {
                
                amount += supply.amount;
            }
            string[,] tempArray = new string[2, 1];
            if (amount > 0) {
                tempArray[0, 0] = supplyList[i];
                tempArray[1, 0] = amount.ToString();
                supplyQuantities.Add(tempArray);
            }
        }
        return supplyQuantities;
    }

    public void createInventoryTable() // Next Step: List in order of greatest to least items
    {
        Debug.Log("createInventoryTable():");
        Supply flour = gameObject.AddComponent(typeof(Flour)) as Flour;
        supplies.Add(flour);
        Debug.Log("Flour Created");

        Supply egg = gameObject.AddComponent(typeof(Egg)) as Egg;
        supplies.Add(egg);
        Debug.Log("Egg Created");

        flour = gameObject.AddComponent(typeof(Flour)) as Flour;
        supplies.Add(flour);
        Debug.Log("Flour Created");

        egg = gameObject.AddComponent(typeof(Egg)) as Egg;
        supplies.Add(egg);
        Debug.Log("Egg Created");

        flour = gameObject.AddComponent(typeof(Flour)) as Flour;
        supplies.Add(flour);
        Debug.Log("Flour Created");
        Debug.Log(flour.GetType().Name);


        List<string[,]> resultList =  getQuantities(ddCategory.value);
        string[,] supplyList = new string[2, resultList.Count];

        int index = 0;
        foreach (string[,] result in resultList)
        {
            supplyList[0, index] = result[0, 0];
            supplyList[1, index] = result[1, 0];
            index++;
        }

        for (int i = 0; i < supplyList.Length / 2; i++)
        {
            entryTemplate = Instantiate(entryTemplate, entryContainer, false);
            txtName = entryTemplate.transform.Find("txtItemName").GetComponent<Text>();
            txtName.text = supplyList[0, i];
            txtAmount = entryTemplate.transform.Find("txtAmount").GetComponent<Text>();
            txtAmount.text = supplyList[1, i];
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

    public void addSupply(Supply supply)
    {
        supplies.Add(supply);
    }

    public void removeSupply(Supply supply)
    {
        supplies.Remove(supply);
    }
}
