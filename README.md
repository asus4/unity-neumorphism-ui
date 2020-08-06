# Neumophism UI for Unity uGUI

Neumorphism UI is a experimental shader for Unity uGUI. Even though textures size is very small (e.g 64x64), it enables us to draw very smooth and scalable images using MSDF(Multi-channel signed distance field) technique. This is used in [AnyFilter iOS App](https://apps.apple.com/app/id1522506966).

![gifanim](https://imgur.com/E9GctJl.gif)

## How to add your textures

Use [msdfgen](https://github.com/Chlumsky/msdfgen) to generate texture from SVG.  
A sample command is included in `Tools/convert.sh` with a msdfgen macOS binary (and you can find the binary for win on the msdfgen's GitHub repo).  

## References

- [Neomorphism Guide 2.0 Figma file](https://dribbble.com/shots/10084381-Neomorphism-Guide-2-0-Original)
- [mob-sakai/UIEffect](https://github.com/mob-sakai/UIEffect)
