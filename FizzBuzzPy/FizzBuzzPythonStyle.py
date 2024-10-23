def FizzBuzzPythonStyle(number: int):
    output = [str(x) for x in range(1, number + 1)]
    for x, word in [(3, "Fizz"), (5, "Buzz"), (15, "FizzBuzz")]:
        output[x - 1 :: x] = [word] * (number // x)
    return output
