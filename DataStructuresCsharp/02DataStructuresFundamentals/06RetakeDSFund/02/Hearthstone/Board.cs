using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hearthstone;

public class Board : IBoard
{
    private Dictionary<string, Card> cardByName;

    private List<Card> cards;

    private MinHeap<Card> cardsHeap;

    public Board()
    {

        cards = new List<Card>();
        cardsHeap = new MinHeap<Card>();
    }


    public bool Contains(string name)
    {
        for (int i = 0; i < this.cards.Count; i++)
        {
            if (cards[i].Name == name)
            {
                return true;

            }
        }

        return false;
    }

    public int Count()
    {
        return this.cards.Count;
    }

    public void Draw(Card card)
    {
        int indexOf = this.cards.IndexOf(card);

        if (indexOf == 1)
        {
            throw new ArgumentException();
        }

       // cardsHeap.Add(card);

        this.cards.Add(card);
    }

    public IEnumerable<Card> GetBestInRange(int start, int end)
    {
        List<Card> toReturn = new List<Card>();

        toReturn = this.cards.Where(c => c.Score >= start && c.Score <= end).OrderByDescending(x=>x.Level).ToList();

        return toReturn;
    }

    public void Heal(int health)
    {
        //Card lessHealthCard = null;

        //int lesshealth = 16;

        //int index = -1;

        //for (int i = 0; i < cards.Count; i++)
        //{
        //    if (cards[i].Health < lesshealth)
        //    {
        //        lesshealth = cards[i].Health;
        //        lessHealthCard = cards[i];
        //        index = i;
        //    }
        //}

        //cards[index].Health += health;

        cardsHeap.Peek().Health += health;

      // int index= cards.IndexOf(cardsHeap.Peek());

      // cards[index].Health += health;

    }

    public IEnumerable<Card> ListCardsByPrefix(string prefix)
    {
        return this.cards.Where(c => c.Name.Contains(prefix)).OrderBy(c => c.Name);

        //List<Card> toReturn = new List<Card>();

        //foreach (var key in cardByName.Keys)
        //{
        //    if (key.Contains(prefix))
        //    {
        //        toReturn.Add(cardByName[key]);
        //    }

        //}

        //return toReturn.OrderBy(c => c.Name);
    }

    public void Play(string attackerCardName, string attackedCardName)
    {
        if (!cardByName.ContainsKey(attackerCardName))
        {
            throw new ArgumentException();
        }

        if (!cardByName.ContainsKey(attackedCardName))
        {
            throw new ArgumentException();
        }

        Card attacker = this.cardByName[attackerCardName];
        Card attacked = this.cardByName[attackedCardName];

        if (attacked.Health <= 0)
        {
            return;

        }

        if (attacker.Level == attacked.Level)
        {
            attacked.Health -= attacker.Damage;

            if (attacked.Health <= 0)
            {
                attacker.Score += attacked.Level;
            }
        }
        else
        {
            throw new ArgumentException();
        }

    }

    public void Remove(string name)
    {
        if (!this.cardByName.ContainsKey(name))
        {
            throw new ArgumentException();
        }
        //  int indexOf = cards.IndexOf(cardByName[name]);

        this.cardByName.Remove(name);
        // cards.RemoveAt(indexOf);
    }

    public void RemoveDeath()
    {
        //for (int i = 0; i < cards.Count; i++)
        //{
        //    if (cards[i].Health <= 0)
        //    {
        //        cardByName.Remove(cards[i].Name);
        //        cards.RemoveAt(i);

        //        i--;

        //    }

        //}

        this.cards.RemoveAll(c => c.Health <= 0);
    }

    public IEnumerable<Card> SearchByLevel(int level)
    {
        return new List<Card>(this.cards.Where(c => c.Level == level)).OrderBy(c => c.Score);

    }
}