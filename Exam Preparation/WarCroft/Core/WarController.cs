using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
	public class WarController
    {
        private readonly ICollection<Character> party;
        private readonly ICollection<Item> itemPool;

		public WarController()
		{
			this.party=new List<Character>();
			this.itemPool=new List<Item>();
		}

		public string JoinParty(string[] args)
        {
            var characterType = args[0];
            var name = args[1];
            Character character = characterType switch
            {
                "Warrior" => new Warrior(name),
                "Priest" => new Priest(name),
                _ => throw new ArgumentException(string.Format(ExceptionMessages.InvalidCharacterType, characterType))
            };
            
			this.party.Add(character);

            return string.Format(SuccessMessages.JoinParty, name);
        }

		public string AddItemToPool(string[] args)
        {
            var name = args[0];

            Item item = name switch
            {
                "FirePotion" => new FirePotion(),
                "HealthPotion" => new HealthPotion(),
                _ => throw new ArgumentException(string.Format(ExceptionMessages.InvalidItem, name))
            };
            
            this.itemPool.Add(item);

            return string.Format(SuccessMessages.AddItemToPool, name);
        }

		public string PickUpItem(string[] args)
        {
            var name = args[0];

            var character = GetCharacterByName(name);

            if (this.itemPool.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.ItemPoolEmpty);
            }

            var item = this.itemPool.Last();
            this.itemPool.Remove(item);
            character.Bag.AddItem(item);

            return string.Format(SuccessMessages.PickUpItem, name, item.GetType().Name);
        }

		public string UseItem(string[] args)
        {
            var characterName = args[0];
            var itemName = args[1];

            var character = GetCharacterByName(characterName);

            var item = character.Bag.GetItem(itemName);

            item.AffectCharacter(character);

            return string.Format(SuccessMessages.UsedItem, characterName, itemName);
        }

        public string GetStats()
		{
            var sb = new StringBuilder();
            foreach (var character in this.party
                .OrderByDescending(x=>x.IsAlive)
                .ThenByDescending(x=>x.Health))
            {
                var status = character.IsAlive ? "Alive" : "Dead";

                sb.AppendLine(string.Format(SuccessMessages.CharacterStats,
                    character.Name, character.Health, character.BaseHealth, character.Armor, character.BaseArmor,
                    status));
            }

            return sb.ToString().TrimEnd();
        }

		public string Attack(string[] args)
        {
            var attackerName = args[0];
            var receiverName = args[1];

            var attacker = GetCharacterByName(attackerName);

            var receiver = GetCharacterByName(receiverName);
            
            if (attacker is Warrior att && att.IsAlive )
            {
                att.Attack(receiver);
            }
            else
            {
                throw new ArgumentException(string.Format(ExceptionMessages.AttackFail,attackerName));
            }

            var sb = new StringBuilder();
            
                sb.AppendLine( string.Format(SuccessMessages.AttackCharacter, attackerName, receiverName,
                    attacker.AbilityPoints, receiverName, receiver.Health, receiver.BaseHealth, receiver.Armor,
                    receiver.BaseArmor));
            
            if (receiver.IsAlive==false)
            {
                sb.AppendLine( string.Format(SuccessMessages.AttackKillsCharacter, receiverName));
            }

            return sb.ToString().TrimEnd();
        }

		public string Heal(string[] args)
        {
            var healerName = args[0];
            var healingReceiverName = args[1];

            var healer = GetCharacterByName(healerName);

            var receiver = GetCharacterByName(healingReceiverName);

            if (healer is Priest priest && healer.IsAlive )
            {
               priest.Heal(receiver);
            }
            else
            {
                throw new ArgumentException(string.Format(ExceptionMessages.HealerCannotHeal,healerName));
            }

            return string.Format(SuccessMessages.HealCharacter, healerName, healingReceiverName, healer.AbilityPoints,
                healingReceiverName, receiver.Health);
        }

        private Character GetCharacterByName(string characterName)
        {
            var character = this.party.FirstOrDefault(x => x.Name == characterName);

            if (character is null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, characterName));
            }

            return character;
        }
    }
}
