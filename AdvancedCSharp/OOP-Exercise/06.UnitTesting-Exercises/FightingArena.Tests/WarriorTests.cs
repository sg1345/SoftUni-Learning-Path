namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class WarriorTests
    {
        private const string _defaultName = "TestName";
        private const int _defaultDamage = 69;
        private const int _defaultHP = 420;
      
        [TestCase(_defaultName,1,100), TestCase(_defaultName, 10, 0), TestCase(_defaultName, int.MaxValue, int.MaxValue)]
        public void Test_WarriorConstructor(string name, int damage, int hp)
        {
            Warrior warrior = new(name, damage, hp);

            Assert.AreEqual(name, warrior.Name);
            Assert.AreEqual(damage, warrior.Damage);
            Assert.AreEqual(hp,warrior.HP);
        }

        [TestCase(null, _defaultDamage, _defaultHP)]
        [ TestCase("", _defaultDamage, _defaultHP)] 
        [TestCase(" ", _defaultDamage, _defaultHP)]
        public void Test_WarriorName_NullEmptyOrWhiteSpace_ArgumentException(string name, int damage, int hp)
        {
            Assert.Throws<ArgumentException>(()=> new Warrior(name, damage, hp));            
        }

        [TestCase(_defaultName, 0, _defaultHP)]
        [TestCase(_defaultName, -1, _defaultHP)]        
        public void Test_WarriorDamage_ZeroOrNegative_ArgumentException(string name, int damage, int hp)
        {
            Assert.Throws<ArgumentException>(() => new Warrior(name, damage, hp));
        }

        [TestCase(_defaultName, _defaultDamage, -1)]
        public void Test_WarriorHP_Negative_ArgumentException(string name, int damage, int hp)
        {
            Assert.Throws<ArgumentException>(() => new Warrior(name, damage, hp));
        }

        [TestCase(_defaultName,30,30,31)]
        [TestCase(_defaultName, 31, 31, 31)] 
        [TestCase(_defaultName, 32, 30, 31)]
        public void Test_Attack(string name, int damage, int dummyDamage, int hp)
        {
            Warrior warrior = new Warrior(name, damage,hp);
            Warrior dummy = new Warrior(name, dummyDamage, hp);

            int warriorExpectedHP = warrior.HP - dummy.Damage;
            int dummyExpectedHP = dummy.HP - warrior.Damage;


            if(dummyExpectedHP < 0)
            {
                dummyExpectedHP = 0;
            }

            warrior.Attack(dummy);

            Assert.AreEqual(warriorExpectedHP, warrior.HP);
            Assert.AreEqual(dummyExpectedHP, dummy.HP);
        }

        [TestCase(_defaultName, 1, 1, 30)]
        [TestCase(_defaultName, 1, 1, 29)]        
        public void Test_Attack_AttackerHP_EqualsOrBelowMinAttackHP_InvalidOperationException
            (string name, int damage, int dummyDamage, int hp)
        {
            Warrior attacker = new Warrior(name, damage, hp);
            Warrior defender = new Warrior(name, dummyDamage, hp+10);

            Assert.Throws<InvalidOperationException>(() => attacker.Attack(defender));
        }

        [TestCase(_defaultName, 1, 1, 30)]
        [TestCase(_defaultName, 1, 1, 29)]
        public void Test_Attack_DefenderHP_EqualsOrBelowMinAttackHP_InvalidOperationException
            (string name, int damage, int dummyDamage, int hp)
        {
            Warrior attacker = new Warrior(name, damage, hp+10);
            Warrior defender = new Warrior(name, dummyDamage, hp);

            Assert.Throws<InvalidOperationException>(() => attacker.Attack(defender));
        }

        [TestCase(_defaultName, 1, 32, 31)]        
        public void Test_Attack_AttackerHP_BelowDefenderDamage_InvalidOperationException
            (string name, int damage, int dummyDamage, int hp)
        {
            Warrior attacker = new Warrior(name, damage, hp);
            Warrior defender = new Warrior(name, dummyDamage, hp + 10);

            Assert.Throws<InvalidOperationException>(() => attacker.Attack(defender));
        }
    }
}