#!/bin/bash

# Path to the test results XML file
RESULTS_FILE="testresults.xml"
RESULTS_PATH="./TestResults/$RESULTS_FILE"

# Run dotnet test and output results to the specified file
dotnet test --logger "trx;LogFileName=$RESULTS_FILE"

# Check if the test results file was created
if [[ ! -f "$RESULTS_PATH" ]]; then
    echo "Test results file not found: $RESULTS_PATH"
    exit 1
fi

# get value of failed attribute. TODO specify path better (or at all)
FAILED_COUNT=$(xmlstarlet sel  -t -v '//@failed' "$RESULTS_PATH")

# Check if the FAILED_COUNT is numeric and if the value is equal to "0"
if [[ "$FAILED_COUNT" =~ ^[0-9]+$ ]] && [[ "$FAILED_COUNT" == "0" ]]; then
    echo "All tests passed."
    exit 0
else
    if [[ "$FAILED_COUNT" =~ ^[0-9]+$ ]]; then
        echo "There are $FAILED_COUNT failed tests."
    else
        echo "Failed to retrieve the test results correctly."
    fi
    exit 1
fi
