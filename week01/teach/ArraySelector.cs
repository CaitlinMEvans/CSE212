public static class ArraySelector
{
    public static void Run()
    {
        var l1 = new[] { 1, 2, 3, 4, 5 };
        var l2 = new[] { 2, 4, 6, 8, 10};
        var select = new[] { 1, 1, 1, 2, 2, 1, 2, 2, 2, 1};
        var intResult = ListSelector(l1, l2, select);
        Console.WriteLine("<int[]>{" + string.Join(", ", intResult) + "}"); // <int[]>{1, 2, 3, 2, 4, 4, 6, 8, 10, 5}
    }

    private static int[] ListSelector(int[] list1, int[] list2, int[] select)
    {
        // PLAN:
        // 1. Create a result array with size equal to the selector array length
        // 2. Keep track of current position in list1 and list2 with index variables
        // 3. Loop through each value in the selector array:
        //    - If selector value is 1: take next item from list1, increment list1 index
        //    - If selector value is 2: take next item from list2, increment list2 index
        // 4. Add the selected item to the result array
        // 5. Return the completed result array
        
        int[] result = new int[select.Length];
        int list1Index = 0;  // Track position in list1
        int list2Index = 0;  // Track position in list2
        
        // Loop through each selector value
        for (int i = 0; i < select.Length; i++) {
            if (select[i] == 1) {
                // Select from list1 and move to next position in list1
                result[i] = list1[list1Index];
                list1Index++;
            }
            else if (select[i] == 2) {
                // Select from list2 and move to next position in list2
                result[i] = list2[list2Index];
                list2Index++;
            }
        }
        
        return result;
    }
}
