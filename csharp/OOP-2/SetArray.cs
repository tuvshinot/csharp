using System;

namespace OOP_2
{
    public class SetArray
    {
        // initialize only once
        private readonly int start;
        private readonly int stop;
        private readonly int count;
        private int[] numbers;

        // property of number of 0
        public int NumberOf0
        {
            get
            {
                var numberOf0 = 0;
                for (int i = 0; i < numbers.Length; i++)
                {
                    if (numbers[i] == 0)
                    {
                        numberOf0++;
                    }
                }
                return numberOf0;
            }
        }

        public int[] Numbers => numbers;

        public SetArray()
        {
            start = -2;
            stop = 2;
            count = 5;
            SetArrayElements();
        }

        public SetArray(int count)
        {
            start = -2;
            stop = 2;
            this.count = count;
            SetArrayElements();
        }

        public SetArray(int start, int stop, int count)
        {
            this.start = start;
            this.stop = stop;
            this.count = count;
            SetArrayElements();
        }

        private void SetArrayElements()
        {
            numbers = new int[count];

            // set elements from start to stop
            var random = new Random();
            for (var i = 0; i < count; i++)
            {
                var num = random.Next(start, stop);
                numbers[i] = num;
            }
        }

        public int NumberOdd()
        {
            var numberOfOdd = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 2 != 0)
                {
                    numberOfOdd++;
                }
            }
            return numberOfOdd;
        }

        public int[] Substract()
        {
            var arr = numbers;

            for (int i = 0; i < numbers.Length; i += 2)
            {
                arr[i] = arr[i] * 2;
            }

            return arr;
        }


    }
}
