type FrameOrThrow = (number | number[]);
export type FrameCollection = FrameOrThrow[];

export function calculateScore(input: FrameCollection): number {
    const game = new BowlingGame3(input);
    return game.calculate();
}

class BowlingGame3 {
    private input: FrameOrThrow[];

    constructor(input: FrameOrThrow[]) {
        this.input = input;
    }

    public calculate(): number {
        const framesCollection = new FramesCollection(this.input);
        return framesCollection.totalScore;
    }

    public print(): string {
        const framesCollection = new FramesCollection(this.input);
        return JSON.stringify(framesCollection);
    }
}

const FullScore = 10;
function isFullScore(score: number): boolean {
    return score === FullScore;
}

function sum(array: number[]): number;
function sum<T>(array: T[], selector: (item: T) => number): number;
function sum<T>(array: T[], selector?: (item: T) => number): number {
    if (!selector) {
        // Case 1: Sum an array of numbers directly
        return (<number[]>array).reduce((acc, curr) => acc + curr, 0);
    } else {
        // Case 2: Sum an array of objects using the selector
        return array.reduce((acc, curr) => acc + selector(curr), 0);
    }
}

class FramesCollection {
    private frames: IFrameOrThrow[] = [];

    constructor(input: FrameOrThrow[]) {
        this.convertToFrames(input);
    }

    public get totalScore(): number {
        return sum(this.frames.filter(f => f instanceof Frame), frame => frame.score);
    }

    private convertToFrames(input: FrameOrThrow[]): void {
        let bonusThrowsBegan = false;
        for (const element of input) {
            if (Array.isArray(element) && element.length === 2) {
                if (bonusThrowsBegan) {
                    throw new Error("Bonus throws should be at the end");
                }
                this.frames.push(new Frame(this, new Throw(element[0]), new Throw(element[1])));
            } else if (typeof element === 'number') {
                bonusThrowsBegan = true;
                this.frames.push(new Throw(element));
            } else {
                throw new Error("Elements should either be int[] with length 2 or int");
            }
        }
    }

    public getNextFrameAfter(frame: IFrameOrThrow): IFrameOrThrow | undefined {
        const index = this.frames.indexOf(frame);
        return this.frames[index + 1];
    }

    public getAfterNextThrow(frame: IFrameOrThrow): Throw | undefined {
        const nextFrame = this.getNextFrameAfter(frame);
        if (nextFrame) {
            return nextFrame.has2Throws ? nextFrame.last : this.getNextFrameAfter(nextFrame)?.first;
        }
        return undefined;
    }

    public getPreviousFrame(frame: Frame): IFrameOrThrow | undefined {
        const index = this.frames.indexOf(frame);
        return this.frames[index - 1];
    }
}

interface IFrameOrThrow {
    score: number;
    has2Throws: boolean;
    last: Throw;
    first: Throw;
    runningTotal: number;
}

class Frame implements IFrameOrThrow {
    private frames: FramesCollection;
    private _first: Throw;
    private _last: Throw;

    constructor(frames: FramesCollection, first: Throw, last: Throw) {
        this.frames = frames;
        this._first = first;
        this._last = last;
    }

    private get normalScore(): number {
        return this.first.score + this.last.score;
    }

    private get bonusScore(): number {
        if (this.isStrike) {
            return (this.nextThrow?.score ?? 0) + (this.afterNextThrow?.score ?? 0);
        } else if (this.isSpare) {
            return this.nextThrow?.score ?? 0;
        }
        return 0;
    }

    public get score(): number {
        return this.normalScore + this.bonusScore;
    }

    private get isSpare(): boolean {
        return !this.first.isFullScore && isFullScore(this.first.score + this.last.score);
    }

    private get isStrike(): boolean {
        return this.first.isFullScore;
    }

    private get nextFrame(): IFrameOrThrow | undefined {
        return this.frames.getNextFrameAfter(this);
    }

    private get nextThrow(): Throw | undefined {
        return this.nextFrame?.first;
    }

    private get afterNextThrow(): Throw | undefined {
        return this.frames.getAfterNextThrow(this);
    }

    public get has2Throws(): boolean {
        return !this.isStrike;
    }

    public get runningTotal(): number {
        const previousFrameScore = this.frames.getPreviousFrame(this)?.runningTotal ?? 0;
        return previousFrameScore + this.score;
    }

    public get first(): Throw {
        return this._first;
    }

    public get last(): Throw {
        return this._last;
    }
}

class Throw implements IFrameOrThrow {
    private pins: number;

    constructor(pins: number) {
        this.pins = pins;
    }

    public get score(): number {
        return this.pins;
    }

    public get isFullScore(): boolean {
        return isFullScore(this.score);
    }

    public get has2Throws(): boolean {
        return false;
    }

    public get last(): this {
        return this;
    }

    public get first(): this {
        return this;
    }

    public get runningTotal(): number {
        return 0;
    }
}
