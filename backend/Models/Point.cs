using System;
using System.Collections.Generic;

namespace CodeBattle.PointWar.Server.Models
{
    public class Point
    {
        public int X_Point { get; set; }
        public int Y_Point { get; set; }
        
        public List<Tuple<HashSet<int>>> Points = new List<Tuple<HashSet<int>>>();

        public IEnumerable<int> GetNeighbors4(int p)
        {
            yield return new Point(X - 1, Y);
            yield return new Point(X, Y - 1);
            yield return new Point(X + 1, Y);
            yield return new Point(X, Y + 1);
        }
        
        public IEnumerable<Point> GetNeighbors8(Point p)
        {
            yield return new Point(p.X - 1, p.Y);
            yield return new Point(p.X - 1, p.Y - 1);
            yield return new Point(p.X, p.Y - 1);
            yield return new Point(p.X + 1, p.Y - 1);
            yield return new Point(p.X + 1, p.Y);
            yield return new Point(p.X + 1, p.Y + 1);
            yield return new Point(p.X, p.Y + 1);
            yield return new Point(p.X - 1, p.Y + 1);
        }
        
        private IEnumerable<HashSet<Point>> GetClosedArea(Point lastPoint)
        {
            var myState = this[lastPoint];
            //перебираем пустые точки в округе и пытаемся пробиться из них к краю поля
            foreach (var n in GetNeighbors4(lastPoint))
                if (this[n] != myState)
                {
                    //ищем замкнутую область
                    var list = GetClosedArea(n, myState);
                    if (list != null)//нашли?
                        yield return list;//возвращаем занятые точки
                }
        }
    }
}