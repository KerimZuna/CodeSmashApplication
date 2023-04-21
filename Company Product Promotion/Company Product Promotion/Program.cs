class Program
{
    static void Main(string[] args)
    {
        //Example 1 - the expected output is 1 
        string[][] codeList1 = new string[][] { new string[] { "apple", "apple" }, new string[] { "banana", "anything", "banana" } };
        string[] shoppingCart1 = new string[] { "orange", "apple", "apple", "banana", "orange", "banana" };

        //Example 2 - the expected output is 0 
        string[][] codeList2 = new string[][] { new string[] { "apple", "apple" }, new string[] { "banana", "anything", "banana" } };
        string[] shoppingCart2 = new string[] { "banana", "orange", "banana", "apple", "apple" };

        //Example 3 - the expected output is 0 
        string[][] codeList3 = new string[][] { new string[] { "apple", "apple" }, new string[] { "banana", "anything", "banana" } };
        string[] shoppingCart3 = new string[] { "apple", "banana", "apple", "banana", "orange", "banana" };

        //Example 4 - the expected output is 0 
        string[][] codeList4 = new string[][] { new string[] { "apple", "apple" }, new string[] { "apple", "apple", "banana" } };
        string[] shoppingCart4 = new string[] { "apple", "apple", "apple", "banana" };

        Console.WriteLine(check(codeList1, shoppingCart1));
        Console.WriteLine(check(codeList2, shoppingCart2));
        Console.WriteLine(check(codeList3, shoppingCart3));
        Console.WriteLine(check(codeList4, shoppingCart4));
    }

    // Check whether there is a match between each element in codeList and shoppingCart
    private static int check(string[][] codeList, string[] shoppingCart)
    {
        // Corner cases
        // Check if the codeList parameter is null or has a length of 0 as that means that the secret code for that day has not been given
        if (codeList == null || codeList.Length == 0)
        {
            // If it is, return 1 as the expected output is 1 in this case
            return 1;
        }

        // Check if the shoppingCart parameter is null or has a length of 0 as that means that the buyer hadn't bought anything
        if (shoppingCart == null || shoppingCart.Length == 0)
        {
            // If it is, return 0 as the expected output is 0 in this case
            return 0;
        }

        // Initialize variables for iterating through codeList and shoppingCart
        int i = 0, j = 0;

        // Check if there is a match in shoppingCart
        while (i < codeList.Length && j + codeList[i].Length <= shoppingCart.Length)
        {
            // Set match to true by default
            bool match = true;

            // Go through each element of codeList[i] and check if it matches shoppingCart[j+k]
            for (int k = 0; k < codeList[i].Length; k++)
            {
                // If codeList[i][k] is not "anything" and shoppingCart[j+k] does not match it, set match to false and break out of the loop
                if (!codeList[i][k].Equals("anything") && !shoppingCart[j + k].Equals(codeList[i][k]))
                {
                    match = false;
                    break;
                }
            }

            // If there is a match, increment j by the length of codeList[i] and increment i
            if (match)
            {
                j += codeList[i].Length;
                i++;
            }
            // If there is no match, increment j by 1
            else
            {
                j++;
            }
        }

        // If i is equal to the length of codeList, return 1 as there is a match
        // Otherwise, return 0 as there is no match
        return (i == codeList.Length) ? 1 : 0;
    }
}

/* Time complexity: O(m*n) because the code runs through each element of the codeList and the shoppingCart
 once using nested loops.
   Space complexity: O(1) because we use constant space for storing all of the elements
 */
