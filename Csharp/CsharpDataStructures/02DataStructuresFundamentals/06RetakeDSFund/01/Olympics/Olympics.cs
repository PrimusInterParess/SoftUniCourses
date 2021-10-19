using System;
using System.Collections.Generic;
using System.Linq;

public class Olympics : IOlympics
{
    private Dictionary<int, Competitor> competitorsById;

    private Dictionary<int, Competition> competitionById;

    private List<Competitor> competitors;

    public Olympics()
    {
        this.competitorsById = new Dictionary<int, Competitor>();
        this.competitionById = new Dictionary<int, Competition>();
        competitors = new List<Competitor>();


    }

    public void AddCompetition(int id, string name, int participantsLimit)
    {
        if (this.competitionById.ContainsKey(id))
        {
            throw new ArgumentException();

        }
        this.competitionById.Add(id, new Competition(name, id, participantsLimit));
    }

    public void AddCompetitor(int id, string name)
    {
        if (this.competitorsById.ContainsKey(id))
        {
            throw new ArgumentException();
        }



        competitorsById.Add(id, new Competitor(id, name));
        this.competitors.Add(new Competitor(id, name));

    }

    public void Compete(int competitorId, int competitionId)
    {
        if (!(this.competitorsById.ContainsKey(competitorId) && this.competitionById.ContainsKey(competitionId)))
        {
            throw new ArgumentException();
        }

        this.competitionById[competitionId].Competitors.Add(this.competitorsById[competitorId]);

        this.competitorsById[competitorId].TotalScore += this.competitionById[competitionId].Score;
    }

    public int CompetitionsCount()
    {
        return this.competitionById.Count;
    }

    public int CompetitorsCount()
    {
        return this.competitorsById.Count;
    }

    public bool Contains(int competitionId, Competitor comp)
    {
        if (!this.competitionById.ContainsKey(competitionId))
        {
            throw new ArgumentException();

        }

        if (!this.competitorsById.ContainsKey(comp.Id))
        {
            return false;
        }

        return true;

    }

    public void Disqualify(int competitionId, int competitorId)
    {

        if (!this.competitorsById.ContainsKey(competitorId) || !this.competitionById.ContainsKey(competitionId))
        {
            throw new ArgumentException();
        }

        this.competitionById[competitionId].Competitors.Remove(this.competitorsById[competitorId]);

        this.competitors.Remove(this.competitorsById[competitorId]);

        this.competitorsById[competitorId].TotalScore -= this.competitionById[competitionId].Score;

    }

    public IEnumerable<Competitor> FindCompetitorsInRange(long min, long max)
    {
        //List<Competitor> toReturn = this.competitors.Where(c => c.TotalScore > min && c.TotalScore <= max)
        //    .OrderBy(i => i.Id).ToList();

        List<Competitor> inRange = new List<Competitor>();

        foreach (var competitor in this.competitorsById.Values)
        {
            if (competitor.TotalScore > min && competitor.TotalScore <= max)
            {
                inRange.Add(competitor);
            }
        }

        return inRange.OrderBy(i => i.Id);

            // return toReturn;
    }

    public IEnumerable<Competitor> GetByName(string name)
    {
        var toReturn = this.competitorsById.Values
            .Where(c => c.Name == name)
            .OrderBy(s => s.Id)
            .ToList();

        if (toReturn.Count == 0)
        {
            throw new ArgumentException();
        }

        return toReturn;
    }

    public Competition GetCompetition(int id)
    {
        if (this.competitionById.ContainsKey(id))
        {
            return competitionById[id];
        }

        throw new ArgumentException();
    }

    public IEnumerable<Competitor> SearchWithNameLength(int min, int max)
    {
        var toReturn = new List<Competitor>();

        foreach (var compeptitor in this.competitorsById.Values)
        {
            if (compeptitor.Name.Length >= min && compeptitor.Name.Length <= max)
            {
                toReturn.Add(compeptitor);
            }
        }

        return toReturn.OrderBy(i => i.Id);
    }
}