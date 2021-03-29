using System;
using System.Linq;
using System.Text;
using LimestoneDigital.NumberMetamorphoses.Contracts;

namespace LimestoneDigital.NumberMetamorphoses
{
    public class ValueTransformer : IValueTransformer
    {
        public string Transform(string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException();
            }

            if (value.Length > 7)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (!int.TryParse(value, out _))
            {
                throw new ArgumentException();
            }

            int[] numbers = value.Union(value)
                .Select(ch => ch - '0')
                .OrderBy(c => c).ToArray();

            StringBuilder builder = new StringBuilder();
            bool isNext = false;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (i != numbers.Length - 1)
                {
                    if ((numbers[i + 1] - numbers[i]) != 1)
                    {
                        builder.Append($"{numbers[i]}, ");
                        isNext = false;
                    }
                    else if (!isNext)
                    {
                        builder.Append($"{numbers[i]}-");
                        isNext = true;
                    }
                }
                else
                {
                    builder.Append(numbers[i]);
                }
            }

            return builder.ToString();
        }
    }
}
