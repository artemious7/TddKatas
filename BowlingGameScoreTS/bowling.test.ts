import { calculateScore as calculateScore1, FrameCollection } from './bowling';
import { calculateScore2 } from './bowling2';
import { calculateScore as calculateScore3 } from './bowling3';

const perfectScoreInput: FrameCollection = [
    [10, 0], [10, 0], [10, 0], [10, 0], [10, 0], [10, 0], [10, 0], [10, 0], [10, 0],
    [10, 0], 10, 10
]; // output = 300

const perfectScoreInput2: FrameCollection = [
    [10, 0], [10, 0], [10, 0], [10, 0], [10, 0], [10, 0], [10, 0], [10, 0], [10, 0],
    [10, 0], 1, 4
]; // output = 276

const normalThrowsBonus: FrameCollection = [
    [5, 3], [8, 2], [10, 0], [10, 0], [1, 0], [9, 1], [0, 10], [10, 0], [6, 4],
    [7, 3], 10
]; // output = 148

const normalThrows: FrameCollection = [
    [5, 3], [8, 2], [10, 0], [10, 0], [1, 0], [9, 1], [0, 10], [10, 0], [6, 4],
    [7, 2]
]; // output = 137

const inputs: ([FrameCollection, number, string])[] = [
    [[[1, 2]], 3, "normal frame"],
    [[[1, 2], [3, 4]], 1 + 2 + 3 + 4, "2 frames"],
    [[[1, 9], [3, 4]], 1 + 9 + 3 * 2 + 4, "spare frame adds next throw as bonus"],
    [[[1, 9], [2, 8], 0], 1 + 9 + 2 * 2 + 8, "2 spare frame"],
    [[[1, 9], [2, 8], 3], 1 + 9 + 2 * 2 + 8 + 3, "2 spare frame with bonus throw"],
    [[[10, 0], [1, 2]], 10 + (1 + 2) * 2, "strike frame adds next 2 throws as bonus"],
    [[[10, 0], [10, 0], 0, 0], 10 + 10 * 2, "2 strike frames without bonus throws"],
    [[[10, 0], [10, 0], 1, 2], (10 + 10 + 1) + (10 + 1 + 2), "2 strike frames with bonus throws"],
    [[[10, 0], [10, 0], 10, 10], (10 + 10 + 10) + (10 + 10 + 10), "perfect 2 frames with strikes bonuses"],
    [[[10, 0], [10, 0], [10, 0], 1, 9], (10 + 10 + 10) + (10 + 10 + 1) + (10 + 1 + 9), "perfect 2 frames with strikes bonuses"],
    [perfectScoreInput2, 276, "perfectScoreInput2"],
    [perfectScoreInput, 300, "perfectScoreInput"],
    [normalThrowsBonus, 148, "normalThrowsBonus"],
    [normalThrows, 137, "normalThrows"],
];

for (const each of inputs) {
    const input = each[0];
    const numberOfFrames = input.filter(value => Array.isArray(value)).length;
    const framesToAdd = 10 - numberOfFrames;
    for (let i = 0; i < framesToAdd; i++) {
        input.unshift([0, 0]);
    }
}

//describe('bowling1', () => {
//    test.each(inputs)('calculateScore1(%o) should equal %d, name: %s', (input, expected, name) => {
//        expect(calculateScore1(input)).toBe(expected);
//    });
//});

//describe('bowling2', () => {
//    test.each(inputs)('calculateScore2(%o) should equal %d, name: %s', (input, expected, name) => {
//        expect(calculateScore2(input)).toBe(expected);
//    });
//});

describe('bowling3', () => {
    test.each(inputs)('calculateScore3(%o) should equal %d, name: %s', (input, expected, name) => {
        expect(calculateScore3(input)).toBe(expected);
    });
});