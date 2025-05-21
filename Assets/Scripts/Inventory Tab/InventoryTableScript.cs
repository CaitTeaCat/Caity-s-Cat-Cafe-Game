using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GamePlay.InventoryTab;
using GamePlay;
using TMPro;

public class InventoryTableScript : MonoBehaviour
{
    // Inventory List Objects
    public Transform entryContainer;
    public GameObject entryTemplate;
    private List<Supply> supplies;
    private List<Supply> combinedSupplies;
    public GameObject durabilityTemplate;
    private TMP_Dropdown ddCategory;
    private Button btnInventoryItem;

    private Text txtName;
    private Text txtAmount;

    // Item View Objects
    public Image itemImage;
    public Button btnIncrease;
    public Button btnDecrease;
    public Text txtCost;
    private int cost;
    public Button btnBuy;
    public Text txtInfo;
    public Text txtItemAmount;
    public Transform durabilityPane;

    private Supply selectedSupply;
    private Transform selectedButton;

    // Item Storage & Balance
    public Text txtStorage;
    private int storageSize;
    private int currentStorage;
    public Text txtBalance;

    //Item Store
    public Button btnStore;
    public GameObject storeItemTemplate;
    public Transform storeContainer;
    private Button btnStoreItem;

    private List<Supply> orderedSupplies;
    private List<int> deliveryLog;

    // Start is called before the first frame update
    void Start()
    {
        //entryContainer = transform.Find("Inventory Content");
        ddCategory = GameObject.Find("ddCategory").GetComponent<TMP_Dropdown>();
        ddCategory.onValueChanged.AddListener(ddCategoryHandler);
        btnIncrease.onClick.AddListener(btnIncreaseHandler);
        btnDecrease.onClick.AddListener(btnDecreaseHandler);
        btnBuy.onClick.AddListener(btnBuyHandler);
        btnStore.onClick.AddListener(btnStoreHandler);
        storeContainer.gameObject.SetActive(false);
        entryContainer.gameObject.SetActive(true);
        supplies = new List<Supply>();
        storageSize = 100;
        currentStorage = 0;

        txtBalance.text = "Balance: $" + GlobalVariables.Money.ToString();

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

        createInventoryTable();
    }

