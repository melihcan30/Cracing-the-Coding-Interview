using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace CracingTheCodingInterview
{
    class Palindrome
    {
        public static void FindLongestPalindromicString(String text)
        {
            int size = text.Length;
            if (size == 0)
            {
                return;
            }

            size = 2 * size + 1;

            int[] Array = new int[size];
            Array[0] = 0;
            Array[1] = 1;

            int CenterPosition = 1;
            int RightPosition = 2;
            int i = 0;

            int iMirror;
            int expand = -1;
            int diff = -1;
            int MaxLPSLenght = 0;
            int MaxLPSCenterPosition = 0;
            int start = -1;
            int end = -1;

            for (i = 2; i < size; i++)
            {
                iMirror = 2 * CenterPosition - i;
                expand = 0;
                diff = RightPosition - i;

                if (diff >= 0)
                {
                    if (Array[iMirror] < diff)
                    {
                        Array[i] = Array[iMirror];
                    }
                    else if (Array[iMirror] == diff && RightPosition == size - 1)
                    {
                        Array[i] = Array[iMirror];
                    }
                    else if (Array[iMirror] == diff && RightPosition < size - 1)
                    {
                        Array[i] = Array[iMirror];
                        expand = 1;
                    }
                    else if (Array[iMirror] > diff)
                    {
                        Array[i] = diff;
                        expand = 1;
                    }
                }
                else
                {
                    Array[i] = 0;
                    expand = 1;
                }

                if (expand == 1)
                {
                    try
                    {
                        while (((i + Array[i]) < size && (i - Array[i]) > 0)&& (((i + Array[i] + 1) % 2 == 0) || (text[(i + Array[i] + 1) / 2] == text[(i - Array[i] - 1) / 2])))
                        {
                            Array[i]++;
                        }
                    }
                    catch (Exception)
                    {

                        Debug.Assert(true);
                    }
                }

                if (Array[i] > MaxLPSLenght)
                {
                    MaxLPSLenght = Array[i];
                    MaxLPSCenterPosition = i;
                }
                if (i + Array[i] > RightPosition)
                {
                    CenterPosition = i;
                    RightPosition = i + Array[i];
                }
            }
            start = (MaxLPSCenterPosition - MaxLPSLenght) / 2;
            end = start + MaxLPSLenght - 1;

            Console.Write("LPS of string is " + text + " : ");

            for (i = start; i <= end; i++)
            {
                Console.Write(text[i]);
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            

            String text1 = "babcbabcbaccba";
            FindLongestPalindromicString(text1);

            String text2 = "abaaba";
            FindLongestPalindromicString(text2);

            String text3 = "abababa";
            FindLongestPalindromicString(text3);

            String text4 = "abcbabcbabcba";
            FindLongestPalindromicString(text4);

            String text5 = "melihhilem";
            FindLongestPalindromicString(text5);

            String text6 = "caba";
            FindLongestPalindromicString(text6);

            String text7 = "abacdfgdcaba";
            FindLongestPalindromicString(text7);

            String text8 = "abacdfgdcabba";
            FindLongestPalindromicString(text8);

            String text9 = "abacdedcaba";
            FindLongestPalindromicString(text9);
        }
    }
}
