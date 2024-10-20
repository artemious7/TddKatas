namespace FizzBuzzPlus;

class StringReverser : IReverser
    {
        public string Reverse(string input) => input.All(char.IsDigit) ?
            input :
            new string(input.Reverse().ToArray());
    }