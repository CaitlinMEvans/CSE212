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

        // PLAN FOR SOLVING "MULTIPLESOF":
        // 1. Create a new array of doubles with size 'length'
        // 2. Use a loop to iterate from 0 to length-1 (array indices)
        // 3. For each index i, calculate the multiple: number * (i + 1)
        //    - We use (i + 1) because we want 1st multiple, 2nd multiple, etc.
        //    - Example: for number=7, we want 7*1=7, 7*2=14, 7*3=21, etc.
        // 4. Store each calculated multiple in the array at index i
        // 5. Return the completed array

        // Step 1: Create array to store the multiples
        double[] result = new double[length];
        
        // Step 2-4: Calculate each multiple and store in array
        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1);
        }
        
        // Step 5: Return the completed array
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

        // PLAN FOR SOLVING ROTATELISTRIGHT:
        // Approach: Use list slicing with GetRange, RemoveRange, and InsertRange methods
        // 1. Handle edge cases: if data is empty or amount is 0, do nothing
        // 2. Normalize the amount using modulo to handle cases where amount > data.Count
        //    - Example: rotating by 10 in a list of 9 items is same as rotating by 1
        // 3. Calculate the split point: where to cut the list for rotation
        //    - For right rotation by 'amount', we take the last 'amount' elements
        //    - Split point = data.Count - amount
        // 4. Use GetRange to extract the portion that moves to the front
        // 5. Use RemoveRange to remove that portion from the original location
        // 6. Use InsertRange to insert the extracted portion at the beginning
        //
        // Example with {1,2,3,4,5,6,7,8,9} rotating right by 3:
        // Original: {1,2,3,4,5,6,7,8,9}
        // Split point: 9-3 = 6, so split at index 6
        // Extract: {7,8,9} (from index 6 to end)
        // Remove: {7,8,9} from original, leaving {1,2,3,4,5,6}
        // Insert: {7,8,9} at beginning: {7,8,9,1,2,3,4,5,6} ✓

        // Step 1: Handle edge cases
        if (data.Count == 0 || amount == 0)
            return;
        
        // Step 2: Normalize amount to handle cases where amount > data.Count
        amount = amount % data.Count;
        
        // If amount is 0 after modulo, no rotation needed
        if (amount == 0)
            return;
        
        // Step 3: Calculate split point for right rotation
        int splitPoint = data.Count - amount;
        
        // Step 4: Extract the portion that will move to the front
        List<int> rotatingPortion = data.GetRange(splitPoint, amount);
        
        // Step 5: Remove the rotating portion from its current location
        data.RemoveRange(splitPoint, amount);
        
        // Step 6: Insert the rotating portion at the beginning
        data.InsertRange(0, rotatingPortion);
    }
}