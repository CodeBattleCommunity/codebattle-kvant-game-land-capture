using System.Collections.Generic;
using CodeBattle.PointWar.Server.Models;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.AspNetCore.SignalR;

namespace CodeBattle.PointWar.Server
{
    public class Logic : Hub
    {
        Map _map = new Map();

        // Map size
        public static int Height = _map.Height;
        public static int Width = _map.Width;

        public readonly CellState[,] cells = new CellState[Height, Width]; // Matrix

        // Get Cell Status
        public CellState this[Point p]
        {
            get
            {
                if (p.X_Point < 0 || p.X_Point >= Width || p.Y_Point < 0 || p.Y_Point >= Height)
                    return CellState.OutOfField;
                return cells[p.X_Point, p.Y_Point];
            }
        }

        /// <summary>
        /// Find neighbors
        /// </summary>
        public IEnumerable<Point> GetNeighbors(Point p)
        {
            yield return new Point(p.Y_Point - 1, p.X_Point, p.PlayerID);
            yield return new Point(p.Y_Point, p.X_Point - 1, p.PlayerID);
            yield return new Point(p.Y_Point + 1, p.X_Point, p.PlayerID);
            yield return new Point(p.Y_Point, p.X_Point + 1, p.PlayerID);
        }

        /// <summary>
        /// Find closed areas
        /// </summary>
        private IEnumerable<HashSet<Point>> GetClosedArea(Point lastPoint)
        {
            var myState = this[lastPoint];
            // Enum empty points & go to edge
            foreach (var n in GetNeighbors(lastPoint))
            {
                if (this[n] != myState)
                {
                    // Find closed area
                    var list = GetClosedArea(n, myState);
                    if (list != null)
                        yield return list; // Return busy points
                }
            }
        }

        /// <summary>
        /// Fill the area, return set busy points
        /// </summary>
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
                // If go out to edge - return null
                if (state == CellState.OutOfField)
                    return null;
                // Enum neighbors
                foreach (var n in GetNeighbors(p))
                {
                    if (this[n] != myState)
                    {
                        if (!visited.Contains(n))
                        {
                            visited.Add(n);
                            stack.Push(n);
                        }
                    }
                }
            }

            return visited;
        }

        public async Task GetCloseArea()
        {
            string File = "points.json";

            if (!File.Exist(File))
                File.Create(File);

            Point _p = JsonConvert.DeserializeObject<Point>(File);

            await Clients.All.SendAsync("GetCloseArea", GetCloseArea(_p));
        }
    }

    // Cell Status
    public enum CellState
    {
        Empty, OutOfField
    }
}