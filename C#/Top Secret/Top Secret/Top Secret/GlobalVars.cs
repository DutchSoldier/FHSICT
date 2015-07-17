using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Top_Secret
{
    public static class GlobalVars
    {
        public static int resolutionWidth;
        public static int resolutionHeight;

        public enum gameState
        {
            mainMenuStart,
            mainMenuHighscore,
            highScoreMenuTerug,
            caracterMenuKies,
            caracterMenuTerug,
            moeilijkheidMenuKiesEasy,
            moeilijkheidMenuKiesMedium,
            moeilijkheidMenuKiesHard,
            moeilijkheidMenuTerugEasy,
            moeilijkheidMenuTerugMedium,
            moeilijkheidMenuTerugHard,
            displayingNormalLevel,          
            levelScore
            
        }
        public static gameState currentState;
    }
}
