import unittest

from FizzBuzzPythonStyle import FizzBuzzPythonStyle


class FizzBuzzPythonStyleTests(unittest.TestCase):
    def test_0_elements(self):
        self.assertEqual([], FizzBuzzPythonStyle(0))

    def test_1_element(self):
        self.assertEqual(["1"], FizzBuzzPythonStyle(1))

    def test_2_elements(self):
        self.assertEqual(["1", "2"], FizzBuzzPythonStyle(2))

    def test_3_elements(self):
        self.assertEqual(["1", "2", "Fizz"], FizzBuzzPythonStyle(3))

    def test_5_elements(self):
        self.assertEqual(["1", "2", "Fizz", "4", "Buzz"], FizzBuzzPythonStyle(5))

    def test_10_elements(self):
        self.assertEqual(
            ["1", "2", "Fizz", "4", "Buzz", "Fizz", "7", "8", "Fizz", "Buzz"],
            FizzBuzzPythonStyle(10),
        )

    def test_15_elements(self):
        self.assertEqual(
            [
                "1",
                "2",
                "Fizz",
                "4",
                "Buzz",
                "Fizz",
                "7",
                "8",
                "Fizz",
                "Buzz",
                "11",
                "Fizz",
                "13",
                "14",
                "FizzBuzz",
            ],
            FizzBuzzPythonStyle(15),
        )


if __name__ == "__main__":
    unittest.main()