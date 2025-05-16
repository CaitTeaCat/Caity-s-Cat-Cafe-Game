using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GamePlay.InventoryTab
{
    public class Coffee : Ingredient
    {

        private string _supplyName;
        private int _price;
        private int _amount;
        private double _durability;
        private double _spoilRate;
        private Image _itemImage;

        public Coffee()
        {
            supplyName = "Coffee";
            price = 15;
            amount = 0;
            durability = 100;
            spoilRate = 4;
            itemImage = null;
        }

        public Coffee(int amount)
        {
            supplyName = "Coffee";
            price = 15;
            this.amount = amount;
            durability = 100;
            spoilRate = 4;
            itemImage = null;
        }

        public override string supplyName
        {

            get { return _supplyName; }
            set { _supplyName = value; }
        }

        public override int price
        {
            get { return _price; }
            set { _price = value; }
        }

        public override int amount
        {
            get { return _amount; }
            set { _amount = value; }
        }

        public override double durability
        {
            get { return _durability; }
            set { _durability = value; }
        }

        public override double spoilRate
        {
            get { return _spoilRate; }
            set { _spoilRate = value; }
        }

        public override Image itemImage
        {
            get { return _itemImage; }
            set { _itemImage = value; }
        }
    }
}
