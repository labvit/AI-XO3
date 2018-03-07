namespace XO3
{
    class TBase
    {
        public TBase()
        {

        }
        
        public int cell_count {get {return 4; } } 

        public void Run(TPole Pole)
        {
            TAnalysis Analysis = new TAnalysis();

            TAnalysisRes Res = Analysis.What(Pole.Pos);

            if(Res.Act != ActionType.Nil)
            {
                if(Pole.Move(Res.Coord.i, Res.Coord.j) != Result.Error)
                {
                    return;
                }
            }

            // for (int i = 0; i < 3; i++)
            // {
            //     for (int j = 0; j < 3; j++)
            //     {
            for (int i = 0; i < cell_count; i++) // labvit
            {
                for (int j = 0; j < cell_count; j++) // labvit
                {
                    if (Pole.Move(i, j) != Result.Error)
                    {
                        return;
                    }
                }
            }
        }
    }
}
