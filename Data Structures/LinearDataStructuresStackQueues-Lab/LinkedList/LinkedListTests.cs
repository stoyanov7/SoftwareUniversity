namespace LinkedList
{
    using System;
    using Xunit;

    public class LinkedListTests
    {
        [Fact]
        public void AddFirst_ShouldIncreaseCount()
        {
            // Arrange
            var list = new LinkedList<int>();

            // Act
            list.AddFirst(1);

            // Assert
            Assert.Equal(1, list.Count);
        }

        [Fact]
        public void AddFirst_ShouldAddCorrectElement()
        {
            // Arrange
            var list = new LinkedList<int>();

            // Act
            list.AddFirst(1);

            // Assert
            foreach (var item in list)
            {
                Assert.Equal(1, item);
            }
        }

        [Fact]
        public void AddFirst_MultipleElements_ShouldAddCorrectElements()
        {
            var list = new LinkedList<int>();

            for (var i = 0; i < 100; i++)
            {
                list.AddFirst(i);
            }

            var expected = 99;
            foreach (var item in list)
            {
                Assert.Equal(expected--, item);
            }
        }

        [Fact]
        public void AddLast_ShouldIncreaseCount()
        {
            // Arrange
            var list = new LinkedList<int>();

            // Act
            list.AddLast(1);

            // Assert
            Assert.Equal(1, list.Count);
        }

        [Fact]
        public void AddLast_ShouldAddCorrectElement()
        {
            var list = new LinkedList<int>();

            list.AddLast(1);

            foreach (var item in list)
            {
                Assert.Equal(1, item);
            }
        }

        [Fact]
        public void AddLast_MultipleElements_ShouldAddCorrectElements()
        {
            var list = new LinkedList<int>();

            for (var i = 0; i < 100; i++)
            {
                list.AddLast(i);
            }

            var expected = 0;
            foreach (var item in list)
            {
                Assert.Equal(expected++, item);
            }
        }

        [Fact]
        public void RemoveFirst_SingleElement_ShouldDecreaseCount()
        {
            var list = new LinkedList<int>();

            list.AddFirst(1);
            list.AddFirst(2);
            list.RemoveFirst();

            Assert.Equal(1, list.Count);
        }

        [Fact]
        public void RemoveFirst_MultipleElements_ShouldRemoveCorrectly()
        {
            var list = new LinkedList<int>();

            for (var i = 0; i < 100; i++)
            {
                list.AddLast(i);
            }

            for (var i = 0; i < 100; i++)
            {
                Assert.Equal(i, list.RemoveFirst());
            }

            Assert.Equal(0, list.Count);
        }

        [Fact]
        public void RemoveFirst_OnEmptyList_ShouldThrow()
        {
            var list = new LinkedList<int>();

            Assert.Throws<InvalidOperationException>(() => list.RemoveFirst());
        }

        [Fact]
        public void RemoveLast_SingleElement_ShouldDecreaseCount()
        {
            var list = new LinkedList<int>();

            list.AddFirst(1);
            list.AddFirst(2);
            list.RemoveLast();

            Assert.Equal(1, list.Count);
        }

        [Fact]
        public void RemoveLast_MultipleElements_ShouldRemoveCorrectly()
        {
            var list = new LinkedList<int>();

            for (var i = 0; i < 100; i++)
            {
                list.AddFirst(i);
            }

            for (var i = 0; i < 100; i++)
            {
                Assert.Equal(i, list.RemoveLast());
            }

            Assert.Equal(0, list.Count);
        }

        [Fact]
        public void RemoveLast_OnEmptyList_ShouldThrow()
        {
            var list = new LinkedList<int>();

            Assert.Throws<InvalidOperationException>(() => list.RemoveLast());
        }
    }
}