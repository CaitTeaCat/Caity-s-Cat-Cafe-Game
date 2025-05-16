using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.InventoryTab
{
    public class ItemViewScript : MonoBehaviour
    {
        private Transform itemViewPane;
        private Transform ItemImage;
        private Transform inventoryTable;
        private List<GameObject> inventoryItem;

        private void Awake()
        {
            inventoryTable = transform.Find("Inventory Table");
            foreach (Transform child in transform)
            {
                //child.OnClick.addListener();
            }
        }
    }
}
