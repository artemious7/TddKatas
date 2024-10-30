import unittest
import Diversion

class DiversionTests(unittest.TestCase):
    def test_0(self):
        self.assertEqual(Diversion.Answer(0), 1)

if __name__ == '__main__':
    unittest.main()
