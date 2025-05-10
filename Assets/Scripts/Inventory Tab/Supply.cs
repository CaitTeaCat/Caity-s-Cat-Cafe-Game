using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamePlay.InventoryTab;

public abstract class Supply : MonoBehaviour
{
    public abstract string supplyName { get; set; }
    public abstract int amount { get; set; }
    public abstract int price { get; set; }
    public abstract double durability {  get; set; }

    public abstract void addAmount(int num);
    public abstract void removeAmount(int num);
}
