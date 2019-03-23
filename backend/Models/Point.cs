using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace CodeBattle.PointWar.Server.Models
{
    public class Point
    {
        public int X_Point { get; set; }
        public int Y_Point { get; set; }
        public string Color { get; set; }

        public Point(int y_point, int x_point)
        {
            X_Point = x_point;
            Y_Point = y_point;
        }
        
        public bool IsPoint(int y_point, int x_point)
        {
            if (y_point == Y_Point || x_point == X_Point) return true;
            return false;
        }
    }
}