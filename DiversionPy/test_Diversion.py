import unittest
import Diversion

class DiversionTests(unittest.TestCase):
    def test_0(self):
        self.assertEqual(Diversion.answer(0), 1)

    def test_1(self):
        self.assertEqual(Diversion.answer(1), 2)

    def test_2(self):
        self.assertEqual(Diversion.answer(2), 3)

if __name__ == '__main__':
    unittest.main()
