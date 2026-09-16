//--------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------

using System;

namespace Ucu.Poo.RolePlayGame
{
    /// <summary>
    /// Programa principal.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Punto de entrada al programa principal.
        /// </summary>
        public static void Main(string[] args)
        {
            Wizard wiz1 = new Wizard("Taba", 4, 10, 8);
            Spell fireBall = new Spell("FireBall", 4, 0);
            SpellBook book = new SpellBook();
            book.AddSpell(fireBall);
            wiz1.Book = book;

            Wizard wiz2 = new Wizard("Atroden", 1, 5, 8);

            wiz1.MagicAtackWizard("FireBall", wiz2);
            Console.WriteLine(wiz2.Life);
        }
    }
}
