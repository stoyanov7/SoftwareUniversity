using System.Text;

namespace _04.NumbersInReversedOrder
{
    public class DecimalNumber
    {
        private string Number { get; set; }

        public static decimal ReverseNumber(string s)
        {
            var reverse = new StringBuilder();

            for (int i = s.Length - 1; i >= 0; i--)
            {
                reverse.Append(s[i]);
            }

            return decimal.Parse(reverse.ToString());
        }
    }
}
