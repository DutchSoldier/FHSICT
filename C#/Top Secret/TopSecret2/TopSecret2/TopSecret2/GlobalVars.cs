namespace TopSecret2
{
    public static class GlobalVars
    {
        public const int resolutionWidth = 1920;
        public const int resolutionHeight = 1080;
        public const int playerSpeed = 8;
        public static gameState currentState;
        public static double score;

        public static int damageMelee;
        public static int healthMelee;
        public static int damageRanged;
        public static int healthRanged;
        public static int damageBoss;
        public static int healthBoss;

        public enum gameState
        {
            mainMenu,
            characterMenu,
            moeilijkheidsMenu,
            highScoreMenu,
            highScoreInvullen,
            normalLevel,
            loadingScherm,
            tutorialScherm
        }
    }
}
