#!/bin/bash

echo "<html>" >index.html
echo "<head>" >>index.html
echo "<title>Build Report</title>" >>index.html
echo "</head>" >>index.html
echo "<body>" >>index.html
echo "<h1>Build Report</h1>" >>index.html
echo "<p>Build Number: $BUILD_NUMBER</p>" >>index.html
echo "<p>Build Status: $BUILD_STATUS</p>" >>index.html
echo "<h1>Build Report for Job: $JOB_NAME</h1>" >>index.html
echo "<h2>Build Number: $BUILD_NUMBER</h2>" >>index.html
echo "</body>" >>index.html
echo "</html>" >>index.html

mv index.html ./reports
