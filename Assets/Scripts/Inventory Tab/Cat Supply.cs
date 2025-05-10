using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.InventoryTab
{
    public abstract class CatSupply : Supply
    {
        public abstract double wearRate { get; set; }
    }
}
