using NUnit.Framework.Constraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataRange_Practice
{
    class Range
    {
        public int LeftBound;
        public bool LeftBoundOpen;
        public int RightBound;
        public bool RightBoundOpen;

        public Range(string range) //(open) does not include [closed] include
        {
            try
            {
                range = range.Replace(" ", "");
                if (range[0] == '[')
                {
                    LeftBoundOpen = false;
                }
                if (range[0] == '(')
                {
                    LeftBoundOpen = true;
                }
                if (range[range.Length - 1] == ']')
                {
                    RightBoundOpen = false;
                }
                if (range[range.Length - 1] == ')')
                {
                    RightBoundOpen = true;
                }
                range = range.Replace("[", "");
                range = range.Replace("(", "");
                range = range.Replace("]", "");
                range = range.Replace(")", "");

                string[] values = range.Split(',');
                LeftBound = Convert.ToInt32(values[0]);
                RightBound = Convert.ToInt32(values[1]);

                if (RightBound == LeftBound && (LeftBoundOpen || RightBoundOpen))
                {
                    throw new ArgumentException("Range is one value and the Range is open(non-inclusive), the Range is null");
                }
            }
            catch (Exception)
            {
                throw new ArgumentException();
            }
            
        }
        public bool Contains(int point)
        {
            if (LeftBoundOpen && RightBoundOpen)
            {
                if ((point - LeftBound) * (RightBound - point) > 0)
                {
                    return true;
                }
                else return false;
            }
            else if (!LeftBoundOpen && RightBoundOpen)
            {
                if (LeftBound <= point && point < RightBound)
                {
                    return true;
                }
                else return false;
            }
            else if (LeftBoundOpen && !RightBoundOpen)
            {
                if (LeftBound < point && point <= RightBound)
                {
                    return true;
                }
                else return false;

            }
            else if (!LeftBoundOpen && !RightBoundOpen)
            {
                if ((point - LeftBound) * (RightBound - point) >= 0)
                {
                    return true;
                }
                else return false;

            }
            else throw new Exception("Problem in Contains Algorithm");
        }
        public bool DoesNotContain(int point)
        {
            if (LeftBoundOpen && RightBoundOpen)
            {
                if ((point - LeftBound) * (RightBound - point) > 0)
                {
                    return false;
                }
                else return true;
            }
            else if (!LeftBoundOpen && RightBoundOpen)
            {
                if (LeftBound <= point && point < RightBound)
                {
                    return false;
                }
                else return true;
            }
            else if (LeftBoundOpen && !RightBoundOpen)
            {
                if (LeftBound < point && point <= RightBound)
                {
                    return false;
                }
                else return true;

            }
            else if (!LeftBoundOpen && !RightBoundOpen)
            {
                if ((point - LeftBound) * (RightBound - point) >= 0)
                {
                    return false;
                }
                else return true;

            }
            else throw new Exception("Problem in DoesNotContain Algorithm");

        }
        public int[] GetAllPoints()
        {

            if (LeftBoundOpen && RightBoundOpen)
            {
                return Enumerable.Range(LeftBound + 1, RightBound - LeftBound - 1).ToArray();
            }
            else if (!LeftBoundOpen && RightBoundOpen)
            {
                return Enumerable.Range(LeftBound, RightBound - LeftBound).ToArray();
            }
            else if (LeftBoundOpen && !RightBoundOpen)
            {
                return Enumerable.Range(LeftBound + 1, RightBound - LeftBound).ToArray();
            }
            else if (!LeftBoundOpen && !RightBoundOpen && LeftBound == RightBound)
            {
                return Enumerable.Range(LeftBound, RightBound - LeftBound + 1).ToArray();
            }
            else if (!LeftBoundOpen && !RightBoundOpen)
            {
                return Enumerable.Range(LeftBound, RightBound - LeftBound + 1).ToArray();
            }

            else throw new Exception("Problem in AllPoints Algorithm");

        }
        public bool ContainsRange(Range receivedRange)
        {
            bool WithinLeft = false, WithinRight = false;
            if (receivedRange.LeftBound < this.LeftBound || receivedRange.RightBound > this.RightBound)
            {
                return false;
            }

            if (LeftBoundOpen)
            {
                if (!receivedRange.LeftBoundOpen && receivedRange.LeftBound == this.LeftBound)
                {
                    return false;
                }
            }

            if (receivedRange.LeftBound >= this.LeftBound)
            {
                WithinLeft = true;
            }


            if (RightBoundOpen)
            {
                if (!receivedRange.RightBoundOpen && receivedRange.RightBound == this.RightBound)
                {
                    return false;
                }
            }

            if (receivedRange.RightBound <= this.RightBound)
            {
                WithinRight = true;
            }

            if (WithinLeft && WithinRight)
            {
                return true;
            }
            else throw new Exception("Problem in DoesContainRange Algorithm");

        }
        public bool DoesNotContainRange(Range receivedRange)
        {
            bool WithinLeft = false, WithinRight = false;
            if (receivedRange.LeftBound < this.LeftBound || receivedRange.RightBound > this.RightBound)
            {
                return true;
            }

            if (LeftBoundOpen)
            {
                if (!receivedRange.LeftBoundOpen && receivedRange.LeftBound == this.LeftBound)
                {
                    return true;
                }
            }

            if (receivedRange.LeftBound >= this.LeftBound)
            {
                WithinLeft = true;
            }


            if (RightBoundOpen)
            {
                if (!receivedRange.RightBoundOpen && receivedRange.RightBound == this.RightBound)
                {
                    return true;
                }
            }

            if (receivedRange.RightBound <= this.RightBound)
            {
                WithinRight = true;
            }

            if (WithinLeft && WithinRight)
            {
                return false;
            }
            else throw new Exception("Problem in DoesNotContainRange Algorithm");

        }
        public int[] EndPoints()
        {
            if (LeftBoundOpen && RightBoundOpen)
            {
                return new int[] { LeftBound + 1, RightBound - 1 };
            }
            else if (!LeftBoundOpen && RightBoundOpen)
            {
                return new int[] { LeftBound, RightBound - 1 };
            }
            else if (LeftBoundOpen && !RightBoundOpen)
            {
                return new int[] { LeftBound + 1, RightBound };

            }
            else if (!LeftBoundOpen && !RightBoundOpen)
            {

                return new int[] { LeftBound, RightBound };

            }
            else throw new Exception("Problem in EndPoints Algorithm");

        }
        public bool OverlapsRange(Range receivedRange)
        {
            if (GetAllPoints().Any(item => receivedRange.GetAllPoints().Any(match => match == item)))
            {
                return true;
            }
            return false;
        }
        public bool DoesNotOverlapRange(Range receivedRange)
        {
            if (GetAllPoints().Any(item => receivedRange.GetAllPoints().Any(match => match == item)))
            {
                return false;
            }
            return true;
        }
        public bool Equals(Range receivedRange)
        {
            return Enumerable.SequenceEqual(GetAllPoints(), receivedRange.GetAllPoints());
        }
        public bool NotEquals(Range receivedRange)
        {
            return !Enumerable.SequenceEqual(GetAllPoints(), receivedRange.GetAllPoints());
        }

    }
}