using System;
using System.Collections.Generic;
using System.Linq;

public class Mixing 
{
    public static string Mix(string s1, string s2)
    {
        // does some weird string comparison thing
        // returning a string in a certain format based on the max number of
        // occurrences of each letter and whether that max was in s1, s2, or both
        Dictionary<int,List<char>> dict = new Dictionary<int,List<char>>();
        char[] letters = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
        int[] count1 = new int[26];
        int[] count2 = new int[26];
        int[] max = new int[26];
        Dictionary<char,int> which = new Dictionary<char,int>();

        // count letters in each string and record max value
        for(int i=0; i < 26; i++){
            // count letters in each string
            count1[i] = s1.Count(x => x == letters[i]);
            count2[i] = s2.Count(x => x == letters[i]);

            // record max and whether they are the same
            if (count1[i] > count2[i]) {
            max[i] = count1[i];
            which[letters[i]] = 1;
            }
            else if (count2[i] > count1[i]) {
            max[i] = count2[i];
            which[letters[i]] = 2;
            }
            else {
            max[i] = count1[i];
            which[letters[i]] = 0;
            }

            // record letters for given max count in dict
            if (dict.ContainsKey(max[i])){
            dict[max[i]].Add(letters[i]);
            }
            else{
            dict[max[i]] = new List<char>();
            dict[max[i]].Add(letters[i]);
            }
        }

        // get ordered array of max counts
        int[] maxes = new int[dict.Count];
        int pos = 0;
        foreach (KeyValuePair<int,List<char>> kp in dict) {
            maxes[pos] = kp.Key;
            pos++;
        }
        Array.Sort(maxes);

        // create string
        string answer = "";
        for (int i=0; i < maxes.Length; i++){
            int j = maxes.Length - 1 - i; // for traversing backwards
            if (maxes[j] < 2) break;

        // deal with unstated sorting requirement
            foreach (char c in dict[maxes[j]]) {
                // if s1 alone had the max
                if (which[c] == 1) {
                    answer += "1:";
                    for (int k=0; k < maxes[j]; k++){
                        answer += c.ToString();
                    }
                    answer += "/";
                }
            }
            foreach (char c in dict[maxes[j]]) {
                // if s2 alone had the max
                if (which[c] == 2) {
                    answer += "2:";
                    for (int k=0; k < maxes[j]; k++){
                        answer += c.ToString();
                    }
                    answer += "/";
                }
            }
            foreach (char c in dict[maxes[j]]) {
                // if they shared the max
                if (which[c] == 0) {
                    answer += "=:";
                    for (int k=0; k < maxes[j]; k++){
                        answer += c.ToString();
                    }
                    answer += "/";
                }
            }
        }
        if (answer.Length > 0){
            answer = answer.Substring(0,answer.Length-1);
        }
        return answer;
    
  }
}
