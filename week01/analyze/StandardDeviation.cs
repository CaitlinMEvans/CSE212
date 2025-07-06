/// <summary>
/// These 3 functions will (in different ways) calculate the standard
/// deviation from a list of numbers.  The standard deviation
/// is defined as the square root of the variance.  The variance is 
/// defined as the average of the squared differences from the mean.
/// </summary>
public static class StandardDeviation {
    public static void Run() {
        var numbers = new[] { 600, 470, 170, 430, 300 };
        Console.WriteLine(StandardDeviation1(numbers)); // Should be 147.322 
        Console.WriteLine(StandardDeviation2(numbers)); // Should be 147.322 
        Console.WriteLine(StandardDeviation3(numbers)); // Should be 147.322 
    }

    /// <summary>
    /// BIG O ANALYSIS: O(n) - Linear Time
    /// Two separate loops, each running n times: O(n) + O(n) = O(n)
    /// </summary>
    private static double StandardDeviation1(int[] numbers) {
        var total = 0.0;
        var count = 0;
        foreach (var number in numbers) {
            total += number;
            count += 1;
        }

        var avg = total / count;
        var sumSquaredDifferences = 0.0;
        foreach (var number in numbers) {
            sumSquaredDifferences += Math.Pow(number - avg, 2);
        }

        var variance = sumSquaredDifferences / count;
        return Math.Sqrt(variance);
    }

    /// <summary>
    /// BIG O ANALYSIS: O(n²) - Quadratic Time
    /// Outer loop runs n times, inner loop runs n times each iteration
    /// Calculates the average inside the outer loop repeatedly (inefficient)
    /// </summary>
    private static double StandardDeviation2(int[] numbers) {
        var sumSquaredDifferences = 0.0;
        var countNumbers = 0;
        foreach (var number in numbers) {
            var total = 0;
            var count = 0;
            foreach (var value in numbers) {
                total += value;
                count += 1;
            }

            var avg = total / count;
            sumSquaredDifferences += Math.Pow(number - avg, 2);
            countNumbers += 1;
        }

        var variance = sumSquaredDifferences / countNumbers;
        return Math.Sqrt(variance);
    }

    /// <summary>
    /// BIG O ANALYSIS: O(n) - Linear Time
    /// Sum() method is O(n), plus one loop of O(n) = O(n)
    /// Most efficient implementation
    /// </summary>
    private static double StandardDeviation3(int[] numbers) {
        var count = numbers.Length;
        var avg = (double)numbers.Sum() / count;
        var sumSquaredDifferences = 0.0;
        foreach (var number in numbers) {
            sumSquaredDifferences += Math.Pow(number - avg, 2);
        }

        var variance = sumSquaredDifferences / count;
        return Math.Sqrt(variance);
    }
}