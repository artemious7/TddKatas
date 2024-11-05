import unittest
from IntegersIntersection import IntegersIntersection

class IntegersIntersectionTests(unittest.TestCase):
    def test_empty(self):
        self.assertEqual(IntegersIntersection([], []), [])

if __name__ == '__main__':
    unittest.main()