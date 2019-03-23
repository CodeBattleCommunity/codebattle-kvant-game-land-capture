using CodeBattle.PointWar.Server.Models;

namespace CodeBattle.PointWar.Server
{
    class GameLogic
    {
        public int Height = Map.Height;
        public int Width = Map.Width;

        // Перебор точек по горизонтали и вертикали
        public IEnumerable<Point> GetNeighbors(Point p)
        {
            yield return new Point(p.X_Point - 1, p.Y_Point);
            yield return new Point(p.X_Point, p.Y_Point - 1);
            yield return new Point(p.X_Point + 1, p.Y_Point);
            yield return new Point(p.X_Point, p.Y_Point + 1);
        }

        // Поиск замкнутых областей
        public Enumerable<Point> GetClosedArea(Point p)
        {
            var lp = this[p];

            foreach(var i in GetNeighbors(lp))
            {
                
            }
        }
    }
}