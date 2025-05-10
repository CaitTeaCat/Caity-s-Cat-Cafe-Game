using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.InventoryTab
{
    public abstract class Ingredient : Supply
    {
        public abstract double spoilRate { get; set; }
    }
}
