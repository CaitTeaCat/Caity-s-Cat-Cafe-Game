using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamePlay.InventoryTab;
using UnityEngine.UI;
using System;

public abstract class Supply : MonoBehaviour, IComparable
{
    public abstract string supplyName { get; set; }
    public abstract int price { get; set; }
    public abstract double durability {  get; set; }
    public abstract Image itemImage { get; set; }
    public abstract int amount { get; set; }

    public int CompareTo(object obj)
    {
        Supply otherSupply = obj as Supply;

        return this.supplyName.CompareTo(otherSupply.supplyName);
    }
}
