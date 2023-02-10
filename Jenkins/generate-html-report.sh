#!/bin/bash

BUILD_RESULT=$1

echo "<html>"
echo "<head>"
echo "<style>"
echo "table {
  font-family: arial, sans-serif;
  border-collapse: collapse;
  width: 100%;
}

td, th {
  border: 1px solid #dddddd;
  text-align: left;
  padding: 8px;
}

tr:nth-child(even) {
  background-color: #dddddd;
}
"

if [ "$BUILD_RESULT" = "SUCCESS" ]; then
  echo "body { background-color: #00FF00; }"
elif [ "$BUILD_RESULT" = "FAILURE" ]; then
  echo "body { background-color: #FF0000; }"
else
  echo "body { background-color: #FFFFFF; }"
fi

echo "</style>"
echo "</head>"
echo "<body>"
echo "<h2>Build Report</h2>"
echo "<table>"
echo "<tr>"
echo "<th>Build Result</th>"
echo "<td>$BUILD_RESULT</td>"
echo "</tr>"
echo "</table>"

if [ "$BUILD_RESULT" = "FAILURE" ]; then
  echo "<h2>Failure Logs</h2>"
  echo "<pre>"
  cat failure_logs.txt
  echo "</pre>"
fi

echo "</body>"
echo "</html>"
