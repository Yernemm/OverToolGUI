@echo off

for /f "delims=" %%f in ('dir /s/b/a-d "*.wem"') do (ww2ogg.exe --pcb packed_codebooks_aoTuV_603.bin "%%f")
for /f "delims=" %%f in ('dir /s/b/a-d "*.ogg"') do (revorb.exe "%%f")

echo Job Complete!