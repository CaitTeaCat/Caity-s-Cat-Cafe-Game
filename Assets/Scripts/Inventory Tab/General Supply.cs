using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.InventoryTab
{
    public abstract class GeneralSupply : Supply
    {
        public abstract double durabilityRate { get; set; }
    }
}
