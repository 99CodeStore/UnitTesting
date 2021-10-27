using NUnit.Framework;
using System;


namespace Fundamentals.Tests
{
    [TestFixture()]
    public class StackTests
    {

        private Stack<string> stack;

        //Setup 
        //TearDown
        [SetUp]
        public void Setup()
        {
              stack = new Stack<string>();
        }
        [Test]
        public void Pop_StackHasSomeObjects_RemoveTopObject()
        {
          
            stack.Push("India");
            stack.Push("UK");
            stack.Push("US");
            // Act
            stack.Pop();
            // Assert
            Assert.That(stack.Count, Is.EqualTo(2), "Its remove Top element of the Stack");
        }
        [Test]
        public void Pop_StackHasSomeObjects_ReturnTopObject()
        {
            // Arrange
         
            stack.Push("India");
            stack.Push("UK");
            stack.Push("US");
            // Act
            var result = stack.Pop();
            // Assert
            Assert.That(result, Is.EqualTo("US"), "Its Reruns Top element of the Stack");
        }

        [Test()]
        public void Pop_EmptyStack_ThrowInvalidOperationException()
        {
            
            Assert.That(() => stack.Pop(), Throws.InvalidOperationException);
        }

        [Test]
        public void Peek_StackHasSomeObjects_ReturnTopObject()
        {
            // Arrange
           
            stack.Push("India");
            stack.Push("UK");
            stack.Push("US");
            // Act
            var result = stack.Peek();
            // Assert
            Assert.That(result, Is.EqualTo("US"), "Its Reruns Top element of the Stack");
        }

        [Test()]
        public void Peek_EmptyStack_ThrowInvalidOperationException()
        {
             
            Assert.That(() => stack.Peek(), Throws.InvalidOperationException);
        }

        [Test]
        public void Peek_StackHasSomeObjects_RemoveTopObject()
        {
            // Arrange
            
            stack.Push("India");
            stack.Push("UK");
            stack.Push("US");
            // Act
            stack.Peek();
            // Assert
            Assert.That(stack.Count, Is.EqualTo(3), "Its not remove Top element of the Stack");
        }


        [Test()]
        public void Push_NullInput_ThrowArgumentNullException()
        {
             
            Assert.That(() => stack.Push(null), Throws.ArgumentNullException);
        }

        [Test()]
        [TestCase("India", 1)]
        [TestCase("SL", 1)]
        [TestCase("US", 1)]
        public void Push_ValidInput_AddedToStack(string input, int expectedResult)
        {
            
            stack.Push(input);
            Assert.AreEqual(expectedResult, stack.Count);
        }

        [Test]
        public void Count_EmptyStack_ReturnZero()
        {
           
            Assert.That(stack.Count, Is.EqualTo(0));
        }
    }
}