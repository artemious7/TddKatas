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
    output = []
    for x in range(number):
        output += [FizzBuzzIt(x + 1)]
    return output