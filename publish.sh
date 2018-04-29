#!/bin/bash

dotnet pack src/ReadLine  -c Release --include-source --include-symbols
dotnet nuget push src/ReadLine/bin/Release/Rubberduck.ReadLine.$VERSION.nupkg  -k $NUGET_APIKEY -s https://nuget.org