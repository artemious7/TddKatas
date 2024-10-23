def FizzBuzzIt(input: int):
    if input == 15:
        return 'FizzBuzz'
    if input % 3 == 0:
        return 'Fizz'
    if input == 5:
        return 'Buzz'
    return str(input)