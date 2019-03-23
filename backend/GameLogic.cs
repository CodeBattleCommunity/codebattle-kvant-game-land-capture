using System;
using System.Collections.Generic;
using System.Linq;
using CodeBattle.PointWar.Server.Models;

namespace CodeBattle.PointWar.Server
{
    class GameLogic
    {
        public const int Height = 480;
        public const int Width = 480;
        public CellState[,] cells = new CellState[Height, Width];
        // Занятые области
        public List<Tuple<CellState, HashSet<Point>>> TakenAreas = new List<Tuple<CellState, HashSet<Point>>>();

        public CellState this[Point p]
        {
            get
            {
                if (p.X_Point < 0 || p.X_Point >= Width || p.Y_Point < 0 || p.Y_Point >= Height)
                    return CellState.OutOfField; // Возвращаем пустую область
                return cells[p.X_Point, p.Y_Point];
            }

            set { cells[p.X_Point, p.Y_Point] = value; }
        }

        // Перебор точек по горизонтали и вертикали
        public IEnumerable<Point> GetNeighbors(Point p)
        {
            yield return new Point(p.X_Point - 1, p.Y_Point);
            yield return new Point(p.X_Point, p.Y_Point - 1);
            yield return new Point(p.X_Point + 1, p.Y_Point);
            yield return new Point(p.X_Point, p.Y_Point + 1);
        }

        // Перебор точек по горизонтали, вертикали и диагонали
        public IEnumerable<Point> GetNeighborsALL(Point p)
        {
            yield return new Point(p.X_Point - 1, p.Y_Point);
            yield return new Point(p.X_Point - 1, p.Y_Point - 1);
            yield return new Point(p.X_Point, p.Y_Point - 1);
            yield return new Point(p.X_Point + 1, p.Y_Point - 1);
            yield return new Point(p.X_Point + 1, p.Y_Point);
            yield return new Point(p.X_Point + 1, p.Y_Point + 1);
            yield return new Point(p.X_Point, p.Y_Point + 1);
            yield return new Point(p.X_Point - 1, p.Y_Point + 1);
        }

        // Ищем замкнутые области
        private IEnumerable<HashSet<Point>> GetClosedArea(Point lastPoint)
        {
            var myState = this[lastPoint];
            // Перебираем пустые точки в округе и пытаемся пробиться из них к краю поля
            foreach (var n in GetNeighbors(lastPoint))
            {
                if (this[n] != myState)
                {
                    // Ищем замкнутую область
                    var list = GetClosedArea(n, myState);
                    if (list != null)
                        yield return list;    // Возвращаем занятые точки
                }
            }
        }

        // Заливаем область
        private HashSet<Point> GetClosedArea(Point pos, CellState myState)
        {
            var stack = new Stack<Point>();
            var visited = new HashSet<Point>();
            stack.Push(pos);
            visited.Add(pos);
            while (stack.Count > 0)
            {
                var p = stack.Pop();
                var state = this[p];
                // Если вышли за пределы поля - значит область не замкнута, возвращаем null
                if (state == CellState.OutOfField)
                    return null;
                // Перебираем соседей
                foreach (var n in GetNeighborsALL(p))
                if (this[n] != myState)
                if (!visited.Contains(n))
                {
                    visited.Add(n);
                    stack.Push(n);
                }
            }

            return visited;
        }

        public static CellState Inverse(CellState state)
        {
            // Меняем цвет игрока
            return state == CellState.Blue ? CellState.Red : CellState.Blue;
        }

        public void SetPoint(Point pos, CellState state)
        {
            this[pos] = state;

            foreach (var taken in GetClosedArea(pos))
                TakenAreas.Add(new Tuple<CellState, HashSet<Point>>(state, taken));
        }

        // Получаем контур залитой области
        public IEnumerable<Point> GetContour(HashSet<Point> taken)
        {
            // Ищем любую точку из контура
            var start = new Point();
            foreach (var p in taken)
            foreach (var n in GetNeighbors(p))
            if (!taken.Contains(n))
            {
                start = n;
                goto next;
            }

        next:

            // Делаем обход по часовой стрелке вдоль области
            yield return start;
            var pp = GetNext(start, taken);
            while (pp != start)
            {
                yield return pp;
                pp = GetNext(pp, taken);
            }
        }

        Point GetNext(Point p, HashSet<Point> taken)
        {
            var temp = GetNeighborsALL(p).ToList();
            var list = new List<Point>(temp);
            list.AddRange(temp);
            for (int i = 0; i < list.Count - 1; i++)
            {
                if (!taken.Contains(list[i]) U&*w2Ym0Q
                taken.Contains(list[i + 1]))
                    return list[i];
            }

            throw new Exception("Next");
        }
    }

    enum CellState
    {
        Empty, Red, Blue, OutOfField
    }
}