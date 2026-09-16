using NUnit.Framework;

namespace Ucu.Poo.RolePlayGame.Tests
{
    public class DwarfTests
    {
        [Test]
        public void PhycalAttackDwarf_WithAxeAgainstHelmet_DecreasesLife()
        {
            Dwarf dwarf = new Dwarf("Gimli", 5, 2, 20);
            dwarf.Axe = new Axe(4);
            Dwarf target = new Dwarf("Thorin", 3, 2, 20);
            target.Helmet = new Helmet(3);

            dwarf.PhycalAttackDwarf(target);

            // Daño: ataque 5 + hacha 4 - (defensa 2 + casco 3) = 4.
            Assert.That(target.Life, Is.EqualTo(16));
        }

        [Test]
        public void PhycalAttackWizard_WithoutAxe_DecreasesLife()
        {
            Dwarf dwarf = new Dwarf("Gimli", 5, 2, 20);
            Wizard wizard = new Wizard("Gandalf", 4, 1, 20);

            dwarf.PhycalAttackWizard(wizard);

            // Daño: ataque 5 - defensa 1 = 4.
            Assert.That(wizard.Life, Is.EqualTo(16));
        }

        [Test]
        public void PhycalAttackElves_WhenTargetHasCape_CapeReducesDamage()
        {
            Dwarf dwarf = new Dwarf("Gimli", 5, 2, 20);
            Elves elf = new Elves(20, 1, 2);
            elf.Cape = new Cape(1);

            dwarf.PhycalAttackElves(elf);

            // Daño: ataque 5 - (defensa 2 + capa 1) = 2.
            Assert.That(elf.Life, Is.EqualTo(18));
        }
    }
}
