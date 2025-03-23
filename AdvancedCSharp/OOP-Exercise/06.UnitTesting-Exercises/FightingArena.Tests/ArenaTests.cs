namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;

    [TestFixture]
    public class ArenaTests
    {
        private const string _defaultName = "TestName";
        private const int _defaultDamage = 69;
        private const int _defaultHP = 420;

        [Test]
        public void Test_ArenaConstructor()
        {
            Arena arena = new();
            Assert.AreEqual(0, arena.Count);
        }

        [Test]
        public void Test_Arena_Enroll()
        {
            Arena arena = new();
            Warrior warrior = new(_defaultName, _defaultDamage, _defaultHP);
            arena.Enroll(warrior);

            Assert.AreEqual(1, arena.Count);
            Assert.AreEqual(_defaultName, arena.Warriors.ElementAt(0).Name);
            Assert.AreEqual(_defaultDamage, arena.Warriors.ElementAt(0).Damage);
            Assert.AreEqual(_defaultHP, arena.Warriors.ElementAt(0).HP);
        }

        [Test]
        public void Test_Enroll_SameName_InvalidOperationException()
        {
            Arena arena = new();
            Warrior warrior = new(_defaultName, _defaultDamage, _defaultHP);
            arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>(() => arena.Enroll(warrior));
        }

        [Test]
        public void Test_Fight()
        {

            Warrior warrior1 = new(_defaultName + "1", _defaultDamage, _defaultHP);
            Warrior warrior2 = new(_defaultName + "2", _defaultDamage, _defaultHP);
            Arena arena = new();
            arena.Enroll(warrior1);
            arena.Enroll(warrior2);

            string attacker = warrior1.Name;
            string defender = warrior2.Name;

            int attackerHP = warrior1.HP - warrior2.Damage;
            int defenderHP = warrior2.HP - warrior1.Damage;

            arena.Fight(attacker, defender);

            Assert.AreEqual(attackerHP, arena.Warriors.ElementAt(0).HP);
            Assert.AreEqual(defenderHP, arena.Warriors.ElementAt(1).HP);
        }

        [TestCase(_defaultName, _defaultName + "2")]
        [TestCase(_defaultName + "1", _defaultName)]
        public void Test_Fight_FighterNotFound_InvalidOperationException(string attackerName, string defenderName)
        {

            Warrior warrior1 = new(_defaultName + "1", _defaultDamage, _defaultHP);
            Warrior warrior2 = new(_defaultName + "2", _defaultDamage, _defaultHP);
            Arena arena = new();
            arena.Enroll(warrior1);
            arena.Enroll(warrior2);

            string attacker = attackerName;
            string defender = defenderName;

            Assert.Throws<InvalidOperationException>(()=> arena.Fight(attacker, defender));                        
        }
    }
}
