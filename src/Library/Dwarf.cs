using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Ucu.Poo.RolePlayGame;


/// <summary>
/// Clase para el personaje Dwarfo
/// </summary>
public class Dwarf
{
    public Dwarf(string name, int attack, int defense, int life)
    {
        this.Name = name;
        this.Attack = attack;
        this.Defense = defense;
        this.Life = life;
    }
    public string Name { get; set; }
    public int Life { get; set; }
    public int Attack { get; set; }
    private int defense;
    public int Defense
    { 
        get
        {
            int totalDefense = defense;
            if (this.Helmet != null)
            {
                totalDefense += this.Helmet.Defense;
            }
            return totalDefense;
        } 
        set
        {
            defense = value;
        } 
    }
    public Axe Axe { get; set; }
    public Helmet Helmet { get; set;}

    public void PhycalAttackDwarf(Dwarf dwarf)
    {
        if (dwarf != null)
        {
            int attackDamage = this.Attack;
            if (this.Axe != null)
            {
                attackDamage += this.Axe.Attack;
            }
            dwarf.Life -= attackDamage - dwarf.Defense;
        }
    }

    public void PhycalAttackWizard(Wizard wizard)
    {
        if (wizard != null)
        {
            int attackDamage = this.Attack;
            if (this.Axe != null)
            {
                attackDamage += this.Axe.Attack;
            }
            wizard.Life -= attackDamage - wizard.Defense;
        }
    }

    public void PhycalAttackElves(Elves elves)
    {
        if (elves != null)
        {
            int attackDamage = this.Attack;
            if (this.Axe != null)
            {
                attackDamage += this.Axe.Attack;
            }
            elves.Life -= attackDamage - elves.Defense;
        }
    }
}

public class Axe 
{
    public Axe(int attack)
    {
        this.Attack = attack;
    }
    public int Attack { get; set; }
}

public class Helmet
{
    public Helmet(int defense)
    {
        this.Defense = defense;
    }
    public int Defense { get; set;}
}