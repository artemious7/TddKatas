
import unittest

from FizzBuzz import FizzBuzzIt

class FizzBuzzTests(unittest.TestCase):
    def test_1_Returns_1(self):
        self.assertEqual('1', FizzBuzzIt('1'))

if __name__ == '__main__':
    unittest.main()