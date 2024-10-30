def Answer(sequenceLength: int):
    if sequenceLength == 0:
        expectedNumbersWithout2AdjacentOnes = 1
        return expectedNumbersWithout2AdjacentOnes
    if sequenceLength == 1:
        return 2