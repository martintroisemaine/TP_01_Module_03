using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_01_Module_03.BO;

namespace TP_01_Module_03
{
    class Program
    {
        private static List<Auteur> ListeAuteurs = new List<Auteur>();
        private static List<Livre> ListeLivres = new List<Livre>();

        static void Main(string[] args)
        {
            InitialiserDatas();

            // Afficher la liste des prénoms des auteurs dont le nom commence par "G"
            var question_1 = ListeAuteurs.Where(a => a.Nom.StartsWith("G"));
            foreach (var auteur in question_1)
            {
                Console.WriteLine(auteur.Prenom);
            }
            Console.WriteLine(Environment.NewLine);

            // Afficher l’auteur ayant écrit le plus de livres
            var question_2 = ListeLivres.GroupBy(l => l.Auteur).Select(a => new { Key = a.Key, total = a.Count() }).OrderByDescending(a => a.total).First().Key;
            Console.WriteLine(question_2.Prenom + " " + question_2.Nom + Environment.NewLine);

            // Afficher le nombre moyen de pages par livre par auteur
            var question_3 = ListeLivres.GroupBy(l => l.Auteur).Select(a => new { Key = a.Key, avg = a.Average(l => l.NbPages) }).OrderByDescending(a => a.avg);
            foreach(var auteur in question_3)
            {
                Console.WriteLine(auteur.Key.Prenom + " " + auteur.Key.Nom + " Moyenne: " + auteur.avg);
            }
            Console.WriteLine(Environment.NewLine);

            // Afficher le titre du livre avec le plus de pages
            var question_4 = ListeLivres.OrderByDescending(l => l.NbPages).First();
            Console.WriteLine(question_4.Titre + Environment.NewLine);

            // Afficher combien ont gagné les auteurs en moyenne (moyenne des factures)
            var question_5 = ListeAuteurs.Select(a => new { factures = a.Factures });
            var listeFactures = new List<Facture>();
            // foreach (var factures in question_5)
            // {
            //     listeFactures.AddRange(factures);
            // }
            // Console.WriteLine(Environment.NewLine);

            Console.ReadKey();
        }

        private static void InitialiserDatas()
        {
            ListeAuteurs.Add(new Auteur("GROUSSARD", "Thierry"));
            ListeAuteurs.Add(new Auteur("GABILLAUD", "Jérôme"));
            ListeAuteurs.Add(new Auteur("HUGON", "Jérôme"));
            ListeAuteurs.Add(new Auteur("ALESSANDRI", "Olivier"));
            ListeAuteurs.Add(new Auteur("de QUAJOUX", "Benoit"));
            ListeLivres.Add(new Livre(1, "C# 4", "Les fondamentaux du langage", ListeAuteurs.ElementAt(0), 533));
            ListeLivres.Add(new Livre(2, "VB.NET", "Les fondamentaux du langage", ListeAuteurs.ElementAt(0), 539));
            ListeLivres.Add(new Livre(3, "SQL Server 2008", "SQL, Transact SQL", ListeAuteurs.ElementAt(1), 311));
            ListeLivres.Add(new Livre(4, "ASP.NET 4.0 et C#", "Sous visual studio 2010", ListeAuteurs.ElementAt(3), 544));
            ListeLivres.Add(new Livre(5, "C# 4", "Développez des applications windows avec visual studio 2010", ListeAuteurs.ElementAt(2), 452));
            ListeLivres.Add(new Livre(6, "Java 7", "les fondamentaux du langage", ListeAuteurs.ElementAt(0), 416));
            ListeLivres.Add(new Livre(7, "SQL et Algèbre relationnelle", "Notions de base", ListeAuteurs.ElementAt(1), 216));
            ListeAuteurs.ElementAt(0).addFacture(new Facture(3500, ListeAuteurs.ElementAt(0)));
            ListeAuteurs.ElementAt(0).addFacture(new Facture(3200, ListeAuteurs.ElementAt(0)));
            ListeAuteurs.ElementAt(1).addFacture(new Facture(4000, ListeAuteurs.ElementAt(1)));
            ListeAuteurs.ElementAt(2).addFacture(new Facture(4200, ListeAuteurs.ElementAt(2)));
            ListeAuteurs.ElementAt(3).addFacture(new Facture(3700, ListeAuteurs.ElementAt(3)));
        }
    }
}
