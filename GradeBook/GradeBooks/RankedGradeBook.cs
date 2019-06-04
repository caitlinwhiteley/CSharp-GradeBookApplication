using System;
using System.Linq;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Standard;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new System.InvalidOperationException("Ranked grading requires at least 5 students");
            }

            var threshold = (int)Math.Ceiling(Students.Count * 0.2);
            var grades = Students.OrderByDescending(e => e.AverageGrade).Select(e => e.AverageGrade).ToList();

            //int percentile = 0;
            //for (int j=1; j<=5; j++)
            //for (int i = threshold*(j-1); i < threshold * j; i++)
            //{
            //    {
            //        if (averageGrade >= grades[i])
            //        {
            //            percentile = j;
            //            break;
            //        }
            //    }
            //}

            //if (percentile == 1)
            //    return 'A';
            //else if (percentile == 2)
            //    return 'B';
            //else if (percentile == 3)
            //    return 'C';
            //else if (percentile == 4)
            //    return 'D';
            //else
            //return 'F';

            if (grades[threshold - 1] <= averageGrade)
                return 'A';
            if (grades[threshold * 2 - 1] <= averageGrade)
                return 'B';
            if (grades[threshold * 3 - 1] <= averageGrade)
                return 'C';
            if (grades[threshold * 4 - 1] <= averageGrade)
                return 'D';
            return 'F';
        }
    }
}




//Ranked-grading grades students not based on their individual performance, but rather 
//their performance compared to their peers.This means the 20% of the students with 
//the highest grade of a class get an A, the next highest 20% get a B, etc.There 
//are many ways to calculate this. I'd recommend figuring out how many students it 
//takes to drop a letter grade (20% of the total number of students) X, put all 
//the average grades in order, then figure out where the input grade would fit in the 
//series of grades. Every X students with higher grades than the input grade knocks 
//the letter grade down until you reach F.

// If the input grade is in the top 20% of the class the method should return an 'A'.


