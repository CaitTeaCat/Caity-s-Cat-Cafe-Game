using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.InventoryTab
{
    public class Flour : Ingredient
    {

        public string _supplyName;
        public int _amount;
        public int _price;
        public double _durability;
        private double _spoilRate;

        public Flour()
        {
            supplyName = "Flour";
            amount = 0;
            price = 0;
            durability = 100;
            spoilRate = 10;

        }
        public override void addAmount(int num)
        {
            amount += num;
        }
        public override void removeAmount(int num)
        {
            amount -= num;
        }


        public override string supplyName
        {

            get { return supplyName; }
            set { _supplyName = value; }
        }

        public override int amount
        {
            get { return amount; }
            set { amount = value; }
        }

        public override int price
        {
            get { return price; }
            set { price = value; }
        }

        public override double durability
        {
            get { return durability; }
            set { durability = value; }
        }

        public override double spoilRate
        {
            get { return spoilRate; }
            set { spoilRate = value;}
        }

    }
}
