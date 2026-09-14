using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;


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
    
    public int Life { get; set; }
    public int Attack { get; set; }
    public int Defense { get; set; }

    public void PhycalAttack(ref int targetLife, int defense)
    {
        attackDamage = this.Attack;
        attackDamage += this.Axe.Attack;
        targetLife -= attackDamage - defense;
    }
}

public class Axe 
{
    public Axe(int attack)
    {
        this.Attack = attack;
    }
}

public class Helmet
{
    public Helmet(int defense)
    {
        this.Defense = defense;
    }
}