using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XO3
{
    public enum Result { X, O, Non, Game, Error };

    public class TPosition
    {
        public char[,] P;
        public int cell_count{ get{return 4;} }
        public TPosition()
        {
            // P = new char[cell_count, cell_count];
            P = new char[cell_count, cell_count]; // labvit
            Clear();
        }

        public string GetS()
        {
            string res = "";

            // for (int i = 0; i < 3; i++)
            // {
            //     for (int j = 0; j < 3; j++)
            for (int i = 0; i < cell_count; i++) // labvit
            {
                for (int j = 0; j < cell_count; j++) // labvit
                {
                    res = res + P[i, j];
                }
            }

            return res;
        }

        public int[] Get_ij(int i)
        {
            int[] ij = new int[2];

            // ij[0] = i / 3;
            // ij[1] = i % 3;
            ij[0] = i / cell_count; // labvit
            ij[1] = i % cell_count; // labvit

            return ij;
        }

        public void GetRand(Random rnd, out int i, out int j)
        {
            int pointer = 0;

            // int[] ij = new int[9];
            int[] ij = new int[cell_count]; // labvit

            // for (i = 0; i < 3; i++)
            // {
            //     for (j = 0; j < 3; j++)
            for (i = 0; i < cell_count; i++) // labvit
            {
                for (j = 0; j < cell_count; j++) // labvit
                {
                    if (P[i, j] == ' ')
                    {
                        // ij[pointer] = i * 3 + j;
                        ij[pointer] = i * cell_count + j; // labvit
                        pointer++;
                    }
                }
            }

            if (pointer == 0)
            {
                i = -1;
                j = -1;
            }
            else
            {
                int n = ij[rnd.Next(pointer)];
                // i = n / 3;
                // j = n % 3;
                i = n / cell_count; // labvit
                j = n % cell_count; // labvit
            }

        }

        public TPosition Copy()
        {
            TPosition res = new TPosition();

            // for (int i = 0; i < 3; i++)
            // {
            //     for (int j = 0; j < 3; j++)
            for (int i = 0; i < cell_count; i++) // labvit
            {
                for (int j = 0; j < cell_count; j++)  // labvit
                {
                    res.P[i, j] = P[i, j];
                }
            }

            return res;
        }

        public void Clear()
        {
            // for (int i = 0; i < 3; i++)
            // {
            //     for (int j = 0; j < 3; j++)
            for (int i = 0; i < cell_count; i++)
            {
                for (int j = 0; j < cell_count; j++) // labvit
                {
                    P[i, j] = ' ';
                }
            }
        }

        public Result Who(out int i1, out int j1, out int i2, out int j2)
        {
            i1 = -1; j1 = -1;
            i2 = -1; j2 = -1;
            // { labvit
            for(int i = 0; i < cell_count; i++){
                char pi = P[i,0];
                {
                    int j = 1;
                    for(; j < cell_count; j++)
                       if( pi != P[i,j]) 
                         break;
                    if( j == cell_count - 1){
                        i1 = i; j1 = 0;
                        i2 = 0i; j2 = j;
                        
                        if (P[i1,j1] == 'X') { return Result.X; }
                        if (P[i1,j1] == 'O') { return Result.O; }

                    }
                }
                pi = P[0,i];
                {
                    int j = 1;
                    for(; j < cell_count; j++)
                       if( pi != P[j,i]) 
                         break;
                    if( j == cell_count - 1){
                        i1 = 0; j1 = i;
                        i2 = j; j2 = i;
                        
                        if (P[i1,j1] == 'X') { return Result.X; }
                        if (P[i1,j1] == 'O') { return Result.O; }

                    }
                }
                   
            }

            {
                char pi = P[0,0];
                int i = 0;
                for( ; i < cell_count; i++){
                    if( pi != P[i,i]) 
                             break;
                }
                if( i == cell_count - 1){
                    i1 = 0; j1 = 0;
                    i2 = i; j2 = i;
                    
                    if (P[i1,j1] == 'X') { return Result.X; }
                    if (P[i1,j1] == 'O') { return Result.O; }

                }
            }

            {
                char pi = P[0,cell_count-1];
                int i = 0;
                for( ; i < cell_count; i++){
                    if( pi != P[i,cell_count - i - 1]) 
                             break;
                }
                if( i == cell_count - 1){
                    i1 = 0; j1 = i;
                    i2 = i; j2 = 0;
                    
                    if (P[i1,j1] == 'X') { return Result.X; }
                    if (P[i1,j1] == 'O') { return Result.O; }

                }
            }


            for (int i = 0; i < cell_count; i++)
            {
                for (int j = 0; j < cell_count; j++)
                {
                    if(P[i, j] == ' ')
                    {
                        return Result.Game;
                    }
                }
            }

            return Result.Non;
            // } labvit
/*

            if ((P[0, 0] == P[0, 1]) && (P[0, 1] == P[0, 2]))
            {
                i1 = 0; j1 = 0;
                i2 = 0; j2 = 2;

                if (P[0, 0] == 'X') { return Result.X; }
                if (P[0, 0] == 'O') { return Result.O; }
            }

            if ((P[1, 0] == P[1, 1]) && (P[1, 1] == P[1, 2]))
            {
                i1 = 1; j1 = 0;
                i2 = 1; j2 = 2;

                if (P[1, 0] == 'X') { return Result.X; }
                if (P[1, 0] == 'O') { return Result.O; }
            }

            if ((P[2, 0] == P[2, 1]) && (P[2, 1] == P[2, 2]))
            {
                i1 = 2; j1 = 0;
                i2 = 2; j2 = 2;

                if (P[2, 0] == 'X') { return Result.X; }
                if (P[2, 0] == 'O') { return Result.O; }
            }

            if ((P[0, 0] == P[1, 0]) && (P[1, 0] == P[2, 0]))
            {
                i1 = 0; j1 = 0;
                i2 = 2; j2 = 0;

                if (P[0, 0] == 'X') { return Result.X; }
                if (P[0, 0] == 'O') { return Result.O; }
            }

            if ((P[0, 1] == P[1, 1]) && (P[1, 1] == P[2, 1]))
            {
                i1 = 0; j1 = 1;
                i2 = 2; j2 = 1;

                if (P[0, 1] == 'X') { return Result.X; }
                if (P[0, 1] == 'O') { return Result.O; }
            }

            if ((P[0, 2] == P[1, 2]) && (P[1, 2] == P[2, 2]))
            {
                i1 = 0; j1 = 2;
                i2 = 2; j2 = 2;

                if (P[0, 2] == 'X') { return Result.X; }
                if (P[0, 2] == 'O') { return Result.O; }
            }

            if ((P[0, 0] == P[1, 1]) && (P[1, 1] == P[2, 2]))
            {
                i1 = 0; j1 = 0;
                i2 = 2; j2 = 2;

                if (P[0, 0] == 'X') { return Result.X; }
                if (P[0, 0] == 'O') { return Result.O; }
            }

            if ((P[0, 2] == P[1, 1]) && (P[1, 1] == P[2, 0]))
            {
                i1 = 0; j1 = 2;
                i2 = 2; j2 = 0;

                if (P[0, 2] == 'X') { return Result.X; }
                if (P[0, 2] == 'O') { return Result.O; }
            }
*/
            // for (int i = 0; i < 3; i++)
            // {
            //     for (int j = 0; j < 3; j++)
            //     {
            //         if(P[i, j] == ' ')
            //         {
            //             return Result.Game;
            //         }
            //     }
            // }

            // return Result.Non;
        }

        public bool Mark(int i, int j, char C)
        {
            if (P[i,j] == ' ')
            {
                P[i, j] = C;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
