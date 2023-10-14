namespace PrimeNumber
{
    public class GreatNumbers
    {
        public string PlusOne(string num)
        {
            int[] input = ToArr(num);

            int[] result;
            int length;
            int flag = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == 9)
                    flag++;
            }
            if (flag == input.Length)
            {
                length = input.Length + 1;

            }
            else
                length = input.Length;
            result = new int[length];

            //filling a with 0
            int[] a = new int[length];
            int k = input.Length - 1;
            for (int i = a.Length - 1; i >= 0; i--, k--)
            {
                a[i] = 0;
                if (k >= 0)
                    a[i] = input[k];
            }
            //filling one arr
            int[] one = new int[length];
            one[one.Length - 1] = 1;
            for (int i = one.Length - 2; i >= 0; i--)
            {
                one[i] = 0;
            }
            //filling result with 0
            int j = input.Length - 1;
            for (int i = result.Length - 1; i >= 0; i--, j--)
            {
                result[i] = 0;
            }

            //tasks
            for (int i = result.Length - 1; i >= 0; i--)
            {

                int t = a[i] + one[i];

                if (t < 10)
                {
                    result[i] += (a[i] + one[i]);
                }
                else if (t >= 10)
                {


                    int counter = i - 1;
                    int m = i - 1;
                    while (true)
                    {
                        if (a[m] != 9)
                        {
                            a[m] += 1;
                            break;
                        }
                        else if (a[m] == 9 && m >= 0)
                        {
                            counter--;
                            m--;
                        }
                    }
                    counter++;
                    while (counter <= i)
                    {
                        a[counter] = 0;
                        counter++;
                    }
                    result[i] = t - 10;
                }
            }



            return ToStr(result);
        }
        public string Subtract(string bigNum, string shortNum)
        {
            int[] biggerNumber = ToArr(bigNum);
            int[] shorterNumber = ToArr(shortNum);


            int length = biggerNumber.Length + 1;
            //filling smallNumber with 0
            int[] smallNumber = new int[length];
            int j = shorterNumber.Length - 1;
            for (int i = length - 1; i >= 0; i--)
            {

                if (j >= 0)
                {
                    smallNumber[i] = shorterNumber[j];
                    j--;
                }
                else if (i <= shorterNumber.Length - 1)
                {
                    smallNumber[i] = 0;
                }
            }

            //filling biggerNumber with 0
            int[] longerNumber = new int[length];
            int l = biggerNumber.Length - 1;
            for (int i = length - 1; i >= 0; i--)
            {

                if (l >= 0)
                {
                    longerNumber[i] = biggerNumber[l];
                    l--;
                }
                else if (i <= biggerNumber.Length - 1)
                {
                    longerNumber[i] = 0;
                }
            }

            //filling result with 0
            int[] result = new int[length];
            for (int i = length - 1; i >= 0; i--)
            {
                result[i] = 0;
            }
            //filling result with final numbers
            int temp;
            for (int i = length - 1; i >= 0; i--)
            {
                temp = longerNumber[i] - smallNumber[i];
                if (temp >= 0)
                {
                    result[i] = temp;
                }
                else
                {
                    int k = i - 1;
                    int counter = i - 1;
                    while (true)
                    {
                        if (longerNumber[k] != 0)
                        {
                            longerNumber[k] -= 1;
                            break;
                        }
                        else if (longerNumber[k] == 0 && k >= 0)
                        {
                            counter--;
                            k--;
                        }
                    }

                    counter++;
                    while (counter <= i)
                    {
                        longerNumber[counter] = 9;
                        counter++;
                    }
                    result[i] = temp + 10;
                }
            }

            return ToStr(result);
        }
        public bool IsBigger(string in1, string in2)
        {
            int[] input1 = ToArr(in1);
            int[] input2 = ToArr(in2);

            bool result = false;

            int length;
            if (input1.Length < input2.Length)
                length = input2.Length;
            else
                length = input1.Length;
            //filling a
            int[] a = new int[length];
            int j = input1.Length - 1;
            for (int i = length - 1; i >= 0; i--)
            {

                if (j >= 0)
                {
                    a[i] = input1[j];
                    j--;
                }
                else if (i <= input1.Length - 1)
                {
                    a[i] = 0;
                }
            }

            //filling b
            int[] b = new int[length];
            int k = input2.Length - 1;
            for (int i = length - 1; i >= 0; i--)
            {

                if (k >= 0)
                {
                    b[i] = input2[k];
                    k--;
                }
                else if (i <= input2.Length - 1)
                {
                    b[i] = 0;
                }
            }

            //tasks
            int flag = 0;
            for (int i = 0; i < length; i++)
            {
                if (a[i] > b[i])
                {
                    result = true;
                    break;
                }
                else if (a[i] < b[i])
                {
                    result = false;
                    break;
                }
                else if (a[i] == b[i])
                {
                    flag++;
                }
            }
            if (flag == length)
                result = true;

            return result;
        }

        public string DivideRemainder(string biggerNumber, string smallerNumber)
        {
            while (IsBigger(biggerNumber, smallerNumber))
            {
                biggerNumber = Subtract(biggerNumber, smallerNumber);
            }
            return biggerNumber;
        }
        public string Dividend(string biggerNumber, string smallerNumber)
        {
            string dividend = "0";
            while (IsBigger(biggerNumber, smallerNumber))
            {
                biggerNumber = Subtract(biggerNumber, smallerNumber);
                dividend = PlusOne(dividend);
            }
            return dividend;
        }
        public bool IsZero(string a)
        {
            int[] input = ToArr(a);
            int flag = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == 0)
                {
                    flag++;
                }
            }

            if (flag == input.Length)
                return true;
            return false;
        }

        public int[] ToArr(string str)
        {
            //convert str to arr
            int[] a = new int[str.Length];
            for (int i = 0; i < str.Length; i++)
            {
                a[i] = int.Parse(str[i].ToString());
            }
            return a;
        }
        public string ToStr(int[] input)
        {
            //convert arr to str
            string a = "";
            for (int i = 0; i < input.Length; i++)
            {
                a += input[i];
            }
            return a;
        }
    }
}
