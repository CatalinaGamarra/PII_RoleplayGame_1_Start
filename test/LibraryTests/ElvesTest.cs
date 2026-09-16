using NUnit.Framework;

namespace Ucu.Poo.RolePlayGame.Tests
{
    public class ElvesTests
    {
        [Test]
        public void HelpOther_WhenHelpingAnotherCharacter_IncreasesLifeByTwo()
        {
            Elves elf = new Elves(10, 5, 3);
            int life = 10;

            elf.helpOther(ref life);

            Assert.That(life, Is.EqualTo(12));
        }

        [Test]
        public void ShootWizard_WithBowAndArrows_DecreasesLifeAndConsumesArrow()
        {
            Elves elf = new Elves(10, 5, 3);
            elf.Bow = new Bow(5);
            Wizard wizard = new Wizard("Gandalf", 4, 3, 20);

            elf.shootWizard(wizard);

            // Daño: ataque 5 + arco 2 - defensa 3 = 4.
            Assert.That(wizard.Life, Is.EqualTo(16));
            Assert.That(elf.Bow.Quantity, Is.EqualTo(4));
        }

        [Test]
        public void ShootWizard_WithoutArrows_DoesNotChangeLife()
        {
            Elves elf = new Elves(10, 5, 3);
            elf.Bow = new Bow(0);
            Wizard wizard = new Wizard("Gandalf", 4, 3, 20);

            elf.shootWizard(wizard);

            Assert.That(wizard.Life, Is.EqualTo(20));
            Assert.That(elf.Bow.Quantity, Is.EqualTo(0));
        }

        [Test]
        public void ShootElves_WhenTargetHasCape_CapeReducesDamage()
        {
            Elves elf = new Elves(10, 5, 3);
            elf.Bow = new Bow(5);
            Elves target = new Elves(20, 1, 2);
            target.Cape = new Cape(3);

            elf.shootElves(target);

            // Daño: ataque 5 + arco 2 - (defensa 2 + capa 3) = 2.
            Assert.That(target.Life, Is.EqualTo(18));
        }

        [Test]
        public void ShootDwarf_WhenTargetHasHelmet_HelmetReducesDamage()
        {
            Elves elf = new Elves(10, 5, 3);
            elf.Bow = new Bow(5);
            Dwarf dwarf = new Dwarf("Gimli", 3, 1, 20);
            dwarf.Helmet = new Helmet(4);

            elf.shootDwarf(dwarf);

            // Daño: ataque 5 + arco 2 - (defensa 1 + casco 4) = 2.
            Assert.That(dwarf.Life, Is.EqualTo(18));
        }
    }
}
