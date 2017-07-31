namespace _04.RandomList
{
    using System;
    using System.Collections;

    public class RandomList : ArrayList
    {
        private Random random;

        public RandomList() => this.random = new Random();

        public string RandomString() => "";
    }
}