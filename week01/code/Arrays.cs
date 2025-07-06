public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // PLAN:
        // 1. Create a new array of doubles with size 'length'
        // 2. Use a loop to iterate from 0 to length-1 (array indices)
        // 3. For each index i, calculate the multiple: number * (i + 1)
        //    - We use (i + 1) because we want 1st multiple, 2nd multiple, etc.
        //    - Example: for number=7, we want 7*1, 7*2, 7*3, etc.
        // 4. Store each calculated multiple in the array at index i
        // 5. Return the completed array

        // Create array to store the multiples
        double[] result = new double[length];
        
        // Calculate each multiple and store in array
        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1);
        }
        
        return result;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // PLAN:
        // 1. Handle edge cases: if data is empty or amount is 0, do nothing
        // 2. Normalize the amount using modulo to handle cases where amount > data.Count
        //    - Example: rotating by 10 in a list of 9 items is same as rotating by 1
        // 3. Use the "reverse sections" approach to rotate:
        //    - Reverse the entire list
        //    - Reverse the first 'amount' elements
        //    - Reverse the remaining elements
        // 4. This approach modifies the list in-place as required
        //
        // Example with {1,2,3,4,5,6,7,8,9} rotating right by 3:
        // Original: {1,2,3,4,5,6,7,8,9}
        // Step 1 - Reverse all: {9,8,7,6,5,4,3,2,1}
        // Step 2 - Reverse first 3: {7,8,9,6,5,4,3,2,1}
        // Step 3 - Reverse remaining: {7,8,9,1,2,3,4,5,6} 

        // Handle edge cases
        if (data.Count == 0 || amount == 0)
            return;
        
        // Normalize amount to handle cases where amount > data.Count
        amount = amount % data.Count;
        
        // If amount is 0 after modulo, no rotation needed
        if (amount == 0)
            return;
        
        // Helper method to reverse a section of the list
        void ReverseSection(List<int> list, int start, int end)
        {
            while (start < end)
            {
                // Swap elements at start and end positions
                int temp = list[start];
                list[start] = list[end];
                list[end] = temp;
                start++;
                end--;
            }
        }
        
        // Step 1: Reverse the entire list
        ReverseSection(data, 0, data.Count - 1);
        
        // Step 2: Reverse the first 'amount' elements
        ReverseSection(data, 0, amount - 1);
        
        // Step 3: Reverse the remaining elements
        ReverseSection(data, amount, data.Count - 1);
    }
}