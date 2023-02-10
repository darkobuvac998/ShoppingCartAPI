#!/bin/bash

BUILD_NUMBER=$1
BUILD_STATUS=$2

echo "<html>"
echo "<head>"
echo "<style>"
echo "table { width:100%; }"
echo "table, th, td { border: 1px solid black; border-collapse: collapse; }"
echo "th, td { padding: 15px; text-align: left; }"
echo "th { background-color: #dddddd; }"
if [ $BUILD_STATUS == "FAILED" ]; then
  echo "h1 { color: red; }"
else
  echo "h1 { color: green; }"
fi
echo "</style>"
echo "</head>"
echo "<body>"
echo "<h1>Build Report #$BUILD_NUMBER</h1>"
echo "<h2>Build Status: $BUILD_STATUS</h2>"
echo "<h3>Build Information</h3>"
echo "<table>"
echo "<tr>"
echo "<th>Build Number</th>"
echo "<td>$BUILD_NUMBER</td>"
echo "</tr>"
echo "<tr>"
echo "<th>Build Status</th>"
echo "<td>$BUILD_STATUS</td>"
echo "</tr>"
echo "</table>"
if [ $BUILD_STATUS == "FAILED" ]; then
  echo "<h3>Failed Stages</h3>"
  echo "<table>"
  echo "<tr>"
  echo "<th>Stage Name</th>"
  echo "<th>Failure Logs</th>"
  echo "</tr>"
  # get the logs for failed stages and add them to the table
  failed_stages=$(grep -B 1 "Result: FAILURE" build.log)
  while read -r line; do
    if [[ $line == *"Started by"* ]]; then
      stage_name=$(echo $line | awk -F 'Running' '{print $2}' | awk -F 'stage' '{print $1}')
      echo "<tr>"
      echo "<td>$stage_name</td>"
      echo "<td>"
    elif [[ $line == *"Result: FAILURE"* ]]; then
      echo "</td>"
      echo "</tr>"
    else
      echo "$line<br>"
    fi
  done <<<"$failed_stages"
  echo "</table>"
fi
echo "</body>"
echo "</html>"
