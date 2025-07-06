public static class Divisors {
    /// <summary>
    /// Entry point for the Divisors class
    /// </summary>
    public static void Run() {
        List<int> list = FindDivisors(80);
        Console.WriteLine("<List>{" + string.Join(", ", list) + "}"); // <List>{1, 2, 4, 5, 8, 10, 16, 20, 40}
        List<int> list1 = FindDivisors(79);
        Console.WriteLine("<List>{" + string.Join(", ", list1) + "}"); // <List>{1}
    }

    /// <summary>
    /// Create a list of all divisors for a number including 1
    /// and excluding the number itself. Modulo will be used
    /// to test divisibility.
    /// </summary>
    /// <param name="number">The number to find the divisor</param>
    /// <returns>List of divisors</returns>
    private static List<int> FindDivisors(int number) {
        List<int> results = new();
        
        // PLAN:
        // 1. Loop through all numbers from 1 to number-1 (excluding the number itself)
        // 2. For each potential divisor, use modulo operator (%) to check if it divides evenly
        // 3. If number % i == 0, then i is a divisor, so add it to the results list
        // 4. Return the completed list
        
        // Loop from 1 to number-1 to find all divisors
        for (int i = 1; i < number; i++) {
            // If i divides number evenly (remainder is 0), it's a divisor
            if (number % i == 0) {
                results.Add(i);
            }
        }
        
        return results;
    }
}