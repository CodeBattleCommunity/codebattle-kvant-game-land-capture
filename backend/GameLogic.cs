using System;
using System.Collections.Generic;
using System.Linq;
using CodeBattle.PointWar.Server.Models;

namespace CodeBattle.PointWar.Server
{
    class GameLogic
    {
        // ������� ����� �� ����������� � ���������
        public IEnumerable<Point> GetNeighbors(Point p)
        {
            yield return new Point(p.X_Point - 1, p.Y_Point);
            yield return new Point(p.X_Point, p.Y_Point - 1);
            yield return new Point(p.X_Point + 1, p.Y_Point);
            yield return new Point(p.X_Point, p.Y_Point + 1);
        }

        // ���� ��������� �������
        private IEnumerable<HashSet<Point>> GetClosedArea(Point lastPoint)
        {
            var myState = this[lastPoint];
            // ���������� ������ ����� � ������ � �������� ��������� �� ��� � ���� ����
            foreach (var n in GetNeighbors(lastPoint))
            {
                if (this[n] != myState)
                {
                    // ���� ��������� �������
                    var list = GetClosedArea(n, myState);
                    if (list != null)
                        yield return list;    // ���������� ������� �����
                }
            }
        }
    }
}