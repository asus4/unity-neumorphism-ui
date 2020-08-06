#!/bin/bash -e

# Convert all svg files into png
for f in *.svg
do
    ./msdfgen mtsdf -svg $f -o "${f%.svg}.png" -autoframe -size 128 128 -pxrange 24
    echo "${f%.svg}.png..."
done
