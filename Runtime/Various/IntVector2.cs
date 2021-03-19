using System;
using System.Collections.Generic;
using UnityEngine;

namespace MWG
{
    public struct IntVector2
    {
        public int x, y;

        public IntVector2(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public IntVector2(float x, float y) : this((int) x, (int) y)
        {
        }

        public IntVector2(Vector2 pos) : this((int) pos.x, (int) pos.y)
        {
        }

        public static IntVector2 operator +(IntVector2 a, IntVector2 b)
        {
            return new IntVector2(a.x + b.x, a.y + b.y);
        }

        public static IntVector2 operator +(IntVector2 a, Vector2 b)
        {
            return new IntVector2(a.x + (int) b.x, a.y + (int) b.y);
        }

        public static IntVector2 operator -(IntVector2 a, IntVector2 b)
        {
            return new IntVector2(a.x - b.x, a.y - b.y);
        }

        public static IntVector2 operator -(IntVector2 a, Vector2 b)
        {
            return new IntVector2(a.x - (int) b.x, a.y - (int) b.y);
        }

        public static IntVector2 operator *(IntVector2 a, int b)
        {
            return new IntVector2(a.x * b, a.y * b);
        }

        public override string ToString()
        {
            return $"[{x} , {y}]";
        }

        public override bool Equals(object obj)
        {
            //
            // See the full list of guidelines at
            //   http://go.microsoft.com/fwlink/?LinkID=85237
            // and also the guidance for operator== at
            //   http://go.microsoft.com/fwlink/?LinkId=85238
            //

            if (obj == null
                || GetType() != obj.GetType())
                return false;

            var v = (IntVector2) obj;
            return x == v.x && y == v.y;
        }

        public override int GetHashCode()
        {
            return x ^ y;
        }

        public static bool operator ==(IntVector2 lhs, IntVector2 rhs)
        {
            return lhs.x == rhs.x && lhs.y == rhs.y;
        }

        public static bool operator !=(IntVector2 lhs, IntVector2 rhs)
        {
            return !(lhs == rhs);
        }
    }

    public static class IntVector2Extensions
    {
        /// <summary>
        ///     Returns the eight locations immediately adjacent (orthogonally and diagonally) to <paramref name="fromLocation" />
        /// </summary>
        /// <param name="fromLocation">The location from which to return all adjacent points</param>
        /// <returns>The locations as an IEnumerable of Points</returns>
        public static IntVector2[] GetAdjacentLocations(this IntVector2 fromLocation)
        {
            return new[]
            {
                new IntVector2(fromLocation.x - 1, fromLocation.y - 1),
                new IntVector2(fromLocation.x - 1, fromLocation.y + 1),
                new IntVector2(fromLocation.x + 1, fromLocation.y + 1),
                new IntVector2(fromLocation.x + 1, fromLocation.y - 1),
                new IntVector2(fromLocation.x, fromLocation.y + 1),
                new IntVector2(fromLocation.x, fromLocation.y - 1),
                new IntVector2(fromLocation.x + 1, fromLocation.y),
                new IntVector2(fromLocation.x - 1, fromLocation.y)
            };
        }

        public static IEnumerable<IntVector2> GetAdjacentCardinalLocations(this IntVector2 fromLocation)
        {
            return new[]
            {
                new IntVector2(fromLocation.x - 1, fromLocation.y),
                new IntVector2(fromLocation.x, fromLocation.y + 1),
                new IntVector2(fromLocation.x + 1, fromLocation.y),
                new IntVector2(fromLocation.x, fromLocation.y - 1)
            };
        }

        public static IEnumerable<IntVector2> GetAdjacentDiagonalLocations(this IntVector2 fromLocation)
        {
            return new[]
            {
                new IntVector2(fromLocation.x - 1, fromLocation.y - 1),
                new IntVector2(fromLocation.x - 1, fromLocation.y + 1),
                new IntVector2(fromLocation.x + 1, fromLocation.y + 1),
                new IntVector2(fromLocation.x + 1, fromLocation.y - 1)
            };
        }

        public static bool IsAdjacentTo(this IntVector2 pos, IntVector2 other)
        {
            var x = Math.Abs(pos.x - other.x);
            var y = Math.Abs(pos.y - other.y);


            return (x != 0 || y != 0)
                   && x <= 1
                   && y <= 1;
        }

        public static IntVector2 TryGetCloserByOneTile(this IntVector2 pos, IntVector2 target, out bool didGetCloser)
        {
            var xDiff = Math.Abs(pos.x - target.x);
            var yDiff = Math.Abs(pos.y - target.y);

            if (xDiff <= 1
                && yDiff <= 1)
            {
                didGetCloser = false;
                return target;
            }

            //Prefer moving on the X-axis
            if (xDiff > yDiff
                || xDiff == yDiff)
            {
                if (pos.x - target.x > 0)
                {
                    didGetCloser = true;
                    return new IntVector2(target.x + 1, target.y);
                }

                if (pos.x - target.x < 0)
                {
                    didGetCloser = true;
                    return new IntVector2(target.x - 1, target.y);
                }
            }
            else if (yDiff < xDiff)
            {
                if (pos.y - target.y > 0)
                {
                    didGetCloser = true;
                    return new IntVector2(target.x, target.y + 1);
                }

                if (pos.y - target.y < 0)
                {
                    didGetCloser = true;
                    return new IntVector2(target.x, target.y + 1);
                }
            }

            didGetCloser = false;
            return target;
        }
    }
}