/**
 * Advent of Code
 * Day 5
 * 
 * @author Ted Senft (@robotgryphon)
 * @namespace advent_of_code
 * 
 */

import * as fs from 'fs-extra';
import {resolve} from 'path';

let part = 1;
let debug = { showSteps: false };

console.clear();
console.log(`Starting Day 5, part ${part}.`);

async function begin(part: number) {
    
    let inputs: Array<number> = processInput(await fs.readFile(resolve(__dirname, "..", "input.txt")));
    
    // let inputs = [0, 3, 0, 1, -3];

    console.log(`Recieved ${inputs.length} instructions in set.`);

    doDay(inputs);
}

function processInput(file: Buffer) : Array<number> {
    let data: String = file.toString("UTF-8");
    return data.split("\n").map(x => parseInt(x));
}

function doDay(inputs: Array<number>) {
    var currentStepIndex: number = 0;
    var numSteps: number = 0;
    let endStepIndex: number = inputs.length - 1;

    // While still inside maze
    while(currentStepIndex <= endStepIndex) {
        // Fetch current step amount
        let currentStepAmount = inputs[currentStepIndex];
        
        if(debug.showSteps) 
            console.log(`At input ${currentStepIndex}, moving by ${currentStepAmount}.`);

        // Increment for next visit, increment number steps taken
        var offset;
        if(part == 2) {
            if(currentStepAmount >= 3) offset = -1;
            else offset = 1;
        } else {
            offset = 1;
        }
        
        inputs[currentStepIndex] += offset;
        numSteps++;

        // Move by step amount
        currentStepIndex += currentStepAmount;
    }

    console.log(`Reached end in ${numSteps} steps.`);
}

begin(2);