using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;


/// <summary>
/// Clase para el personaje wizardo
/// </summary>
public class Wizard
{
    public Wizard(string name, int attack, int defense, int life)
    {
        this.Name = name;
        this.Attack = attack;
        this.Defense = defense;
        this.Life = life;
    }

    public int Life { get; set; }
    public int Attack { get; set; }
    public int Defense { get; set; }
    public string Name { get; set; }
    public MagicStaff Staff { get; set; }
    public SpellBook Book { get; set;}

    public void MagicAtack(string spell, ref int targetLife, int defense)
    {
        Spell choice = this.Book.GetSpell(spell);
        if (choice == null) { return;}
        int attackDamage = this.Attack;
        attackDamage += choice.Power;
        if (this.Staff != null)
        {
            attackDamage += this.Staff.Attack;
        }
        targetLife -= attackDamage - defense;
    }
    public void MagicDefense(string spell, ref int targetDefense)
    {
        Spell choice = this.Book.GetSpell(spell);
        if (choice == null) { return;}
        int def = choice.Defense;
        if (this.Staff != null)
        {
            def += this.Staff.Attack;
        }
        targetDefense += def;
    }
}
public class MagicStaff
{
    public MagicStaff(string name, int attack)
    {
        this.Name = name;
        this.Attack = attack;
    }

    public string Name { get; set; }
    public int Attack { get; set; }
}

public class SpellBook
{
    private List<Spell> spells = new List<Spell>();

    public Spell GetSpell(string name)
    {
        foreach (Spell spell in spells)
        {
            if (spell.Name == name)
            {
                return spell;
            }
        }
        return null;
    }

    public void AddSpell(Spell spell)
    {
        spells.Add(spell);
    }
}

public class Spell
{
    public Spell(string name, int power, int defense)
    {
        this.Name = name;
        this.Power = power;
        this.Defense = defense;
    }
    public string Name { get; }
    public int Power { get; }
    public int Defense { get; }
}