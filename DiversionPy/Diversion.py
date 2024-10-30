def answer(sequenceLength: int):

    def permutations():
        if sequenceLength == 0:
            return ['']
        if sequenceLength == 1:
            return [format(0, "b"), format(1, "b")]

    return len(permutations())