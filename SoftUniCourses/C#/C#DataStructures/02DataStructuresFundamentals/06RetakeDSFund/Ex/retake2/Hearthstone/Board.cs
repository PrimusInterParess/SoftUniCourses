using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using _02.LegionSystem;

public class Board : IBoard
{
    private Dictionary<string, Card> cards;


    private List<Card> list;

    public Board()
    {
        this.cards = new Dictionary<string, Card>();
        list = new List<Card>();

    }


    public bool Contains(string name)
    {
        if (!this.cards.ContainsKey(name))
        {
            return false;
        }

        return true;
    }

    public int Count()
    {
        return this.cards.Count;
    }

    public void Draw(Card card)
    {
        if (this.cards.ContainsKey(card.Name))
        {
            throw new ArgumentException();
        }


        list.Add(card);

        this.cards.Add(card.Name, card);
    }

    public IEnumerable<Card> GetBestInRange(int start, int end)
    {
        return new List<Card>(
            this.list.FindAll(c => c.Score >= start && c.Score <= end)
                .OrderByDescending(c => c.Level));
    }

    public void Heal(int health)
    {
        int minHealth = 10;

        Card cardToHeal = null;

        foreach (var card in cards.Values)
        {
            if (minHealth > card.Health)
            {
                minHealth = card.Health;
                cardToHeal = card;
            }
        }

        cardToHeal.Health += health;


    }

    public IEnumerable<Card> ListCardsByPrefix(string prefix)
    {
        return list.FindAll(c => c.Name
                .StartsWith(prefix))
            .OrderByDescending(c => c.Name)
            .ThenBy(c => c.Level);
    }

    public void Play(string attackerCardName, string attackedCardName)
    {

        if (!this.cards.ContainsKey(attackerCardName))
        {
            throw new ArgumentException();
        }

        if (!this.cards.ContainsKey(attackedCardName))
        {
            throw new ArgumentException();

        }



        var attacker = this.cards[attackerCardName];
        var attacked = this.cards[attackedCardName];

        if (attacked.Health <= 0)
        {
            return;

        }

        if (attacker.Health <= 0)
        {
            return;

        }

        if (attacker.Level != attacked.Level)
        {
            throw new ArgumentException();
        }

        attacked.Health -= attacker.Damage;

        if (attacked.Health <= 0)
        {
            attacker.Score += attacked.Level;
        }
    }

    public void Remove(string name)
    {
        if (!this.cards.ContainsKey(name))
        {
            throw new ArgumentException();
        }

        var toRemove = cards[name];
      //  list.Remove(toRemove);

        this.cards.Remove(name);
    }

    public void RemoveDeath()
    {
      //  this.list.RemoveAll(c => c.Health <= 0);
    }

    public IEnumerable<Card> SearchByLevel(int level)
    {
        return this.list.FindAll(c => c.Level == level).OrderByDescending(c => c.Score);
    }
}