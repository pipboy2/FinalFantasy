using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FinalFantasy.Models;

namespace FinalFantasy.DAL
{
    public class FinalFantasyInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<FinalFantasyContext>
    {
        protected override void Seed(FinalFantasyContext context)
        {
            var classes = new List<Roll>
            {
                new Roll{RollAbr="GLD",RollName="Gladiator", RaidDate=DateTime.Parse("2019-04-01")},
                new Roll{RollAbr="PUG",RollName="Pugilist", RaidDate=DateTime.Parse("2019-09-06")},
                new Roll{RollAbr="MAR",RollName="Marauder", RaidDate=DateTime.Parse("2019-09-05")},
                new Roll{RollAbr="LAN",RollName="Lancer", RaidDate=DateTime.Parse("2019-09-01")},
                new Roll{RollAbr="ARC",RollName="Archer", RaidDate=DateTime.Parse("2019-05-01")},
                new Roll{RollAbr="ROG",RollName="Rogue", RaidDate=DateTime.Parse("2019-09-02")},
                new Roll{RollAbr="CON",RollName="Conjurer", RaidDate=DateTime.Parse("2019-08-01")},
                new Roll{RollAbr="SCH",RollName="Arcanist", RaidDate=DateTime.Parse("2019-09-01")}
            };

            classes.ForEach(s => context.Rolls.Add(s));
            context.SaveChanges();
            var jobs = new List<Job>
            {
                new Job{JobID=1,Title="Paladin",Hours=3},
                new Job{JobID=2,Title="Monk",Hours=3},
                new Job{JobID=3,Title="Warrior",Hours=3},
                new Job{JobID=4,Title="Dragoon",Hours=3},
                new Job{JobID=5,Title="Bard",Hours=3},
                new Job{JobID=6,Title="Ninja",Hours=3},
                new Job{JobID=7,Title="Whithe Mage",Hours=3},
                new Job{JobID=8,Title="Scholar",Hours=3},
            };

            jobs.ForEach(s => context.Jobs.Add(s));
            context.SaveChanges();
            var raids = new List<Raid>
            {
                new Raid{RollID=1, JobID=1, Day=Day.M},
                new Raid{RollID=1, JobID=2, Day=Day.F},
                new Raid{RollID=2, JobID=4, Day=Day.TH},
                new Raid{RollID=3, JobID=5, Day=Day.M},
                new Raid{RollID=3, JobID=6, Day=Day.W},
                new Raid{RollID=4, JobID=3, Day=Day.W},
                new Raid{RollID=4, JobID=8, Day=Day.M},
                new Raid{RollID=5, JobID=7, Day=Day.F},
                new Raid{RollID=6, JobID=4, Day=Day.F},
                new Raid{RollID=6, JobID=1, Day=Day.TH},
                new Raid{RollID=7, JobID=3, Day=Day.TU},
            };
            raids.ForEach(s => context.Raids.Add(s));
            context.SaveChanges();
        }

    }
}