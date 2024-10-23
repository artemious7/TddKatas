import unittest

from FizzBuzz import FizzBuzz100, FizzBuzzIt

class FizzBuzzTests(unittest.TestCase):
    def test_1_Returns_1(self):
        self.assertEqual('1', FizzBuzzIt(1))

    def test_3_Returns_Fizz(self):
        self.assertEqual('Fizz', FizzBuzzIt(3))

    def test_5_Returns_Buzz(self):
        self.assertEqual('Buzz', FizzBuzzIt(5))

    def test_15_Returns_FizzBuzz(self):
        self.assertEqual('FizzBuzz', FizzBuzzIt(15))

    def test_6_Returns_Fizz(self):
        self.assertEqual('Fizz', FizzBuzzIt(6))

    def test_10_Returns_Buzz(self):
        self.assertEqual('Buzz', FizzBuzzIt(10))

    def test_30_Returns_FizzBuzz(self):
        self.assertEqual('FizzBuzz', FizzBuzzIt(30))

class FizzBuzz100Tests(unittest.TestCase):
    def test_0_elements(self):
        self.assertEqual([], FizzBuzz100(0));
    def test_1_element(self):
        self.assertEqual(['1'], FizzBuzz100(1));
    def test_2_elements(self):
        self.assertEqual(['1', '2'], FizzBuzz100(2));
    def test_3_elements(self):
        self.assertEqual(['1', '2', 'Fizz'], FizzBuzz100(3));
    def test_10_elements(self):
        self.assertEqual(['1', '2', 'Fizz', '4', 'Buzz', 'Fizz', '7', '8', 'Fizz', 'Buzz'], FizzBuzz100(10));

if __name__ == '__main__':
    unittest.main()