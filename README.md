# Neumorphism UI for Unity uGUI

Neumorphism UI is an experimental shader for Unity uGUI. Even though texture size is very small (e.g 64x64), it enables us to draw very smooth and scalable images using the MSDF(Multi-channel signed distance field) technique. This is used in [AnyFilter iOS App](https://apps.apple.com/app/id1522506966).

![gifanim](https://imgur.com/E9GctJl.gif)

## How to add your textures

Use [msdfgen](https://github.com/Chlumsky/msdfgen) to generate texture from SVG.  
A sample command is included in `Tools/convert.sh` with a msdfgen macOS binary (Also, you can find the binary for Windows in the [msdfgen's GitHub](https://github.com/Chlumsky/msdfgen/releases)).  

## References

- [Neomorphism Guide 2.0 Figma file](https://dribbble.com/shots/10084381-Neomorphism-Guide-2-0-Original)
- [mob-sakai/UIEffect](https://github.com/mob-sakai/UIEffect)
