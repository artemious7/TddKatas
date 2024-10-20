type Frame = number[];
type Strike = [10, 0] & Frame;
export type FrameOrRoll = number | Frame;
export type FrameCollection = FrameOrRoll[];

export function calculateScore2(input: FrameCollection): number {
    const rolls = [];
    for (const frameOrRoll of input) {
        if (Array.isArray(frameOrRoll)) {
            if (frameOrRoll[0] === 10) {
                rolls.push(10);
            }
            else {
                rolls.push(frameOrRoll[0], frameOrRoll[1]);
            }
        }
        else {
            rolls.push(frameOrRoll);
        }
    }

    let rollIndex = 0;
    let score = 0;
    for (let frame = 0; frame < 10; frame++) {
        const isStrike = rolls[rollIndex] === 10;
        const isSpare = !isStrike && rolls[rollIndex] + rolls[rollIndex + 1] === 10;
        if (isStrike) {
            score += 10 + rolls[rollIndex + 1] + rolls[rollIndex + 2];
            rollIndex++;
        }
        else if (isSpare) {
            score += 10 + rolls[rollIndex + 2];
            rollIndex += 2;
        }
        else {
            score += rolls[rollIndex] + rolls[rollIndex + 1];
            rollIndex += 2;
        }
    }

    return score;
}
