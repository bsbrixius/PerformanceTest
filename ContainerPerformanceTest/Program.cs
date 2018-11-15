using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceTest
{
    using System.Collections;
    using System.Diagnostics;

    class Program
    {
        static private int elementsCount = 1000000;

        static Stopwatch stopWatchAddArray = new Stopwatch();

        static Stopwatch stopWatchAddGenericList = new Stopwatch();

        static Stopwatch stopWatchAddDictionary = new Stopwatch();

        static Stopwatch stopWatchFindArray = new Stopwatch();
        static Stopwatch stopWatchFindGenericList = new Stopwatch();
        static Stopwatch stopWatchFindDictionary = new Stopwatch();

        private static int[] findResults;

        static void TestAddArray()
        {
            stopWatchAddArray.Start();
            int[] arrayInt = new int[elementsCount];
            
            for (int i = 0; i < elementsCount; i++)
            {
                arrayInt[i] = i;
            }
            stopWatchAddArray.Stop();
        }

        static void TestAddGenericList()
        {
            stopWatchAddGenericList.Start();
            List<int> genericList = new List<int>(elementsCount);

            for (int i = 0; i < elementsCount; i++)
            {
                genericList.Add(i);
            }
            stopWatchAddGenericList.Stop();

        }

        static void TestAddDictionary()
        {
            stopWatchAddDictionary.Start();
            Dictionary<int,int> dictionary = new Dictionary<int, int>(elementsCount);

            for (int i = 0; i < elementsCount; i++)
            {
                dictionary.Add(i,i);
            }
            stopWatchAddDictionary.Stop();
        }

        static void TestFindArray()
        {
            int[] arrayInt = new int[elementsCount];
            int foundValue;
            for (int i = 0; i < elementsCount; i++)
            {
                arrayInt[i] = i;
            }

            stopWatchFindArray.Start();
            for (int i = 0; i < findResults.Length; i++)
            {
                for (var j = 0; j < arrayInt.Length; j++)
                {
                    if (arrayInt[j] == findResults[i])
                    {
                        foundValue = arrayInt[j];
                        break;
                    }
                }
            }
            stopWatchFindArray.Stop();
        }

        static void TestFindGenericList()
        {
            List<int> genericList = new List<int>(elementsCount);
            int foundValue;

            for (int i = 0; i < elementsCount; i++)
            {
                genericList.Add(i);
            }
            stopWatchFindGenericList.Start();
            for (int i = 0; i < findResults.Length; i++)
            {
                foundValue = genericList.Find(x => x == findResults[i]);
            }
            stopWatchFindGenericList.Stop();
        }

        static void TestFindDictionary()
        {
            Dictionary<int, int> dictionary = new Dictionary<int, int>(elementsCount);
            int foundValue;

            for (int i = 0; i < elementsCount; i++)
            {
                dictionary.Add(i, i);
            }

            stopWatchFindDictionary.Start();
            for (int i = 0; i < findResults.Length; i++)
            {
                foundValue = dictionary[findResults[i]];
            }
            stopWatchFindDictionary.Stop();
        }

        static void Main(string[] args)
        {
            findResults = new int[10000];
            Random randomNumber = new Random();
            for (int i = 0; i < findResults.Length; i++)
            {
                findResults[i] = randomNumber.Next(elementsCount);
            }

            TestAddArray();
            TestAddGenericList();
            TestAddDictionary();

            stopWatchAddArray.Reset();
            stopWatchAddGenericList.Reset();
            stopWatchAddDictionary.Reset();

            TestAddArray();
            TestAddGenericList();
            TestAddDictionary();


            Console.WriteLine($"Array Add time = {stopWatchAddArray.Elapsed.Milliseconds}");
            Console.WriteLine($"GenericList Add time = {stopWatchAddGenericList.Elapsed.Milliseconds}");
            Console.WriteLine($"Dictionary Add time = {stopWatchAddDictionary.Elapsed.Milliseconds}");

            TestFindArray();
            TestFindGenericList();
            TestFindDictionary();

            stopWatchFindArray.Reset();
            stopWatchFindGenericList.Reset();
            stopWatchFindDictionary.Reset();
            

            TestFindArray();
            TestFindGenericList();
            TestFindDictionary();

            Console.WriteLine($"Array Find time = {stopWatchFindArray.Elapsed.Milliseconds}");
            Console.WriteLine($"GenericList Find time = {stopWatchFindGenericList.Elapsed.Milliseconds}");
            Console.WriteLine($"Dictionary Find time = {stopWatchFindDictionary.Elapsed.Milliseconds}");

            Console.ReadLine();
        }
    }
}
