#!/bin/bash

folder_path=$1

if [ ! -d "$folder_path" ]; then
  mkdir -p "$folder_path"
  echo "Folder '$folder_path' has been created."
else
  echo "Folder '$folder_path' already exists."
fi
