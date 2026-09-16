using System;

namespace Ucu.Poo.RolePlayGame
{


    public class Elves
    {

        public int Life { get; set; }
        public int Attack { get; set; }
        private int defense;
        public int Defense
        { 
            get
            {
                int totalDefense = defense;
                if (this.Cape != null)
                {
                    totalDefense += this.Cape.Defense;
                }
                return totalDefense;
            } 
            set
            {
                defense = value;
            } 
        }
        public Bow Bow { get; set; }
        public Cape Cape { get; set; }

        public Elves(int Life, int Attack, int Defense)
        {

            this.Life = Life;
            this.Attack = Attack;
            this.Defense = Defense;

        }

        public void helpOther(ref int life)
        {

            life += 2;
        }
        public void shootWizard(Wizard wizard)
        {
            if (this.Bow != null)
            {
                if (wizard != null && this.Bow.shootArrow())
                {
                    int attackTotal = this.Attack + this.Bow.Damage;
                    wizard.Life -= attackTotal - wizard.Defense;
                }
            }
        }
        public void shootElves(Elves elves)
        {
            if (this.Bow != null)
            {
                if (elves != null && this.Bow.shootArrow())
                {
                    int attackTotal = this.Attack + this.Bow.Damage;
                    elves.Life -= attackTotal - elves.Defense;
                }
            }
        }
        public void shootDwarf(Dwarf dwarf)
        {
            if (this.Bow != null)
            {
                if (dwarf != null && this.Bow.shootArrow())
                {
                    int attackTotal = this.Attack + this.Bow.Damage;
                    dwarf.Life -= attackTotal - dwarf.Defense;
                }
            }
        }
    }
    public class Bow
    {
        public int Damage { get; set; }
        public int Quantity { get; set; }

        public Bow(int quantity)
        {
            this.Damage = 2;
            this.Quantity = quantity;
        }
        public bool shootArrow()
        {
            if (this.Quantity > 0)
            {
                this.Quantity = Quantity - 1;
                return true;
            }
            return false;
        }
    }

    public class Cape
    {
        public int Defense;

        public Cape(int defense)
        {

            this.Defense = defense;
        }
    }
}

