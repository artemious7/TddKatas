import unittest
import Diversion


class DiversionTests(unittest.TestCase):
    def execute_test(self, input: int, expected: int):
        self.assertEqual(Diversion.naive_approach(input), expected)
        self.assertEqual(Diversion.proof_step1(input), expected)
        self.assertEqual(Diversion.proof_step2(input), expected)
        self.assertEqual(Diversion.proof_step3(input), expected)
        self.assertEqual(Diversion.proof_step4(input), expected)
        self.assertEqual(Diversion.proof_step5(input), expected)
        self.assertEqual(Diversion.fibonacci(input), expected)

    def test_0(self):
        self.execute_test(0, 1)

    def test_1(self):
        self.execute_test(1, 2)

    def test_2(self):
        self.execute_test(2, 3)

    def test_3(self):
        self.execute_test(3, 5)

    def test_4(self):
        self.execute_test(4, 8)

    def test_10(self):
        self.execute_test(10, 144)


if __name__ == "__main__":
    unittest.main()
