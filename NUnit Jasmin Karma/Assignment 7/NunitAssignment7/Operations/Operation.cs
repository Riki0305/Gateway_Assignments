using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Operations
{
    public class Operation
    {
        public int Add10ToNumber(int num)
        {
            int i = 0;
            while(i<10)
            {
                num++;
                i++;
            }
            return num;
        }

        public int GetColorCode(string color)
        {
            if (color == null)
            {
                throw new ArgumentNullException();
            }
            switch (color)
            {
                case "red":
                    return 1;
                case "blue":
                    return 2;
                case "green":
                    return 3;
                default:
                    return -1;
            }
        }
        public bool IsEven(int number)
        {
            if (number % 2 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public int Divide(int n, int d)
        {
            if (d != 0)
            {
                return n / d;
            }
            else
            {
                throw new DivideByZeroException();
            }
        }

        public int FindOddNumbers(List<int> numbers)
        {
            int oddCounter = 0;
            foreach (var number in numbers)
            {
                if (number % 2 != 0)
                {
                    oddCounter++;
                }
            }
            return oddCounter;
        }

        public int Subtract10(int number)
        {
            int i = 10;
            for(i=0;i<10;i++)
            {
                number--;
            }
            return number;
        }

        public void NotImplemented()
        {
            throw new NotImplementedException();
        }

        public bool ValidateName(string name)
        {
            if (name == null)
            {
                throw new NullReferenceException();
            }
            else if (name == "Reserved_Word")
            {
                throw new InvalidNameException();
            }
            else
            {
                return true;
            }
        }

        public async Task<int> AddAsync(int x, int y)
        {
            
            await Task.Delay(100).ConfigureAwait(false);
            // the answer to life, the universe and everything.
            return x+y;
        }

    }
}

[Serializable]
public class InvalidNameException : Exception
{
    public InvalidNameException()
    {

    }

    public InvalidNameException(string name) : base(String.Format("Invalid name : {0}", name))
    {

    }

}