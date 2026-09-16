using NUnit.Framework;

namespace Ucu.Poo.RolePlayGame.Tests
{
    public class WizardTests
    {
        private Wizard wizard;

        [SetUp]
        public void Setup()
        {
            SpellBook book = new SpellBook();
            book.AddSpell(new Spell("FireBall", 5, 0));
            book.AddSpell(new Spell("Shield", 0, 4));

            this.wizard = new Wizard("Gandalf", 4, 3, 20);
            this.wizard.Book = book;
        }

        [Test]
        public void MagicAtackWizard_WithStaff_DecreasesLife()
        {
            this.wizard.Staff = new MagicStaff("Vara", 2);
            Wizard target = new Wizard("Saruman", 1, 3, 20);

            this.wizard.MagicAtackWizard("FireBall", target);

            // Daño: ataque 4 + hechizo 5 + vara 2 - defensa 3 = 8.
            Assert.That(target.Life, Is.EqualTo(12));
        }

        [Test]
        public void MagicAtackElves_WhenTargetHasCape_CapeReducesDamage()
        {
            Elves elf = new Elves(20, 1, 2);
            elf.Cape = new Cape(3);

            this.wizard.MagicAtackElves("FireBall", elf);

            // Daño: ataque 4 + hechizo 5 - (defensa 2 + capa 3) = 4.
            Assert.That(elf.Life, Is.EqualTo(16));
        }

        [Test]
        public void MagicAtackDwarf_WhenTargetHasHelmet_HelmetReducesDamage()
        {
            Dwarf dwarf = new Dwarf("Gimli", 3, 1, 20);
            dwarf.Helmet = new Helmet(4);

            this.wizard.MagicAtackDwarf("FireBall", dwarf);

            // Daño: ataque 4 + hechizo 5 - (defensa 1 + casco 4) = 4.
            Assert.That(dwarf.Life, Is.EqualTo(16));
        }

        [Test]
        public void MagicAtackWizard_WithUnknownSpell_DoesNotChangeLife()
        {
            Wizard target = new Wizard("Saruman", 1, 3, 20);

            this.wizard.MagicAtackWizard("Unknown", target);

            Assert.That(target.Life, Is.EqualTo(20));
        }

        [Test]
        public void MagicDefense_WithKnownSpell_IncreasesDefense()
        {
            this.wizard.MagicDefense("Shield");

            // Defensa: 3 + hechizo 4 = 7.
            Assert.That(this.wizard.Defense, Is.EqualTo(7));
        }
    }
}
