def FizzBuzzIt(input: int):
    output: str = ''

    if input % 3 == 0:
        output += 'Fizz'

    if input % 5 == 0:
        output += 'Buzz'

    if not output:
        output = str(input)

    return output

def FizzBuzz100(number: int):
    if number == 1:
        return [FizzBuzzIt(number)]
    if number == 2:
        return [FizzBuzzIt(1), FizzBuzzIt(2)]
    return []