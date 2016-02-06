using System;
public static class Kata
{
    public static int CountCombinations(int money, int[] coins)
    {
        // counts the number of ways to create $money using denominations in coins array
        // ignoring different orderings of the coins
        
        int[] ways = new int[money+1];

        // induct on coins to ignore order in the # of ways
        foreach (int c in coins) {
            for (int v = 0; v <= money; v++) {
                //base case
                if (v == c){
                    ways[v] += 1;
                }

                //inductive cases
                if (v > c){
                    ways[v] += ways[v-c];
                }
            }
        }

        return ways[money];
    }
}
