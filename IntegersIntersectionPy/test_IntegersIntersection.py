import unittest
from IntegersIntersection import IntegersIntersection

class IntegersIntersectionTests(unittest.TestCase):
    def test_empty(self):
        self.assertEqual(IntegersIntersection([], []), [])

    def test_no_intersection(self):
        self.assertEqual(IntegersIntersection([2], [1]), [])

    def test_intersection_for_1_1_2_and_1_is_1(self):
        self.assertEqual(IntegersIntersection([1, 1, 2], [1]), [1])

if __name__ == '__main__':
    unittest.main()