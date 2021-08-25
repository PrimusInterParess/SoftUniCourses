using System;
using System.Collections.Generic;
using System.Linq;

public class Olympics : IOlympics
{
    private Dictionary<int, Competitor> competitors;

    private Dictionary<int, Competition> competitions;

    public Olympics()
    {
        this.competitions = new Dictionary<int, Competition>();
        this.competitors = new Dictionary<int, Competitor>();

    }

    public void AddCompetition(int id, string name, int participantsLimit)
    {
        if (this.competitions.ContainsKey(id))
        {
            throw new ArgumentException();
        }

        this.competitions.Add(id, new Competition(name, id, participantsLimit));
    }

    public void AddCompetitor(int id, string name)
    {
        if (this.competitors.ContainsKey(id))
        {
            throw new ArgumentException();
        }




        this.competitors.Add(id, new Competitor(id, name));
    }

    public void Compete(int competitorId, int competitionId)
    {
        if (!this.competitors.ContainsKey(competitorId))
        {
            throw new ArgumentException();
        }

        if (!this.competitions.ContainsKey(competitionId))
        {
            throw new ArgumentException();
        }

        this.competitors[competitorId].TotalScore += this.competitions[competitionId].Score;
        this.competitions[competitionId].Competitors.Add(this.competitors[competitorId]);
    }

    public int CompetitionsCount()
    {
        return this.competitions.Count;
    }

    public int CompetitorsCount()
    {
        return this.competitors.Count;
    }

    public bool Contains(int competitionId, Competitor comp)
    {
        if (!this.competitions.ContainsKey(competitionId))
        {
            throw new ArgumentException();
        }

        return this.competitors.ContainsKey(comp.Id);
    }

    public void Disqualify(int competitionId, int competitorId)
    {
        if (!this.competitions.ContainsKey(competitionId))
        {
            throw new ArgumentException();
        }

        if (!this.competitors.ContainsKey(competitorId))
        {
            throw new ArgumentException();
        }

        if (!this.competitions[competitionId].Competitors.Contains(this.competitors[competitorId]))
        {
            throw new ArgumentException();
        }

        this.competitors[competitorId].TotalScore -= this.competitions[competitionId].Score;

        this.competitions[competitionId].Competitors.Remove(this.competitors[competitorId]);
    }

    public IEnumerable<Competitor> FindCompetitorsInRange(long min, long max)
    {
        List<Competitor> toReturn = new List<Competitor>();

        foreach (var competitor in competitors.Values)
        {
            if (competitor.TotalScore > min && competitor.TotalScore <= max)
            {
                toReturn.Add(competitor);

            }
        }

        return toReturn.OrderBy(c=>c.Id);


    }

    public IEnumerable<Competitor> GetByName(string name)
    {
        List<Competitor> toReturn = new List<Competitor>();

        foreach (var competitor in competitors.Values)
        {
            if (competitor.Name == name)
            {
                toReturn.Add(competitor);
            }
        }

        if (toReturn.Count == 0)
        {
            throw new ArgumentException();
        }

        return toReturn.OrderBy(c => c.Id);

    }

    public Competition GetCompetition(int id)
    {
        if (!this.competitions.ContainsKey(id))
        {
            throw new ArgumentException();
        }

        return this.competitions[id];
    }

    public IEnumerable<Competitor> SearchWithNameLength(int min, int max)
    {
        List<Competitor> toReturn = new List<Competitor>();

        foreach (var competitor in competitors.Values)
        {
            if (competitor.Name.Length>=min && competitor.Name.Length<=max)
            {
                toReturn.Add(competitor);
            }
        }

        return toReturn.OrderBy(c => c.Id);
    }
}