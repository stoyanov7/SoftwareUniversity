namespace ArrayList.Test
{
    using System;
    using Xunit;

    public class ArrayListTest
    {
        [Fact]
        public void Add_AddSingleElement_ShouldIncreaseCount()
        {
            // Arrange
            var list = new ArrayList<int>();

            // Act
            list.Add(1);

            // Assert
            Assert.Equal(1, list.Count);
        }

        [Fact]
        public void Add_AddMultipleElements_ShouldIncreaseCount()
        {
            // Arrange
            var list = new ArrayList<int>();

            // Act
            for (int i = 0; i < 100; i++)
            {
                list.Add(i);
            }

            // Assert
            Assert.Equal(100, list.Count);
        }
        
        [Fact]
        public void Get_GetSingleElements_ShouldReturnCorrectElement()
        {
            // Arrange
            var list = new ArrayList<int>();
            const int expected = 7;

            // Act
            list.Add(expected);

            // Assert
            Assert.Equal(expected, list[0]);
        }

        [Fact]
        public void Get_GetMultipleElements_ShouldReturnCorrectElements()
        {
            // Assert
            var list = new ArrayList<int>();

            // Act
            for (var i = 0; i < 100; i++)
            {
                list.Add(i);
            }

            // Assert
            for (var i = 0; i < 100; i++)
            {
                Assert.Equal(i, list[i]);
            }
        }

        [Fact]
        public void Get_InvalidPosition_ShouldThrowException()
        {
            // Assert
            var list = new ArrayList<int>();

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => list[5]);
        }

        [Fact]
        public void Set_SetSingleElement_ShouldChangeCorrect()
        {
            // Arrange
            var list = new ArrayList<int>();

            // Act
            list.Add(0);
            list[0] = 2;

            // Assert
            Assert.Equal(2, list[0]);
        }

        [Fact]
        public void Set_SetMultipleElements_ShouldChangeAllElementsCorrect()
        {
            // Arrange
            var list = new ArrayList<int>();

            // Act
            for (var i = 0; i < 100; i++)
            {
                list.Add(i);
            }

            for (var i = 0; i < list.Count; i++)
            {
                list[i] = i + 1;
            }

            // Assert
            for (var i = 0; i < 100; i++)
            {
                Assert.Equal(i + 1, list[i]);
            }
        }

        [Fact]
        public void Set_InvalidPosition_ShouldThrowException()
        {
            // Arrange
            var list = new ArrayList<int>();

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => list[5] = 2);
        }

        [Fact]
        public void Remove_RemoveSingleElement_ShouldDecreaseCount()
        {
            // Arrange
            var list = new ArrayList<int>();

            // Act
            list.Add(0);
            list.RemoveAt(0);

            // Assert
            Assert.Equal(0, list.Count);
        }

        [Fact]
        public void Remove_RemoveSingleElement_ShouldDecreaseElements()
        {
            // Arrange
            var list = new ArrayList<int>();

            // Act
            list.Add(0);
            list.Add(1);
            list.Add(2);
            list.RemoveAt(0);

            // Assert
            Assert.Equal(1, list[0]);
            Assert.Equal(2, list[1]);
        }

        [Fact]
        public void Remove_RemoveMultipleElements_ShouldRemoveElementsCorrect()
        { 
            // Arrange
            var list = new ArrayList<int>();

            // Act
            for (var i = 0; i < 100; i++)
            {
                list.Add(i);
            }

            for (var i = 0; i < 50; i++)
            {
                list.RemoveAt(0);
            }

            // Assert
            Assert.Equal(50, list.Count);

            for (var i = 0; i < 50; i++)
            {
                Assert.Equal(i + 50, list[i]);
            }
        }
    }
}
