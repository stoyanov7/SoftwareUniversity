namespace Froggy
{
    using System.Collections;
    using System.Collections.Generic;

    public class Lake : IEnumerable<int>
    {
        private readonly IList<int> stonesNumber;

        public Lake(IList<int> stonesNumber) => this.stonesNumber = stonesNumber;

        public IEnumerator<int> GetEnumerator()
        {
            for (var i = 0; i < this.stonesNumber.Count; i+= 2)
            {
                yield return this.stonesNumber[i];
            }

            var len = this.stonesNumber.Count;
            var test = len % 2 != 0 ? len - 2 : len - 1;

            for (var i = test; i >= 0; i-= 2)
            {
                yield return this.stonesNumber[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}