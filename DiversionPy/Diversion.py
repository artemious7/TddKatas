def answer(sequenceLength: int):

    def permutations():
        if sequenceLength == 0:
            return ['']
        if sequenceLength == 1:
            return [format(0, "b"), format(1, "b")]
        if sequenceLength == 2:
            return [format(0, "b"), format(1, "b"), format(2, "b"), format(3, "b")]

    return len([permutation for permutation in permutations() if '11' not in permutation])