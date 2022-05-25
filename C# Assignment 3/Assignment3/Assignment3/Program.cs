using Assignment3;

//Reverse Array
/*
int[] numbers = GenerateNumbers();
PrintNumbers(numbers);
Reverse(ref numbers);
PrintNumbers(numbers);

int[] GenerateNumbers(int length = 10)
{
    int[] numbers = new int[length];

    for (int i = 0; i < length; i++)
        numbers[i] = i;

    return numbers;
}

void PrintNumbers(int[] numbers)
{
    string str = "";
    foreach (int number in numbers)
        str += number + " ";

    Console.WriteLine(str);
}

void Reverse(ref int[] numbers)
{
    int[] temp = new int[numbers.Length];

    for (int i = 0; i < numbers.Length; i++)
        temp[i] = numbers[numbers.Length - 1 - i];

    numbers = temp;
}
*/


//Fibonacci
/*
Fibonacci(8);

void Fibonacci(int len)
{
    FibonacciRec(1, 1, 1, len); 
}

void FibonacciRec(int a, int b, int counter, int len)
{
    Console.Write(a + " ");

    if (counter < len)
    {
        FibonacciRec(b, a + b, counter + 1, len);
    }
}
*/

// Color Balls
/*
Ball ball1 = new Ball(new Color(50, 50, 50));
Ball ball2 = new Ball(new Color(20, 60, 40, 75), 3);
Ball ball3 = new Ball(new Color(0, 0, 0, 0));

ball1.Pop();
ball1.Throw();
ball2.Pop();
ball3.Throw();
ball2.Throw();
ball3.Pop();
ball3.Throw();

Console.WriteLine($"Thrown - ball1:{ball1.GetThrown()}, ball2:{ball2.GetThrown()}, ball3:{ball3.GetThrown()}");
*/