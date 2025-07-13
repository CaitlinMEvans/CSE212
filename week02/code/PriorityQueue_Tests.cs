using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add items with different priorities and dequeue them
    // Expected Result: Items should come out in priority order (highest first)
    // Defect(s) Found: Loop condition in Dequeue is wrong - should be < _queue.Count, not < _queue.Count - 1.
    // Also, item isn't actually being removed from the queue after finding it.
    public void TestPriorityQueue_BasicPriority()
    {
        var priorityQueue = new PriorityQueue();
        
        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("High", 5);
        priorityQueue.Enqueue("Medium", 3);
        
        Assert.AreEqual("High", priorityQueue.Dequeue());
        Assert.AreEqual("Medium", priorityQueue.Dequeue());
        Assert.AreEqual("Low", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Add items with same priority and verify FIFO behavior for equal priorities
    // Expected Result: Items with same priority should come out in the order they were added
    // Defect(s) Found: The >= comparison should be > to maintain FIFO for equal priorities.
    public void TestPriorityQueue_SamePriority()
    {
        var priorityQueue = new PriorityQueue();
        
        priorityQueue.Enqueue("First", 3);
        priorityQueue.Enqueue("Second", 3);
        priorityQueue.Enqueue("Third", 3);
        
        Assert.AreEqual("First", priorityQueue.Dequeue());
        Assert.AreEqual("Second", priorityQueue.Dequeue());
        Assert.AreEqual("Third", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Try to dequeue from empty queue
    // Expected Result: Should throw InvalidOperationException
    // Defect(s) Found: This should work correctly as written.
    public void TestPriorityQueue_EmptyQueue()
    {
        var priorityQueue = new PriorityQueue();
        
        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
    }

    [TestMethod]
    // Scenario: Mix of priorities with some equal values
    // Expected Result: Higher priorities first, FIFO within same priority
    // Defect(s) Found: Same issues as above tests will show up here.
    public void TestPriorityQueue_MixedPriorities()
    {
        var priorityQueue = new PriorityQueue();
        
        priorityQueue.Enqueue("A", 2);
        priorityQueue.Enqueue("B", 5);
        priorityQueue.Enqueue("C", 2);
        priorityQueue.Enqueue("D", 5);
        priorityQueue.Enqueue("E", 1);
        
        Assert.AreEqual("B", priorityQueue.Dequeue()); // First item with priority 5
        Assert.AreEqual("D", priorityQueue.Dequeue()); // Second item with priority 5
        Assert.AreEqual("A", priorityQueue.Dequeue()); // First item with priority 2
        Assert.AreEqual("C", priorityQueue.Dequeue()); // Second item with priority 2
        Assert.AreEqual("E", priorityQueue.Dequeue()); // Only item with priority 1
    }

    [TestMethod]
    // Scenario: Single item in queue
    // Expected Result: That item should be returned
    // Defect(s) Found: Should work but might reveal the removal bug.
    public void TestPriorityQueue_SingleItem()
    {
        var priorityQueue = new PriorityQueue();
        
        priorityQueue.Enqueue("Only", 1);
        
        Assert.AreEqual("Only", priorityQueue.Dequeue());
        
        // Verify queue is now empty
        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Queue should be empty now.");
        }
        catch (InvalidOperationException)
        {
            // Expected behavior
        }
    }
}