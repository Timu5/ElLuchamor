# Makefile for SDL2#
# Written by Ethan "flibitijibibo" Lee

# Source Lists
SRC = \
	LPUtf8StrMarshaler.cs \
	SDL2.cs \
	SDL2_image.cs \
	SDL2_mixer.cs \
	SDL2_ttf.cs

# Targets

debug: clean-debug
	mkdir -p bin/Debug
	cp SDL2-CS.dll.config bin/Debug
	dmcs /unsafe -debug -out:bin/Debug/SDL2-CS.dll -target:library $(SRC)

clean-debug:
	rm -rf bin/Debug

release: clean-release
	mkdir -p bin/Release
	cp SDL2-CS.dll.config bin/Release
	dmcs /unsafe -optimize -out:bin/Release/SDL2-CS.dll -target:library $(SRC)

clean-release:
	rm -rf bin/Release

clean: clean-debug clean-release
	rm -rf bin

all: debug release
