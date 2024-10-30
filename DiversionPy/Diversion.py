def answer(sequenceLength: int):

    def permutations():
        if sequenceLength == 0:
            return ['']
        return [format(x, 'b') for x in range(2 ** sequenceLength)]

    return len([permutation for permutation in permutations() if '11' not in permutation])