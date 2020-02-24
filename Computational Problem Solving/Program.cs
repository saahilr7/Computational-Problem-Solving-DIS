using System;
using System.Collections;
using System.Collections.Generic;
//using Lucene.Net.Util;
using System.Text;
using System.Linq;

namespace Computational_Problem_Solving
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Question 1");
            int[] l1 = new int[] { 5, 6, 6, 9, 9, 12 };
            int target = 9;
            int[] r = TargetRange(l1, target);

            Console.WriteLine("[" + r[0] + "," + r[1] + "]");
            // Write your code to print range r here
            //foreach (int n in r)
            //{
            //    Console.Write("[{0}]", string.Join(", ", r));
            //    //Console.Write(n);
            //}
            //DisplayArray(r);
            Console.WriteLine();
            Console.WriteLine("Question 2");
            string s1 = "University of South Florida";
            string rs = StringReverse(s1);
            Console.WriteLine(rs);



            Console.WriteLine("Question 3");
            int[] l2 = new int[] { 40, 40 };
            int sum = MinimumSum(l2);
            Console.WriteLine(sum);

            Console.WriteLine();

            Console.WriteLine("Question 4");
            string s2 = "Dell";
            string sortedString = FreqSort(s2);
            Console.WriteLine(sortedString);

            Console.WriteLine();

            Console.WriteLine("Question 5-Part 1");
            int[] nums1 = { 3, 6, 2 };
            int[] nums2 = { 6, 3, 6, 7, 3 };
            int[] intersect1 = Intersect1(nums1, nums2);
            Console.WriteLine("Part 1- Intersection of two arrays is: ");
            DisplayArray(intersect1);
            Console.WriteLine("\n");

            Console.WriteLine("Question 5-Part 2");
            int[] intersect2 = Intersect2(nums1, nums2);
            Console.WriteLine("Part 2- Intersection of two arrays is: ");
            DisplayArray(intersect2);
            Console.WriteLine("\n");

            Console.WriteLine("Question 6");
            char[] arr = new char[] { 'a', 'g', 'c', 'a' };
            int k = 3;
            Console.WriteLine(ContainsDuplicate(arr, k));

            Console.WriteLine();

            Console.WriteLine("Question 7");
            int rodLength = 15;
            int priceProduct = GoldRod(rodLength);
            Console.WriteLine(priceProduct);

            Console.WriteLine();

            Console.WriteLine("Question 8");
            string[] userDict = new string[] { "rocky", "usf", "hello", "apple" };
            string keyword = "hhllo";
            Console.WriteLine(DictSearch(userDict, keyword));

            Console.WriteLine();

            Console.WriteLine("Question 9");
            SolvePuzzle();

            

        }



        public static void DisplayArray(int[] a)
        {
            foreach (int n in a)
            {
                Console.Write(n + " ");
            }
        }

        public static int[] TargetRange(int[] l1, int t)
        {
            int[] res = { -1, 1 };
            if (l1 == null | l1.Length == 0)
                return res;
            try
            {
                res[0] = firstPos(l1, t);
                res[1] = lastPos(l1, t);
            }
            catch (Exception)
            {
                Console.WriteLine("Exception Occured"); ;
            }
            return res;
        }



        public static int firstPos(int[] l1, int t)     //function to narrow down the search to left half of the array
        {
            int start = 0;
            int last = l1.Length - 1;

            int index = -1;

            while (start <= last)
            {
                int mid = start + (last - start) / 2;
                if (l1[mid] == t)
                {
                    index = mid;                     //if middle element of l1 is equal to target, store index of middle element in index and search only the left part of the array from this point. (Narrowing down the search to left half of the array)
                    last = mid - 1;
                }
                else if (l1[mid] > t)               //if middle element is greater than target, keep checking the left part of the array l1
                    last = mid - 1;
                else
                    start = mid + 1;                //if middle element is greater than target, keep checking the left part of the array l1
            }
            return index;
        }

        public static int lastPos(int[] l1, int t)      //narrowing down the search to right half of the array
        {
            int start = 0;
            int last = l1.Length - 1;

            int index = -1;

            while (start <= last)
            {
                int mid = start + (last - start) / 2;           //if middle element of l1 is equal to target, store index of middle element in index
                if (l1[mid] == t)                               //narrow down the search to right half of the array
                {
                    index = mid;
                    start = mid + 1;
                }
                else if (l1[mid] > t)   
                    last = mid - 1;
                else
                    start = mid + 1;
            }
            return index;
        }
        public static string StringReverse(string s1)
        {
            try
            {
                // Here I have created an array list with the split up of words from our main string.
                //As we are not allowed to use the predifined split function, i have used a for loop to split and add words
                //to the list.
                ArrayList arrayList = new ArrayList();
                string Temp = "";
                for (int i = 0; i < s1.Length; i++)
                {

                    if (s1[i] != ' ')
                    {
                        Temp = Temp + s1[i];
                        if (i == (s1.Length - 1))
                            arrayList.Add(Temp);
                        continue;

                    }
                    arrayList.Add(Temp);
                    Temp = "";
                }
                string reverse = ""; // Here i have taken an empty string to store the characters.
                foreach (string s in arrayList)
                {
                    char[] x = s.ToCharArray(); // I have taken each word and converted it into characters.
                    for (int i = x.Length - 1; i > -1; i--)
                    {
                        reverse += s[i]; // Each character is revesred and stored in the string 'reverse.'


                    }
                    reverse += " ";

                }

                Console.WriteLine(reverse); // The final output is printed.

            }

            catch
            {
                throw;
            }
            return null;
        }


        public static int MinimumSum(int[] l2)
        {
            try
            {

                int res = 0;
                for (int i = 0; i <= l2.Length - 1; i++)
                {
                    res = res + l2[i]; // Calculating sum of elements in array 
                    if (i != l2.Length - 1 && l2[i + 1] == l2[i])
                    {
                        l2[i + 1] = l2[i + 1] + 1;
                    }
                } // Comparing each element in array with previous one and adding one in it (l2[i+1]) if found similar
                return res;

            }
            catch (Exception)
            {
                throw;
            }
            return 0;
        }


        public static int[] Intersect1(int[] nums1, int[] nums2)
        {
            try
            {
                // Write your code here
                Array.Sort(nums1);
                Array.Sort(nums2);
                // Sorted both the array
                int m = nums1.Length;
                int n = nums2.Length;
                int i = 0, j = 0;
                ArrayList myAL = new ArrayList();// Creates and initializes a new ArrayList.


                while (i < m && j < n)
                {
                    if (nums1[i] < nums2[j])
                        i++;
                    else if (nums2[j] < nums1[i])
                        j++; // comparing elements in both the array with each other to find intersection
                    else
                    {

                        myAL.Add(nums2[j++]);
                        i++;
                    }  // Stored the same elements from both the array in myAL

                }
                // converting myAL arraylist to array

                object[] obj1 = myAL.ToArray();
                // created a new array a 
                int[] a = new int[obj1.Length];
                int x = 0;
                foreach (int st in obj1)
                {

                    a[x++] = st;
                }
                return a;
            }

            catch
            {
                throw;
            }
            return new int[] { };
        }

        public static int[] Intersect2(int[] nums1, int[] nums2)
        {
            try
            {
                var Countnum = new Dictionary<int, int>(); // creating a dictionary

                foreach (var num in nums1)
                {
                    if (!Countnum.ContainsKey(num)) // check if the number exist in the dictionary and add into dictionary if not present
                        Countnum[num] = 0;
                    Countnum[num]++;
                }

                var Intersection = new List<int>();

                foreach (var num in nums2)
                {
                    if (Countnum.ContainsKey(num) && Countnum[num] > 0) //check if number in num2 are present in the dictionary 
                    {
                        Intersection.Add(num);// if number is present in num2 add to a list  

                        Countnum[num]--;
                    }

                }
                return Intersection.ToArray();
            }

            catch
            {
                throw;
            }
            return new int[] { };
        }



        public static string FreqSort(string s)
        {
            if (string.IsNullOrEmpty(s))
                return s;

            Dictionary<char, int> dict = new Dictionary<char, int>();
            Dictionary<int, List<char>> dictr = new Dictionary<int, List<char>>();

            //calculate frequencies by char
            foreach (var c in s)
            {
                if (!dict.ContainsKey(c))
                {
                    dict.Add(c, 0);                        //add letter to cache if it previously didn't exist. [Key = letter, Value = Frequency]
                }

                dict[c]++;                                 //Increase the count of the letter if it is repeated
            }

            //reverse cache:chars by frequency
            foreach (var k in dict.Keys)
            {
                if (!dictr.ContainsKey(dict[k]))
                    dictr.Add(dict[k], new List<char>());

                dictr[dict[k]].Add(k);
            }


            StringBuilder sb = new StringBuilder();
            var l = dictr.Keys.ToList();
            l.Sort();                                       //Sorting and Reversing the list so that the list contains frequency of letters in descending order
            l.Reverse();

            //Build a new string by appending to the string by the frequency of letters stored in List "l"
            foreach (var f in l)
            {
                foreach (var c in dictr[f])
                    for (int i = 0; i < f; i++)
                        sb.Append(c);
            }


            return sb.ToString();

        }
        public static bool ContainsDuplicate(char[] arr, int k)
        {
            // We have created a dictionary for storing the characters and checking for duplicates.
            var d = new Dictionary<char, int>(); //The key type here is char and the value is the index of the char element in the array. 

            for (int i = 0; i < arr.Length; i++)
            {
                if (d.ContainsKey(arr[i]))
                {
                    int diff = 0;
                    diff = i - d[arr[i]]; // Here i have taken the difference of the index positions of the char elements. 
                    if (diff < 0)
                        diff = diff * (-1); // This is a corner case, if the diff is negative, it will become positive with this LOC
                    if (diff == k)
                        return true;
                }
                else
                {
                    d[arr[i]] = i; // In this statement, we are basically adding elements to the dictionary. As we add the elements, if we get a duplicate,
                                   // it will go through the if loop above.
                }
            }
            return false;
        }

        //Question 7
        public static int GoldRod(int rodLength)
        {
            try
            {
                // As per the rodLength returning the values of PriceProduct
                if (rodLength == 2)
                    return 1;
                else if (rodLength == 3)
                    return 2;
                else if (rodLength == 4)
                    return 4;
                else if (rodLength == 5)
                    return 6;
                else if (rodLength == 6)
                    return 9;
                else
                    return 3 * GoldRod(rodLength - 3); // Recursion used

            }
            catch (Exception)
            {
                throw;
            }
            return 0;
        }

        //Question 8
        public static bool DictSearch(string[] userDict, string keyword)
        {

            //for(int i = 0; i < keyword.Length; i++)
            //{
            //    if (keyword == userDict[i])
            //        return false;
            //}
            int same = 0;
            //for (int i = 0; i < userDict.Length; i++)
            //{
            //    if (userDict[i].Length != keyword.Length)
            //        return false;
            //}
            for (int i = 0; i < userDict.Length; i++)                   //looping through every word in the array, "userDict"
            {
                same = 0;
                for (int j = 0; j < userDict[i].Length; j++)        //new iteration variable "j" to access each letter in the word
                {

                    if (userDict[i][j] == keyword[j])               //comparing each letter of every word in the array to each letter of keyword
                    {
                        same = same + 1;
                       // Console.WriteLine(same);
                    }

                }
                if (same == keyword.Length - 1)
                    return true;

            }

            return false;

        }
        public static void SolvePuzzle()
        {
            Dictionary<char, int> dict = new Dictionary<char, int>();
            Console.WriteLine("Enter the string 1");
            String inp_1 = Console.ReadLine();
            Console.WriteLine("Enter the String 2");
            String inp_2 = Console.ReadLine();
            Console.WriteLine("Enter the Result String 3");
            String output = Console.ReadLine();
            String fin = String.Concat(inp_1, inp_2, output);

            //Here i have first taken the inputs and outputs from the user. I have stored them in 3 string variables,

            var distinct1 = new HashSet<char>(fin);
            List<char> unichar = distinct1.ToList();
            Char[] str1 = inp_1.ToCharArray();
            Char[] str2 = inp_2.ToCharArray();
            Char[] str3 = output.ToCharArray();

            // In the above LOC i have taken a dictionary. In this dictionary i will store the characters and assign a number to them. For the 
            // duplicates, i will just ignore. The strings have been changed to char arrays.
            //The sum of the numbers of the input words are taken in sum and the sum of the output is stored in another variable.
            // The difference between the sums will be distributed amongst the unique characters of the output string.

        }



    }
}
