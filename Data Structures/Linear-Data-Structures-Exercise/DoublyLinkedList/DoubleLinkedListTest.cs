namespace DoublyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Xunit;

    public class UnitTestsDoublyLinkedList
    {
        [Fact]
        public void AddFirst_WithEmptyList_ShouldAddElement()
        {
            // Arrange
            var list = new DoublyLinkedList<int>();

            // Act
            list.AddFirst(5);

            // Assert
            Assert.Equal(1, list.Count);

            var items = new List<int>();
            list.ForEach(items.Add);
            Assert.Equal(items, new List<int> { 5 });
        }

        [Fact]
        public void AddFirst_SeveralElements_ShouldAddElementsCorrectly()
        {
            // Arrange
            var list = new DoublyLinkedList<int>();

            // Act
            list.AddFirst(10);
            list.AddFirst(5);
            list.AddFirst(3);

            // Assert
            Assert.Equal(3, list.Count);

            var items = new List<int>();
            list.ForEach(items.Add);
            Assert.Equal(items, new List<int>() { 3, 5, 10 });
        }

        [Fact]
        public void AddLast_EmptyList_ShouldAddElement()
        {
            // Arrange
            var list = new DoublyLinkedList<int>();

            // Act
            list.AddLast(5);

            // Assert
            Assert.Equal(1, list.Count);

            var items = new List<int>();
            list.ForEach(items.Add);
            Assert.Equal(items, new List<int> { 5 });
        }

        [Fact]
        public void AddLast_SeveralElements_ShouldAddElementsCorrectly()
        {
            // Arrange
            var list = new DoublyLinkedList<int>();

            // Act
            list.AddLast(5);
            list.AddLast(10);
            list.AddLast(15);

            // Assert
            Assert.Equal(3, list.Count);

            var items = new List<int>();
            list.ForEach(items.Add);
            Assert.Equal(items, new List<int> { 5, 10, 15 });
        }

        [Fact]
        public void RemoveFirst_OneElement_ShouldMakeListEmpty()
        {
            // Arrange
            var list = new DoublyLinkedList<int>();
            list.AddLast(5);

            // Act
            var element = list.RemoveFirst();

            // Assert
            Assert.Equal(5, element);
            Assert.Equal(0, list.Count);

            var items = new List<int>();
            list.ForEach(items.Add);
            Assert.Equal(items, new List<int> { });
        }

        [Fact]
        public void RemoveFirst_EmptyList_ShouldThrowException()
        {
            // Arrange
            var list = new DoublyLinkedList<int>();

            // Act && Assert
            Assert.Throws<InvalidOperationException>(() => list.RemoveFirst());
        }

        [Fact]
        public void RemoveFirst_SeveralElements_ShouldRemoveElementsCorrectly()
        {
            // Arrange
            var list = new DoublyLinkedList<int>();
            list.AddLast(5);
            list.AddLast(6);
            list.AddLast(7);

            // Act
            var element = list.RemoveFirst();

            // Assert
            Assert.Equal(5, element);
            Assert.Equal(2, list.Count);

            var items = new List<int>();
            list.ForEach(items.Add);
            Assert.Equal(items, new List<int> { 6, 7 });
        }

        [Fact]
        public void RemoveLast_OneElement_ShouldMakeListEmpty()
        {
            // Arrange
            var list = new DoublyLinkedList<int>();
            list.AddFirst(5);

            // Act
            var element = list.RemoveLast();

            // Assert
            Assert.Equal(5, element);
            Assert.Equal(0, list.Count);

            var items = new List<int>();
            list.ForEach(items.Add);
            Assert.Equal(items, new List<int> { });
        }

        [Fact]
        public void RemoveLast_EmptyList_ShouldThrowException()
        {
            // Arrange
            var list = new DoublyLinkedList<int>();

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => list.RemoveLast());
        }

        [Fact]
        public void RemoveLast_SeveralElements_ShouldRemoveElementsCorrectly()
        {
            // Arrange
            var list = new DoublyLinkedList<int>();
            list.AddFirst(10);
            list.AddFirst(9);
            list.AddFirst(8);

            // Act
            var element = list.RemoveLast();

            // Assert
            Assert.Equal(10, element);
            Assert.Equal(2, list.Count);

            var items = new List<int>();
            list.ForEach(items.Add);
            Assert.Equal(items, new List<int> { 8, 9 });
        }

        [Fact]
        public void ForEach_EmptyList_ShouldEnumerateElementsCorrectly()
        {
            // Arrange
            var list = new DoublyLinkedList<int>();

            // Act
            var items = new List<int>();
            list.ForEach(items.Add);

            // Assert
            Assert.Equal(items, new List<int> { });
        }

        [Fact]
        public void ForEach_SingleElement_ShouldEnumerateElementsCorrectly()
        {
            // Arrange
            var list = new DoublyLinkedList<int>();
            list.AddLast(5);

            // Act
            var items = new List<int>();
            list.ForEach(items.Add);

            // Assert
            Assert.Equal(items, new List<int> { 5 });
        }

        [Fact]
        public void ForEach_MultipleElements_ShouldEnumerateElementsCorrectly()
        {
            // Arrange
            var list = new DoublyLinkedList<string>();
            list.AddLast("Five");
            list.AddLast("Six");
            list.AddLast("Seven");

            // Act
            var items = new List<string>();
            list.ForEach(items.Add);

            // Assert
            Assert.Equal(items, new List<string> { "Five", "Six", "Seven" });
        }

        [Fact]
        public void IEnumerable_Foreach_MultipleElements()
        {
            // Arrange
            var list = new DoublyLinkedList<string>();
            list.AddLast("Five");
            list.AddLast("Six");
            list.AddLast("Seven");

            // Act
            var items = new List<string>();

            foreach (var element in list)
            {
                items.Add(element);
            }

            // Assert
            Assert.Equal(items, new List<string> { "Five", "Six", "Seven" });
        }

        [Fact]
        public void IEnumerable_NonGeneric_MultipleElements()
        {
            // Arrange
            var list = new DoublyLinkedList<object>();
            list.AddLast("Five");
            list.AddLast(6);
            list.AddLast(7.77);

            // Act
            var enumerator = ((IEnumerable)list).GetEnumerator();
            var items = new List<object>();

            while (enumerator.MoveNext())
            {
                items.Add(enumerator.Current);
            }

            // Assert
            Assert.Equal(items, new List<object>() { "Five", 6, 7.77 });
        }

        [Fact]
        public void ToArray_EmptyList_ShouldReturnEmptyArray()
        {
            // Arrange
            var list = new DoublyLinkedList<string>();

            // Act
            var arr = list.ToArray();

            // Assert
            Assert.Equal(arr, new List<string> { });
        }

        [Fact]
        public void ToArray_NonEmptyList_ShouldReturnArray()
        {
            // Arrange
            var list = new DoublyLinkedList<string>();
            list.AddLast("Five");
            list.AddLast("Six");
            list.AddLast("Seven");

            // Act
            var arr = list.ToArray();

            // Assert
            Assert.Equal(arr, new[] { "Five", "Six", "Seven" });
        }
    }
}
