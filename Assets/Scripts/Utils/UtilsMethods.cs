using System.Collections;
using System.Collections.Generic;
using System;

namespace Utils
{
    public static class UtilsMethods
    {
        public static void ShuffleArr<T>(T[] arr)
        {
            Random random = new Random();

            for (int i = arr.Length - 1; i >= 1; i--)
            {
                int j = random.Next(i + 1);

                var temp = arr[j];
                arr[j] = arr[i];
                arr[i] = temp;
            }
        }
    }
}