# Instructions

1. Create a __Canvas__, change its color.
2. Create an empty __GameObject__ (rename to _SandClock_).
3. In SandClock add an __Image__ (rename to _Holder_). Encrease SandClock's size.
4. Check _SandClock_ sprite, change Sprite Mode to "multiple", slice this sprite.
5. Set "SandClock_0" sprite as Holder's source image. Change Holder's size and color.
6. Duplicate the Holder (rename to _Glass_), place it before Holder.
7. Set "SandClock_1" sprite as Glass's source image. Change its color and size.
8. Inside the SandClock create a new empty __GameObject__ (rename it to _Fill_).
9. In Fill create an __Image__ (rename to _TopFillImage_).
10. Set "SandClock_2" sprite as TopFillImage's source image, rotate it (180 degrees), change its size and color.
11. Duplicate the TopFillImage (rename to _BottomFillImage_), rotate it (0 degrees).
12. In the SandClock add Text field (place it to the upper part of the Glass).
13. In TopFillImage and BottomFillImage set _Image Type_ to "Filled", set _Fill Method_ to "Vertical".
14. In TopFillImage set _Fill Origin_ to "Top".
15. Create a new C# script, add logic.
16. Add script to SandClock.
17. Create a new __Material__ (_SandDots_). Set Shader (Mobile -> Particles -> Alpha Blended). Set Texture (Sand).
18. In _Sand_ sprite set _Wrape Mode_ to "Repeat", _Pixel per unit_ = 450.
19. In Fill duplicate the BottomFillImage (rename to _SandDots_). Set its _Image Type_ to "Tiled". Set _Source Image_ (Sand). Set _Material_ (SandDots). Change its size. Place it before TopFillImage.
20. Duplicate BottomFillImage (rename to _BottomMask_), replace it before SandDots. Add a __Mask__ component. Set a color same as a glass color. Set _Image Type_ to "Simple".
21. Inside the BottomMask create an __Image__ (_SandPyramidImage_). Set _Source Image_ (SandPyramid). Change its color an size.