# The Bowling Score
Implement the code for a Bowling Score system that calculates the score of a bowling game.

In a game of bowling, you get ten rounds to knock back 10 pins with a bowling ball. In each round, called a
frame, you have two tries. If you knock them over on the first try, it's called a strike, if you do it in two it's
called a spare. At the end of the 10 frames the player with the most points wins.

Points are calculated based on a frame result:
- If it's not a strike or a spare the sum of the throws is calculated.
- For a spare, you get the next throw added as a bonus.
- For a strike, you get the next two throws added as a bonus.
- If you have a spare or a strike in the last frame you get one or two throws as a bonus respectively.

const perfectScoreInput = [
   [10, 0], [10, 0], [10, 0], [10, 0], [10, 0], [10, 0], [10, 0], [10, 0], [10, 0], [10, 0], 10, 10
]; // output = 300

const normalThrows = [
   [5, 3], [8, 2], [10, 0], [10, 0], [1, 0], [9, 1], [0, 10],[ 10, 0], [6, 4], [7, 3], 10,
]; // output = 148
