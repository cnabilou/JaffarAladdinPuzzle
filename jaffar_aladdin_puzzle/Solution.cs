using System;
using System.Collections.Generic;

namespace Jafar_Aladdin
{
    public static class Solution
    {
        #region Private Members

        private const char Jaffar = 'X';
        private const char Aladdin = 'O';
        private const char Empty = '.';

        private static int _leftMoveCount = 0;
        private static int _rightMoveCount = 0;

        private static int _zzCounter = 0;

        private static int[] _aladdinInitialPosition = new int[] { };

        private static int _arrayDimension = 0;

        private static int _lx = 0;
        private static int _ly = 0;
        private static int[] _newPosition = new int[] { };

        private static List<int> _pathMaxJump = new List<int> { };

        #endregion Private Members

        public static int GetMaxJump(string[] array)
        {
            // Get array dimension
            _arrayDimension = array.Length - 1;

            Console.WriteLine($"Array height: {_arrayDimension}");
            Console.WriteLine($"Array width: {array[0].Length - 1}");

            // Get Aladdin position
            _aladdinInitialPosition = AladdinPostion(array);

            var lc = LeftPathJumpCount(_aladdinInitialPosition, array);
            var rc = RightPathJumpCount(_aladdinInitialPosition, array);
            var zz = ZigZagPathJumpCount(_aladdinInitialPosition, array);
            var max1 = Math.Max(lc, rc);
            return Math.Max(max1, zz);
        }

        /// <summary>
        /// Returns Aladdin position
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static int[] AladdinPostion(string[] array)
        {
            var arrayRow = 0;
            foreach (var s in array)
            {
                var index = s.IndexOf(Aladdin);
                if (index != -1)
                {
                    return new[] { index, arrayRow };
                }
                arrayRow++;
            }
            return null;
        }

        public static bool CanMoveToPosition(int[] position, string[] array, SearchType searchType)
        {
            var x = position[0];
            var y = position[1];

            string row;
            char emptyItem;
            char jaffarItem;

            switch (searchType)
            {
                case SearchType.CanMoveLeft:
                    // Need to check that we are not going to go out of the bound of the array
                    if ((y - 1 < 0) || (x - 1 < 0)
                        || (y - 2 < 0) || (x - 2 < 0))
                    {
                        return false;
                    }

                    // Jaffar
                    row = array[y - 1];
                    jaffarItem = row[x - 1];

                    // empty
                    row = array[y - 2];
                    emptyItem = row[x - 2];

                    return ((jaffarItem == Jaffar)
                            && (emptyItem == Empty));

                case SearchType.CanMoveRight:
                    // Need to check that we are not going to go out of the bound of the array
                    if ((x + 2 > _arrayDimension)
                        || (y - 2 < 0)
                        || (x + 2 > _arrayDimension))
                    {
                        return false;
                    }

                    // Jaffar
                    row = array[y - 1];
                    jaffarItem = row[x + 1];
                    // Empty
                    row = array[y - 2];
                    emptyItem = row[x + 2];

                    return ((jaffarItem == Jaffar)
                            && (emptyItem == Empty));
                default:
                    return false;
            }
        }

        public static int LeftPathJumpCount(int[] aladdinPosition, string[] array)
        {
            Console.WriteLine($"Starting Aladdin position Path1: {aladdinPosition[0]}, {aladdinPosition[1]}");

            if (CanMoveToPosition(aladdinPosition, array, SearchType.CanMoveLeft))
            {
                _leftMoveCount++;

                var lx = 0;
                var ly = 0;

                // get new aladdin position
                lx = aladdinPosition[0] - 2;
                ly = aladdinPosition[1] - 2;

                if ((lx > 0)
                    && (ly > 0))
                {
                    var newPosition = new int[] { lx, ly };
                    LeftPathJumpCount(newPosition, array);
                }
            }
            else if (CanMoveToPosition(aladdinPosition, array, SearchType.CanMoveRight))
            {
                _leftMoveCount++;

                var lx = 0;
                var ly = 0;

                // get new aladdin position
                lx = aladdinPosition[0] + 2;
                ly = aladdinPosition[1] - 2;

                if ((ly > 0)
                    && (lx < _arrayDimension))
                {
                    var newPosition = new int[] { lx, ly };
                    LeftPathJumpCount(newPosition, array);
                }
            }

            return _leftMoveCount;
        }

        public static int RightPathJumpCount(int[] aladdinPosition, string[] array)
        {
            Console.WriteLine();
            Console.WriteLine($"Starting Aladdin position Path2: {aladdinPosition[0]}, {aladdinPosition[1]}");

            if (CanMoveToPosition(aladdinPosition, array, SearchType.CanMoveRight))
            {
                var lx = 0;
                var ly = 0;

                _rightMoveCount++;

                // get new aladdin position
                lx = aladdinPosition[0] + 2;
                ly = aladdinPosition[1] + 2;


                if ((lx < _arrayDimension)
                    && (ly < _arrayDimension))
                {
                    var newPosition = new int[] { lx, ly };
                    RightPathJumpCount(newPosition, array);
                }
            }
            else if (CanMoveToPosition(aladdinPosition, array, SearchType.CanMoveLeft))
            {
                _rightMoveCount++;

                // get new aladdin position
                var lx = 0;
                var ly = 0;
                lx = aladdinPosition[0] + 2;
                ly = aladdinPosition[1] - 2;

                if ((lx < _arrayDimension)
                    && (ly > 0))
                {

                    var newPosition = new int[] { lx, ly };
                    RightPathJumpCount(newPosition, array);
                }
            }
            return _rightMoveCount;
        }

        public static int ZigZagPathJumpCount(int[] aladdinPosition, string[] array)
        {
            Console.WriteLine();
            Console.WriteLine($"Starting Aladdin position Path3: {aladdinPosition[0]}, {aladdinPosition[1]}");

            if (CanMoveToPosition(aladdinPosition, array, SearchType.CanMoveLeft))
            {
                _zzCounter++;

                // get new aladdin position
                var lx = 0;
                var ly = 0;
                lx = aladdinPosition[0] + 2;
                ly = aladdinPosition[1] + 2;

                if ((lx < _arrayDimension)
                    && (ly < _arrayDimension))
                {
                    var newPosition = new int[] { lx, ly };
                    LeftPathJumpCount(newPosition, array);
                }
            }
            if (CanMoveToPosition(aladdinPosition, array, SearchType.CanMoveRight))
            {
                _zzCounter++;
                // get new aladdin position
                var lx = 0;
                var ly = 0;
                lx = aladdinPosition[0] + 2;
                ly = aladdinPosition[1] - 2;

                if ((lx < _arrayDimension)
                    && (ly > 0))
                {

                    var newPosition = new int[] { lx, ly };
                    RightPathJumpCount(newPosition, array);
                }
            }
            Console.WriteLine($"");
            return _zzCounter;
        }
    }
}
