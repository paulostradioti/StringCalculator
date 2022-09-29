namespace StringCalculator.Domain
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
                return 0;

            var parts = numbers.Split(',');

            var exceedsCount = parts.Length > 2;
            //var consecutiveCommas = parts.Any(string.IsNullOrWhiteSpace);
            var consecutiveCommas = parts.Any(x => x == "");
            var nonNumbers = parts.Any(x => !int.TryParse(x, out _));

            if (exceedsCount || consecutiveCommas || nonNumbers)
                throw new ArgumentException(nameof(numbers));

            //var sum = parts.Sum(Convert.ToInt32);
            var sum = parts.Sum(x => Convert.ToInt32(x));

            return sum;
        }
    }
}