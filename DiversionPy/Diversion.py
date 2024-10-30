def naive_approach(sequenceLength: int):

    def all_permutations():
        if sequenceLength == 0:
            return [""]
        return [format(x, "b") for x in range(2**sequenceLength)]

    return len(
        [permutation for permutation in all_permutations() if "11" not in permutation]
    )


def proof_step1(sequenceLength: int):

    def permutations(sequenceLength: int):
        if sequenceLength == 0:
            return [""]
        if sequenceLength == 1:
            return ["0", "1"]

        return [("0" + x) for x in permutations(sequenceLength - 1)] + [
            ("1" + x) for x in permutations(sequenceLength - 1) if x[0] != "1"
        ]

    return len(permutations(sequenceLength))


def proof_step2(sequenceLength: int):

    def permutations(sequenceLength: int):
        if sequenceLength == 0:
            return [""]
        if sequenceLength == 1:
            return ["0", "1"]

        return [("0" + x) for x in permutations(sequenceLength - 1)] + [
            ("1" + x) for x in permutations(sequenceLength - 2)
        ]

    return len(permutations(sequenceLength))


def proof_step3(sequenceLength: int):

    def permutations(sequenceLength: int):
        if sequenceLength == 0:
            return [""]
        if sequenceLength == 1:
            return ["0", "1"]

        return permutations(sequenceLength - 1) + permutations(sequenceLength - 2)

    return len(permutations(sequenceLength))


def proof_step4(sequenceLength: int):

    def permutations_count(sequenceLength: int):
        if sequenceLength == 0:
            return len([""])
        if sequenceLength == 1:
            return len(["0", "1"])

        return permutations_count(sequenceLength - 1) + permutations_count(
            sequenceLength - 2
        )

    return permutations_count(sequenceLength)


def proof_step5(sequenceLength: int):

    def permutations_count(sequenceLength: int):
        if sequenceLength <= 0:
            return 1

        return permutations_count(sequenceLength - 1) + permutations_count(
            sequenceLength - 2
        )

    return permutations_count(sequenceLength)


def fibonacci(n: int):
    if n <= 0:
        return 1

    return fibonacci(n - 1) + fibonacci(n - 2)


def fibonacci_fast(n: int):
    if n <= 0:
        return 1
    a, b = 0, 1
    for _ in range(n + 1):
        a, b = b, a + b
    return b
