import unittest
from HelloWorld import HelloWorld

class HelloWorldTest(unittest.TestCase):
    def test_HelloWorld(self):
        self.assertEqual("Hello world", HelloWorld.SayHelloWorld())

if __name__ == '__main__':
    unittest.main()