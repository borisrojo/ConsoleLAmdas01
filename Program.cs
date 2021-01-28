using System;
using System.Linq;

namespace ConsoleLAmdas01
{
    class Program
    {
        //https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/lambda-expressions

        static void Main(string[] args)
        {

            //Lambda expressions (C# reference)**********************************************


            Func<int, int> square = x => x * x;
            Console.WriteLine("square " + square(5)  );

            //Expression lambdas can also be converted to the expression tree types, as the 
            //following example shows:
            System.Linq.Expressions.Expression<Func<int, int>> e = x => x * x;
            Console.WriteLine(e);
            // Output:
            // x => (x * x)

            //You can also use lambda expressions when you write LINQ in C#
            int[] numbers = { 2, 3, 4, 5 };
            var squaredNumbers = numbers.Select(x => x * x);
            Console.WriteLine(string.Join(" ", squaredNumbers));
            // Output:
            // 4 9 16 25


            //Statement lambdas***********************************************************

            //A statement lambda resembles an expression lambda except that its statements are 
            //enclosed in braces
            Action<string> greet = name =>
            {
                string greeting = $"Hello {name}!";
                Console.WriteLine(greeting);
            };
            greet("World 02");
            // Output:
            // Hello World!



            //Input parameters of a lambda expression ********************************

            //You enclose input parameters of a lambda expression in parentheses.Specify zero input parameters 
            //with empty parentheses:
            Action line = () => Console.WriteLine("Galletita 03");
            line();

            Func<double, double> cube = x => x * x * x;
            Console.WriteLine("cube " + cube(5));

            //Two or more input parameters are separated by commas:
            Func<int, int, bool> testForEquality = (x, y) => x == y;
            Console.WriteLine("testForEquality 1 " + testForEquality(5,5));
            Console.WriteLine("testForEquality 2 " + testForEquality(5, 6));

            //Sometimes the compiler can't infer the types of input parameters. 
            //You can specify the types explicitly as shown in the following example:
            Func<int, string, bool> isTooLong = (int x, string s) => s.Length > x;
            Console.WriteLine("isTooLong 1 " + isTooLong(10, "String de prueba"));
            Console.WriteLine("isTooLong 2 " + isTooLong(10, "String 2"));

            //No jalo es para C# 9.0
            //Func<int, int, int> constante = (_, _) => 42;
            //Console.WriteLine("constante " + constante(10, 11));

            //Async lambdas
            //You can easily create lambda expressions and statements that incorporate 
            //asynchronous processing by using the async and await keywords

            /*
             * the following Windows Forms example contains an event handler that calls 
             * and awaits an async method, ExampleMethodAsync
             * 
public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
        button1.Click += button1_Click;
    }

    private async void button1_Click(object sender, EventArgs e)
    {
        await ExampleMethodAsync();
        textBox1.Text += "\r\nControl returned to Click event handler.\n";
    }

    private async Task ExampleMethodAsync()
    {
        // The following line simulates a task-returning asynchronous process.
        await Task.Delay(1000);
    }
}

*/

            //You can add the same event handler by using an async lambda. 
            //To add this handler, add an async modifier before the lambda parameter list

            /*
public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
        button1.Click += async (sender, e) =>
        {
            await ExampleMethodAsync();
            textBox1.Text += "\r\nControl returned to Click event handler.\n";
        };
    }

    private async Task ExampleMethodAsync()
    {
        // The following line simulates a task-returning asynchronous process.
        await Task.Delay(1000);
    }
}
* */


            //Lambda expressions and tuples

            //You define a tuple by enclosing a comma-delimited list of its components in parentheses. 
            //The following example uses tuple with three components to pass a sequence of numbers to a 
            //lambda expression, which doubles each value and returns a tuple with three components that 
            //contains the result of the multiplications

            Func<(int, int, int), (int, int, int)> doubleThem = ns => (2 * ns.Item1, 2 * ns.Item2, 2 * ns.Item3);
            var numbers01 = (2, 3, 4);
            var doubledNumbers = doubleThem(numbers01);
            Console.WriteLine($"The set {numbers01} doubled: {doubledNumbers}");
            // Output:
            // The set (2, 3, 4) doubled: (4, 6, 8)


            //You can, however, define a tuple with named components
            Func<(int n1, int n2, int n3), (int, int, int)> doubleThem02 = ns => (2 * ns.n1, 2 * ns.n2, 2 * ns.n3);
            var numbers02 = (2, 3, 4);
            var doubledNumbers02 = doubleThem(numbers02);
            Console.WriteLine($"The set {numbers02} doubled: {doubledNumbers02}");



            Console.WriteLine("LambdaFactorial " + LambdaFactorial(5));
        }


        public static int LambdaFactorial(int n)
        {
            Func<int, int> nthFactorial = default(Func<int, int>);

            nthFactorial = number => number < 2
                ? 1
                : number * nthFactorial(number - 1);

            return nthFactorial(n);
        }

    }
}
