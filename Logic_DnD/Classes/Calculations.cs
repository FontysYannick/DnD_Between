using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic_DnD.Classes
{
    public class Calculations
    {

        public int ConfigureByTable(int score)
        {
            int[] tableX1 = { 0, 2, 4, 6, 8, 10, 12, 14, 16, 18, 20, 22, 24, 26, 28, 30 };      //Even scores
            int[] tableX2 = { 1, 3, 5, 7, 9, 11, 13, 15, 17, 19, 21, 23, 25, 27, 29, 31 };      //Odd scores
            int[] tableY = { -5, -4, -3, -2, -1, 0, +1, +2, +3, +4, +5, +6, +7, +8, +9, +10 };  //Modifier values

            //Ability modifiers are assigned directly from a table.
            int result = 0;
            for (int i = 0; i < tableY.Length; i++)
            {
                if (score == tableX1[i])
                {
                    result = tableY[i];
                }
                else if (score == tableX2[i])
                {
                    result = tableY[i];
                }
            }
            return result;
        }

        public int ConfigureProf(int level)
        {
            int prof = 2;
            if (level >= 17)
            {
                prof = 6;
            }
            else if (level >= 13)
            {
                prof = 5;
            }
            else if (level >= 9)
            {
                prof = 4;
            }
            else if (level >= 5)
            {
                prof = 3;
            }

            return prof;
        }
    }
}