    public void ddCategoryHandler(int category)
    {
        if (btnStore.transform.Find("txtStoreButton").GetComponent<Text>().text == "Store")
        {
            createInventoryStore();
        }
        else
        {
            createInventoryTable();
        }
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

        for (int i = 0; i < supplyList.Length; i++)
        {
            temp = supplies.FindAll(s => s.supplyName == supplyList[i]);
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

    public void createInventoryTable() // Next Step: List in order of greatest to least items and alternate colors
    {
        int totalItems = 0;
        foreach (Transform child in entryContainer)
        {
            Destroy(child.gameObject);
        }

        List<string[,]> resultList =  getQuantities(ddCategory.value);
        string[,] supplyList = new string[2, resultList.Count];

        // Copies the resulting list to an array
        int index = 0;
        foreach (string[,] result in resultList)
        {
            supplyList[0, index] = result[0, 0];
            supplyList[1, index] = result[1, 0];
            totalItems += int.Parse(result[1, 0]);
            index++;
        }

        // Instatiates a row for each supply
        for (int i = 0; i < supplyList.Length / 2; i++)
        {
            GameObject newEntry = Instantiate(entryTemplate, entryContainer, false);
            txtName = newEntry.transform.Find("txtItemName").GetComponent<Text>();
            txtName.text = supplyList[0, i];
            txtAmount = newEntry.transform.Find("txtAmount").GetComponent<Text>();
            txtAmount.text = supplyList[1, i];
            btnInventoryItem = newEntry.GetComponent<Button>();
            btnInventoryItem.onClick.AddListener(() => { populateItemView(btnInventoryItem.transform); });
        }

        txtStorage.text = "Storage: " + totalItems.ToString() + "/" + storageSize.ToString();
    }

    public void populateItemView(Transform button)
    {
        selectedButton = button;
        string itemName = button.Find("txtItemName").GetComponent<Text>().text;
        string itemAmount = button.Find("txtAmount").GetComponent<Text>().text;

        if(itemName == "Flour")
        {
            Flour flour = gameObject.AddComponent(typeof(Flour)) as Flour;
            selectedSupply = flour;
            itemImage = flour.itemImage;
            txtInfo.text = itemName + "\nYou have: " + itemAmount;
        }

    }
    public void populateItemView()
    {
        string itemName = selectedButton.Find("txtItemName").GetComponent<Text>().text;
        string itemAmount = selectedButton.Find("txtAmount").GetComponent<Text>().text;

        itemImage = selectedSupply.itemImage;
        txtInfo.text = itemName + "\nYou have: " + itemAmount;

    }


    public void btnDecreaseHandler()
    {
        if (selectedSupply != null && txtItemAmount.text != "0")
        {
            txtItemAmount.text = (int.Parse(txtItemAmount.text) - 5).ToString();
            cost = (int.Parse(txtItemAmount.text) / 5) * selectedSupply.price;
            txtCost.text = "Cost: $" + cost.ToString();
        }
    }

    public void btnIncreaseHandler() {
        if (selectedSupply != null && (int.Parse(txtItemAmount.text) + 5) < storageSize && ((int.Parse(txtItemAmount.text) / 5) * selectedSupply.price) <= GlobalVariables.Money)
        {
            txtItemAmount.text = (int.Parse(txtItemAmount.text) + 5).ToString();
            cost = (int.Parse(txtItemAmount.text) / 5) * selectedSupply.price;
            txtCost.text = "Cost: $" + cost.ToString();
        }
    }

    public void btnBuyHandler()
    {
        if (selectedSupply != null)
        {
            if (selectedSupply.supplyName == "Flour")
            {
                Flour flour = gameObject.AddComponent<Flour>() as Flour;
                flour.amount = int.Parse(txtItemAmount.text);
                supplies.Add(flour);
                txtItemAmount.text = 0.ToString();
                createInventoryTable();
                GlobalVariables.Money -= flour.price * (flour.amount / 5);
                txtBalance.text = "Balance: $" + GlobalVariables.Money;
                txtCost.text = "Cost: $0";
                currentStorage += flour.amount;
                txtStorage.text = "Storage: " + currentStorage.ToString() + "/" + storageSize.ToString();
                orderedSupplies.Add(flour);
                deliveryLog.Add(3);
            }
        }
    }

    public void btnStoreHandler()
    {
        if (btnStore.transform.Find("txtStoreButton").GetComponent<Text>().text == "Store")
        {
            entryContainer.gameObject.SetActive(false);
            storeContainer.gameObject.SetActive(true);
            btnStore.transform.Find("txtStoreButton").GetComponent<Text>().text = "Inventory";
            createInventoryStore();
            Debug.Log("Store");
        }
        else
        {
            entryContainer.gameObject.SetActive(true);
            storeContainer.gameObject.SetActive(false);
            btnStore.transform.Find("txtStoreButton").GetComponent<Text>().text = "Store";
            createInventoryTable();
            Debug.Log("Inventory");
        }
    }

    public void createInventoryStore()
    {
        int arrayLength = 0;
        if (ddCategory.value == 0)
        {
            arrayLength = 61;
        }
        else if (ddCategory.value == 1)
        {
            arrayLength = 20;
        }
        else if (ddCategory.value == 2)
        {
            arrayLength = 20;
        }
        else
        {
            arrayLength = 20;

        }

        string[] supplyList = new string[arrayLength];

        if (ddCategory.value == 0)
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
        else if (ddCategory.value == 1)
        {
            supplyList = new string[] {"Bowl", "Cleaning Solution", "Cup", "Cutting Board", "Dish Soap", "Gloves",
            "Hand Soap", "Kettle", "Mixing Bowl", "Mop Pad", "Napkin", "Pan", "Paper Towel", "Plate", "Pot",
            "Spatula", "Sponge", "Toilet Paper", "Towel", "Utensils", "Whisk"};
        }
        else if (ddCategory.value == 2)
        {
            supplyList = new string[] {"Blanket", "Carrier", "Cat Bed", "Cat Tree", "Collar", "Dry Food",
                "Food Bowl", "Hair Brush", "Litter", "Litter Box", "Mouse", "Nail Trimmers", "Scratching Post",
                "Shampoo", "Toothbrush", "Toothpaste", "Treat", "Wand Toy", "Water Bowl", "Wet Food"};

        }
        else if (ddCategory.value == 3)
        {
            supplyList = new string[]{ "Almond Flour" , "Avocado", "Banana", "Carrot", "Cherry", "Chocolate",
            "Cinnamon", "Coffee", "Cream", "Cream Cheese", "Egg", "Flour", "Lemon", "Maple Syrup", "Milk",
            "Mixed Berries", "Raspberry", "Sandwich Cookies", "Strawberry", "Turkey"};
        }

        foreach (string s in supplyList)
        {
            GameObject newEntry = Instantiate(storeItemTemplate, storeContainer, false);
            txtName = newEntry.transform.Find("Inventory Store Item Name").GetComponent<Text>();
            txtName.text = s;
            btnStoreItem = newEntry.GetComponent<Button>();
            btnStoreItem.onClick.AddListener(() => { populateStoreItemView(btnStoreItem.transform); });
        }
    }

    public void populateStoreItemView(Transform button)
    {
        selectedButton = button;
        string itemName = selectedButton.Find("Inventory Store Item Name").GetComponent<Text>().text;

        if(itemName == "Flour")
        {
            Flour flour = gameObject.AddComponent(typeof(Flour)) as Flour;
            selectedSupply = flour;
            itemImage = flour.itemImage;

            int itemAmount = 0;
            List<Supply> temp = new List<Supply>();
            temp = supplies.FindAll(s => s.supplyName == "Flour");
            int amount = 0;
            foreach (Supply supply in temp)
            {
                itemAmount += supply.amount;
            }

                txtInfo.text = itemName + "\nYou have: " + itemAmount;
        }

        itemImage = selectedSupply.itemImage;
    }

    public void dayAdvance()
    {
        for(int i = 0; i < deliveryLog.Count; i++)
        {
            deliveryLog[i]--;
            if (deliveryLog[i] == 0)
            {
                supplies.Add(orderedSupplies[i]);
                deliveryLog.RemoveAt(i);
                orderedSupplies.RemoveAt(i);

            }
        }
        createInventoryStore();
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
