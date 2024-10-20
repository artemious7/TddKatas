namespace FizzBuzzPlus.Implementation;

class FizzBuzzer : IFizzBuzzer
{
    public string FizzBuzzIt(int number) =>
        number % 15 == 0 ? "fizz buzz" :
        number % 5 == 0 ? "buzz" :
        number % 3 == 0 ? "fizz" :
        number.ToString();
}
