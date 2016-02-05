using System;
using System.Collections.Generic;

public class Kata
{
    public static long NextBiggerNumber(long n)
    {
        // returns the next number after n formed by rearranging digits of n
        int length = (int)Math.Floor(Math.Log10(n))+1;
        int[] digits = new int[length];
        int places = 0;

        digits[0] = (int)(n%10);
        n /= 10;
        for (int i=1; i<length; i++){
            digits[i] = (int)(n%10);
            n /= 10;
            places++;
            if (digits[i] < digits[i-1]) {
                return buildNumber(n,digits,places);
            }
        }
        return -1;
    }

    public static long buildNumber(long m, int[] digits, int places){
        int length = digits.Length;
        int digitToReplace = digits[places];
        
        // find next largest number to place here instead
        int max = 10;
        int pos = -1;
        for (int i = length-places+1; i < length; i++) {
            int j = length - 1 - i;
            if (digits[j] < max && digits[j] > digitToReplace) {
                max = digits[j];
                pos = j;
            }
        }

        // in case we didn't find any, use next number
        if (pos == -1){
            pos = length-places;
            max = digits[length - 1 - pos];
        }

        m *= 10;
        m += max;
        
        // order remaining digits and rebuild m
        int[] remainingDigits = new int[places+1];
        for (int i= length-places-1; i < length; i++){
            int j = length - 1 - i;
            remainingDigits[j] = digits[j];
        }

        Array.Sort(remainingDigits);

        bool skipped = false;
        foreach (int d in remainingDigits){
            // skip the digit we already used as replacement
            if (d == max && !skipped){
                skipped = true;
                continue;
            }
            m *= 10;
            m += d;
        }
        return m;
    }
}
