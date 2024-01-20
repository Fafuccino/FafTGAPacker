## ⚠ **DISCLAIMER** ⚠
**I'm not a software engineer. It's not optimized, I know, but it doesn't have to be.** Also, I wanna point out that I won't maintain this software or do bugfixes of any sort.
I don't have the time. Fork it if you want. If you don't credit me, that's okay. I'm just sharing it in case it can help someone but that's it. Thanks for your understanding.
________________________________
Howdy !
I made a little tool to speed up my workflow. It takes 3-4 textures and merges them a single RGBA texture.
The work is done on the GPU.

**Naming conventions :** Add those suffixes at the end of the file name
_r = Red Channel
_g = Green Channel
_b = Blue Channel
_a = Alpha Channel

Example : "Texture_r", "Texture_g", "Texture_b", "Texture_a"

Note : You can put whatever you want in that name, just make sure to keep the exact same name for the textures you want to merge together.
You can go like... "barbara_r.png"

You can use this tool in 2 different modes :

## I/O mode :
- Create an "input" and "output" folder where the .exe is (if it's not already there).
- Place your textures in the input folder.
- Run the .exe and get your files in the output folder

## Drag and Drop mode :
- Select the files you want to merge, drag and drop onto the .exe
- The .TGAs will appear in the folder where the base files where located. It doesn't even have to be where the .exe is located

## Libraries used :
- **TGASharpLib :** https://github.com/ALEXGREENALEX/TGASharpLib
- **Emgu CV :** https://github.com/emgucv/emgucv

(if you do fork it and develop it on your own, be aware that you're supposed to release the source code for free or pay a license, since it uses Emgu CV.)

## Icon Credit :
It's AI Generated. It's not the purpose of this software so plz don't start whining about it.
Here, steal it if you want <3
![Faf TGA Packer Icon](https://github.com/Fafuccino/Faf-TGA-Packer-Repo/assets/114378047/fa7061f8-ca65-45c6-8ce7-39b47441fc02)
