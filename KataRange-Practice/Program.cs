using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataRange_Practice
{
    class Program
    {
        static void Main()
        {
            Range range;
            Console.WriteLine("-----------------------");
            Console.WriteLine("- Kata Range Exercise -");
            Console.WriteLine("-----------------------");
            Console.WriteLine();


            #region Integer Range Contains and DoesNotContain
            Console.WriteLine("[-] - Integer Range Contains");
            Console.WriteLine();
            Console.WriteLine("[-] - [2,6) contains {2,4}");                 //1
            range = new Range("[2,6)");
            Console.WriteLine("[2,6) contains 2 = " + range.Contains(2));
            Console.WriteLine("[2,6) contains 4 = " + range.Contains(4));
            Console.WriteLine();
            Console.WriteLine("[-] - [2,6) doesn't contain {-1,1,6,10}");    //2
            Console.WriteLine("[2,6) doesn't contain -1 = " + range.DoesNotContain(-1));
            Console.WriteLine("[2,6) doesn't contain 1 = " + range.DoesNotContain(1));
            Console.WriteLine("[2,6) doesn't contain 6 = " + range.DoesNotContain(6));
            Console.WriteLine("[2,6) doesn't contain 10 = " + range.DoesNotContain(10));
            Console.WriteLine();
            #endregion

            #region GetAllPoints
            Console.WriteLine("[-] - getAllPoints");
            Console.WriteLine();
            Console.WriteLine("[-] - [2,6) allPoints = {2,3,4,5}");
            Console.Write("[2,6) allPoints = { ");
            foreach (var point in range.GetAllPoints())
            {
                Console.Write(point + " ");
            }
            Console.WriteLine("}");
            Console.WriteLine();
            #endregion

            #region ContainsRange and DoesNotContainRange
            Console.WriteLine("[-] - ContainsRange");
            Console.WriteLine();
            Console.WriteLine("[-] - [2,5) doesn't contain [7,10)"); //1
            range = new Range("[2,5)");
            Console.WriteLine("[2,5) doesn't contain the range [7,10) = " + range.DoesNotContainRange(new Range("[7,10)")));
            Console.WriteLine("[-] - [2,5) doesn't contain [3,10)"); //2
            Console.WriteLine("[2,5) doesn't contain the range [3,10) = " + range.DoesNotContainRange(new Range("[3,10)")));
            Console.WriteLine("[-] - [3,5) doesn't contain [2,10)"); //3
            range = new Range("[3,5)");
            Console.WriteLine("[3,5) doesn't contain the range [2,10) = " + range.DoesNotContainRange(new Range("[2,10)")));
            Console.WriteLine("[-] - [2,10) contains [3,5]");        //4
            range = new Range("[2,10)");
            Console.WriteLine("[2,10) contains range [3,5] = " + range.ContainsRange(new Range("[3,5]")));
            Console.WriteLine("[-] - [3,5) contains [3,5)");         //5
            range = new Range("[3,5]");
            Console.WriteLine("[3,5] contains the range [3,5) = " + range.ContainsRange(new Range("[3,5)")));
            Console.WriteLine();
            #endregion

            #region endPoints
            Console.WriteLine("[-] - endPoints");
            Console.WriteLine();
            Console.WriteLine("[-] - [2,6) endPoints are {2,5}"); //1
            range = new Range("[2,6)");
            Console.WriteLine("[2,6) end points = {0} and {1}", range.EndPoints()[0], range.EndPoints()[1]);
            Console.WriteLine("[-] - [2,6] endPoints are {2,6}"); //2
            range = new Range("[2,6]");
            Console.WriteLine("[2,6] end points = {0} and {1}", range.EndPoints()[0], range.EndPoints()[1]);
            Console.WriteLine("[-] - (2,6) endPoints are {3,5}"); //3
            range = new Range("(2,6)");
            Console.WriteLine("(2,6) end points = {0} and {1}", range.EndPoints()[0], range.EndPoints()[1]);
            Console.WriteLine("[-] - (2,6] endPoints are {3,6}"); //4
            range = new Range("(2,6]");
            Console.WriteLine("(2,6] end points = {0} and {1}", range.EndPoints()[0], range.EndPoints()[1]);
            Console.WriteLine();
            #endregion

            #region OverlapsRange and DoesNotOverlapRange
            Console.WriteLine("[-] - overlapsRange");
            Console.WriteLine();
            Console.WriteLine("[-] - [2,5) doesn't overlap with [7,10)"); //1
            range = new Range("[2,5)");
            Console.WriteLine("[2,5) doesn't overlap the range [7,10) = " + range.DoesNotOverlapRange(new Range("[7,10)")));
            Console.WriteLine("[-] - [2,10) overlaps with [3,5)"); //2
            range = new Range("[2,10)");
            Console.WriteLine("[2,10) overlaps the range [3,5) = " + range.OverlapsRange(new Range("[3,5)")));
            Console.WriteLine("[-] - [3,5) overlaps with [3,5)"); //3
            range = new Range("[3,5)");
            Console.WriteLine("[3,5) overlaps the range [3,5) = " + range.OverlapsRange(new Range("[3,5)")));
            Console.WriteLine("[-] - [2,5) overlaps with [3,10)");        //4
            range = new Range("[2,5)");
            Console.WriteLine("[2,5) overlaps the range [3,10) = " + range.OverlapsRange(new Range("[3,10)")));
            Console.WriteLine("[-] - [3,5) overlaps [2,10)");         //5
            range = new Range("[3,5]");
            Console.WriteLine("[3,5] overlaps the range [2,10) = " + range.OverlapsRange(new Range("[2,10)")));
            Console.WriteLine();
            #endregion

            #region Equals and NotEquals
            Console.WriteLine("[-] - Equals");
            Console.WriteLine();
            Console.WriteLine("[-] - [3,5) equals [3,5)"); //1
            range = new Range("[3,5)");
            Console.WriteLine("[3,5) equals the range [3,5) = " + range.Equals(new Range("[3,5)")));
            Console.WriteLine("[-] - [2,10) not equal to [3,5)"); //2
            range = new Range("[2,10)");
            Console.WriteLine("[2,10) doesn't equal the range [3,5) = " + range.NotEquals(new Range("[3,5)")));
            Console.WriteLine("[-] - [2,5) not equal to [3,10)"); //3
            range = new Range("[2,5)");
            Console.WriteLine("[2,5) doesn't equal the range [3,10) = " + range.NotEquals(new Range("[3,10)")));
            Console.WriteLine("[-] - [3,5) not equal to [2,10)");        //4
            range = new Range("[3,5)");
            Console.WriteLine("[3,5) doesn't equal the range [2,10) = " + range.NotEquals(new Range("[2,10)")));
            Console.WriteLine();
            #endregion

            Console.ReadLine();
        }
    }
}
