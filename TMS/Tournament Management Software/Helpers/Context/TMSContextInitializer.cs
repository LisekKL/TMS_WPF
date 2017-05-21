using System;
using System.Collections.ObjectModel;
using System.Data.Entity;
using Tournament_Management_Software.Helpers.Enums;
using Tournament_Management_Software.Model;

namespace Tournament_Management_Software.Helpers.Context
{
    public class TMSContextInitializer : DropCreateDatabaseAlways<TMSContext>
    {
        //public override void InitializeDatabase(TMSContext context)
        //{
        //    //context.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction,
        //    //    $"ALTER DATABASE [{context.Database.Connection.Database}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE");
        //    base.InitializeDatabase(context);
        //}
        protected override void Seed(TMSContext context)
        {
            //Create Tournament --> Base class in Database
            var tournaments = new ObservableCollection<Tournament>()
            {
                new Tournament()
                {
                    Name = "Tournament #1",
                    Location = "Lublin",
                    StartDate = DateTime.Parse("2017-06-20"),
                    Information = "Testing purposes"
                }
            };
            context.Tournaments.AddRange(tournaments);

            //Initiate AgeClasses
            var ageClasses = new ObservableCollection<AgeClass>()
            {
                new AgeClass() { AgeClassName = "Smurfs", MinYear = 2006, MaxYear = 2007},
                new AgeClass() { AgeClassName = "Kids", MinYear = 2008, MaxYear = 2009},
                new AgeClass() { AgeClassName = "Juniors", MinYear = 2010, MaxYear = 2011},
                new AgeClass() { AgeClassName = "Freshmen", MinYear = 2012, MaxYear = 2013}
            };

            context.AgeClasses.AddRange(ageClasses);

            var weightClasses = new ObservableCollection<WeightClass>()
            {
                //WeightClasses for Smurfs 
                new WeightClass()
                {
                    AgeClassId = ageClasses[0].AgeClassId,
                    WeightClassName = "FeatherWeight",
                    MinWeight = 45,
                    MaxWeight = 50
                },
                new WeightClass()
                {
                    AgeClassId = ageClasses[0].AgeClassId,
                    WeightClassName = "LightWeight",
                    MinWeight = 51,
                    MaxWeight = 54
                },
                new WeightClass()
                {
                    AgeClassId = ageClasses[0].AgeClassId,
                    WeightClassName = "Standard",
                    MinWeight = 55,
                    MaxWeight = 60
                },
                new WeightClass()
                {
                    AgeClassId = ageClasses[0].AgeClassId,
                    WeightClassName = "HeavyWeight",
                    MinWeight = 61,
                    MaxWeight = 80
                },

                //WeightClasses for Kids
                new WeightClass()
                {
                    AgeClassId = ageClasses[1].AgeClassId,
                    WeightClassName = "FeatherWeight",
                    MinWeight = 45,
                    MaxWeight = 50
                },
                new WeightClass()
                {
                    AgeClassId = ageClasses[1].AgeClassId,
                    WeightClassName = "MiniWeight",
                    MinWeight = 50,
                    MaxWeight = 80
                },

                //WeightClasses for Juniors
                new WeightClass()
                {
                    AgeClassId = ageClasses[2].AgeClassId,
                    WeightClassName = "LightWeight",
                    MinWeight = 52,
                    MaxWeight = 61
                },
                new WeightClass()
                {
                    AgeClassId = ageClasses[2].AgeClassId,
                    WeightClassName = "HeavyWeight",
                    MinWeight = 62,
                    MaxWeight = 70
                }
            };

            context.WeightClasses.AddRange(weightClasses);

            //Initiate Contestants
            var allContestants = new ObservableCollection<Contestant>
            {
                new Contestant()
                {
                    FirstName = "Adam",
                    LastName = "Małysz",
                    DateOfBirth = DateTime.Parse("2008-12-25"),
                    Gender = GenderEnum.Male,
                    Height = 165,
                    Weight = 68.5,
                    TournamentId = tournaments[0].TournamentId
                },
                new Contestant()
                {
                    FirstName = "Ewelina",
                    LastName = "Flinta",
                    DateOfBirth = DateTime.Parse("2010-10-10"),
                    Gender = GenderEnum.Female,
                    Height = 155,
                    Weight = 58,
                    TournamentId = tournaments[0].TournamentId
                },
                new Contestant()
                {
                    FirstName = "Anna",
                    LastName = "Zuziak",
                    DateOfBirth = DateTime.Parse("2008-03-10"),
                    Gender = GenderEnum.Female,
                    Height = 159,
                    Weight = 54,
                    TournamentId = tournaments[0].TournamentId
                },
                new Contestant()
                {
                    FirstName = "Patryk",
                    LastName = "Goloch",
                    DateOfBirth = DateTime.Parse("2006-11-09"),
                    Gender = GenderEnum.Male,
                    Height = 149,
                    Weight = 52,
                    TournamentId = tournaments[0].TournamentId
                },
                new Contestant()
                {
                    FirstName = "Augustyn",
                    LastName = "Augystynin",
                    DateOfBirth = DateTime.Parse("2008-12-12"),
                    Gender = GenderEnum.Male,
                    Height = 152,
                    Weight = 58,
                    TournamentId = tournaments[0].TournamentId
                },
                new Contestant()
                {
                    FirstName = "Ewa",
                    LastName = "Kozak",
                    DateOfBirth = DateTime.Parse("2009-02-15"),
                    Gender = GenderEnum.Female,
                    Height = 156,
                    Weight = 54,
                    TournamentId = tournaments[0].TournamentId
                },
                new Contestant()
                {
                    FirstName = "Jan",
                    LastName = "Kowalski",
                    DateOfBirth = DateTime.Parse("2009-01-25"),
                    Gender = GenderEnum.Male,
                    Height = 160,
                    Weight = 64.5,
                    TournamentId = tournaments[0].TournamentId
                }
            };

            context.Contestants.AddRange(allContestants);

            context.SaveChanges();
            //base.Seed(context);
        }
    }
}
