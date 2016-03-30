#!/bin/bash
###############################################################
# This is the Cake bootstrapper script that is responsible for
# downloading Cake and all specified tools from NuGet.
###############################################################

# Define directories.
SCRIPT_DIR=$( cd "$( dirname "${BASH_SOURCE[0]}" )" && pwd )
TOOLS_DIR=$SCRIPT_DIR/tools
NUGET_EXE=$TOOLS_DIR/nuget.exe
CAKE_EXE=$TOOLS_DIR/Cake/Cake.exe

# Define default arguments.
SCRIPT="build.cake"
TARGET="Default"
CONFIGURATION="Release"
VERBOSITY="verbose"
DRYRUN=false
SHOW_VERSION=false

# Parse arguments.
for i in "$@"; do
    case $1 in
        -t|--target) TARGET="$2"; shift ;;
        -s|--script) SCRIPT="$2"; shift ;;
        -c|--configuration) CONFIGURATION="$2"; shift ;;
        -v|--verbosity) VERBOSITY="$2"; shift ;;
        -d|--dryrun) DRYRUN=true ;;
        --version) SHOW_VERSION=true ;;
    esac
    shift
done

if [ ! -f $TOOLS_DIR ]; then
    mkdir $TOOLS_DIR
fi

# Download NuGet if it does not exist.
if [ ! -f $NUGET_EXE ]; then
    echo "Downloading NuGet..."
    curl -Lsfo $NUGET_EXE https://dist.nuget.org/win-x86-commandline/latest/nuget.exe   
    if [ $? -ne 0 ]; then
        echo "An error occured while downloading nuget.exe."
        exit 1
    fi
fi

# Restore tools from NuGet.
if [ ! -f $CAKE_EXE ]; then
    pushd $TOOLS_DIR >/dev/null
    mono $NUGET_EXE install Cake -ExcludeVersion -Out $TOOLS_DIR
    popd >/dev/null
fi

# Make sure that Cake has been installed.
if [ ! -f $CAKE_EXE ]; then
    echo "Could not find Cake.exe."
    exit 1
fi

# Start Cake
if $SHOW_VERSION; then
    mono $CAKE_EXE -version
elif $DRYRUN; then
    mono $CAKE_EXE $SCRIPT -verbosity=$VERBOSITY -configuration=$CONFIGURATION -target=$TARGET -dryrun
else
    mono $CAKE_EXE $SCRIPT -verbosity=$VERBOSITY -configuration=$CONFIGURATION -target=$TARGET
fi
exit $?