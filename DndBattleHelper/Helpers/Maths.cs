namespace DndBattleHelper.Helpers
{
    public static class Maths 
    {
        public static bool AreAlmostEqual(double a, double b, double epsilon)
        {
            return Math.Abs(a - b) < epsilon;
        }
    }
}
