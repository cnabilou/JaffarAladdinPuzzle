using System;

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

        private static int[] _aladdinInitialPosition = new int[] { };

        private static int _arrayDimension = 0;

        private static int _lx = 0;
        private static int _ly = 0;
        private static int[] _newPosition = new int[] { };

        #endregion Private Members

        public static int GetMaxJump(string[] array)
        {
            // Get array dimension
            _arrayDimension = array.Length - 1;
            // Get Aladdin position
            _aladdinInitialPosition = AladdinPostion(array);

            // Calculate max jumps
            var maxJump = Jump(_aladdinInitialPosition, array);

            return maxJump;
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

        /// <summary>
        /// Calculate the maximum number of jumps on the list of string
        /// </summary>
        /// <param name="aladdinPosition"></param>
        /// <param name="array"></param>
        /// <returns></returns>
        public static int Jump(int[] aladdinPosition, string[] array)
        {
            if (CanMoveToPosition(aladdinPosition, array, SearchType.CanMoveLeft))
            {
                _leftMoveCount++;

                // get new aladdin position
                _lx = aladdinPosition[0] - 2;
                _ly = aladdinPosition[1] - 2;

                if ((_lx >= 0 || _lx <= _arrayDimension)
                    || (_ly >= 0 || _ly <= _arrayDimension))
                {
                    _newPosition = new int[] { _lx, _ly };
                    Jump(_newPosition, array);
                }
            }
            if (CanMoveToPosition(aladdinPosition, array, SearchType.CanMoveRight))
            {
                _rightMoveCount++;

                // get new aladdin position
                _lx = aladdinPosition[0] + 2;
                _ly = aladdinPosition[1] - 2;

                if ((_lx >= 0 || _lx <= _arrayDimension)
                    || (_ly >= 0 || _ly <= _arrayDimension))
                {
                    _newPosition = new int[] { _lx, _ly };
                    Jump(_newPosition, array);
                }
            }

            return Math.Max(_leftMoveCount, _rightMoveCount);
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
                    if ((y - 1 < 0) || (x + 1 > _arrayDimension)
                        || (y - 2 < 0) || (x + 2 > _arrayDimension))
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
    }
}
