# OpinionatedGeek PowerPack

The PowerPack was a set of ASP.NET controls for early versions of ASP.NET. The last code
change was 'Thu Oct 30 10:28:48 2008 +0000'.

I've made no effort to bring the source code up to date, or even try compiling it. These
controls just aren't that useful any more - there are better options for development now.
I have removed some strong-name key files and the licensing.txt, which no longer applies.
I also removed some license keys from config files.

I thought the controls were quite useful in their day. I've put the source code up here
in case someone finds it useful.

## Building

Building used to be fairly straightforward. There was even a PackageForRelease MSBuild
target in Visual Studio 2008 as well as some useful release stuff in the ReleaseMechanism
folder.

So, yeah, you'll probably need Visual Studio 2008 to build the current source tree. I don't
think it ever made it to Visual Studio 2010 - by then there were better options for many of
the controls. I've no idea what a conversion to the current version of Visual Studio would
look like.

You may get errors building because I've not supplied the strong-name key that was used for
licensing. You may be able to just create a new SNK and use it instead.

That said, you'd probably be best just deleting the entire Licensing folder and removing all
references to it in the code - that should stop any license checks.

I think.

It's all a bit hazy, given the last check-in was over 8 years ago.

## Licensing

Despite what appears in the (unedited) code files, this project is all released now (in 2017)
into the public domain using the [LICENSE.txt](LICENSE.txt). The license block at the head of
each source file no longer applies - I just wanted to keep the files as original as possible.
