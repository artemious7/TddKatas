import unittest

from FizzBuzz import FizzBuzzIt

class FizzBuzzTests(unittest.TestCase):
    def test_1_Returns_1(self):
        self.assertEqual('1', FizzBuzzIt(1))

    def test_3_Returns_Fizz(self):
        self.assertEqual('Fizz', FizzBuzzIt(3))

    def test_5_Returns_Fizz(self):
        self.assertEqual('Buzz', FizzBuzzIt(5))

if __name__ == '__main__':
    unittest.main()