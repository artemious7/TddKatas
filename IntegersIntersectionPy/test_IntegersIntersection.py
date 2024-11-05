import unittest
from IntegersIntersection import DoublyNestedLoop, UseSetForResults

class IntegersIntersectionTests(unittest.TestCase):
    def assertAllMethods(self, a: list, b: list, expected: list):
        self.assertEqual(DoublyNestedLoop(a, b), expected)
        self.assertEqual(UseSetForResults(a, b), expected)

    def test_empty(self):
        self.assertAllMethods([], [], [])
        self.assertAllMethods([], [], [])

    def test_no_intersection(self):
        self.assertAllMethods([2], [1], [])

    def test_intersection_for_1_1_2_and_1_is_1(self):
        self.assertAllMethods([1, 1, 2], [1], [1])

if __name__ == '__main__':
    unittest.main()