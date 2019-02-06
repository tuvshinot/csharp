namespace OOP_2
{
    public class WorkingWithArray
    {
        private readonly int[] numbers;
        private int numberOf0;

        public int NumberOf0
        {
            get { return numberOf0; }
        }

        public WorkingWithArray(int[] numbers)
        {
            this.numbers = numbers;
        }

        public int NumberOdd()
        {
            var numberOfOdd = 0;
            numberOf0 = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 2 != 0)
                {
                    numberOfOdd++;
                }
                else if (numbers[i] == 0)
                {
                    numberOf0++;
                }
            }

            return numberOfOdd;
        }

        public int[] Substract()
        {
            var arr = numbers;

            for (int i = 0; i < numbers.Length; i+=2)
            {
                arr[i] = arr[i] * 2;
            }

            return arr;
        }

    }
}
