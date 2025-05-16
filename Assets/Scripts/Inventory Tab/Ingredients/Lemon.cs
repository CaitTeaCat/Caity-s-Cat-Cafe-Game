using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GamePlay.InventoryTab
{
    public class Lemon : Ingredient
    {

        private string _supplyName;
        private int _price;
        private int _amount;
        private double _durability;
        private double _spoilRate;
        private Image _itemImage;

        public Lemon()
        {
            supplyName = "Lemon";
            price = 3;
            amount = 0;
            durability = 100;
            spoilRate = 20;
            itemImage = null;
        }

        public Lemon(int amount)
        {
            supplyName = "Lemon";
            price = 3;
            this.amount = amount;
            durability = 100;
            spoilRate = 20;
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
