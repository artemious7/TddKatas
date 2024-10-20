type Frame = number[];
type Strike = [10, 0] & Frame;
export type FrameOrThrow = number | Frame;
export type FrameCollection = FrameOrThrow[];

export function calculateScore(input: FrameCollection): number {
    let score = 0;
    const nextThrowsMultipliers: number[] = [1, 1];

    for (let i = 0; i < input.length; i++) {
        const frameOrThrow = input[i];

        // frame
        if (isFrame(frameOrThrow)) {
            const frameSum = frameOrThrow[0] * nextThrowsMultipliers[0] + frameOrThrow[1] * nextThrowsMultipliers[1];
            score += frameSum;

            // set bonuses
            if (isStrike(frameOrThrow)) {
                nextThrowsMultipliers[0]++;
                nextThrowsMultipliers[1]++;
            }
            else if (isSpare(frameOrThrow)) {
                nextThrowsMultipliers[0]++;
            }
        }
        else {
            score += frameOrThrow * nextThrowsMultipliers[0];
        }

        function isSpare(frame: Frame) {
            return frame[0] + frame[1] === 10 && frame[0] !== 10;
        }

        function isStrike(frame: Frame): frame is Strike {
            return frame[0] === 10 && frame[1] == 0;
        }

        function isFrame(frameOrThrow: FrameOrThrow): frameOrThrow is Frame {
            return Array.isArray(frameOrThrow) && frameOrThrow.length === 2;
        }
    }
    return score;
}
