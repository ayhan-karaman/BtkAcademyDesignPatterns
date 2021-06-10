using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            ScoringAlgoritm scoringAlgoritm;
            Console.WriteLine("Mans");
            scoringAlgoritm = new MensScoringAlgoritm();

            Console.WriteLine(scoringAlgoritm.GenerateScore(10,new TimeSpan(0,2,34)));

            Console.WriteLine("\n*******************\n");

            Console.WriteLine("Women");
            scoringAlgoritm = new WomensScoringAlgoritm();
            Console.WriteLine(scoringAlgoritm.GenerateScore(10, new TimeSpan(0, 2, 34)));

            Console.WriteLine("\n*******************\n");

            Console.WriteLine("Children");
            scoringAlgoritm = new ChildrensScoringAlgoritm();
            Console.WriteLine(scoringAlgoritm.GenerateScore(10, new TimeSpan(0, 2, 34)));


            Console.ReadLine();
        }
    }
   abstract class ScoringAlgoritm
    {
       
        public int GenerateScore(int hits, TimeSpan time)
        {
            int score = CalculateBaseScore(hits);
            int reduction = CalculateReduction(time);
            return CalculateOverallScore(score, reduction);
        }

        public abstract int CalculateOverallScore(int score, int reduction);


        public abstract int CalculateReduction(TimeSpan time);
        

        public abstract int CalculateBaseScore(int hits);
    }
    class MensScoringAlgoritm : ScoringAlgoritm
    {
        public override int CalculateBaseScore(int hits)
        {
            return hits * 100;
        }

        public override int CalculateOverallScore(int score, int reduction)
        {
            return score - reduction;
        }

        public override int CalculateReduction(TimeSpan time)
        {
            return (int)time.TotalSeconds / 5;
        }
    }

    class WomensScoringAlgoritm : ScoringAlgoritm
    {
        public override int CalculateBaseScore(int hits)
        {
            return hits * 100;
        }

        public override int CalculateOverallScore(int score, int reduction)
        {
            return score - reduction;
        }

        public override int CalculateReduction(TimeSpan time)
        {
            return (int)time.TotalSeconds / 3;
        }
    }

    class ChildrensScoringAlgoritm : ScoringAlgoritm
    {
        public override int CalculateBaseScore(int hits)
        {
            return hits * 80;
        }

        public override int CalculateOverallScore(int score, int reduction)
        {
            return score - reduction;
        }

        public override int CalculateReduction(TimeSpan time)
        {
            return (int)time.TotalSeconds / 2;
        }
    }
}
