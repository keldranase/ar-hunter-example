# AR Hunter

AR hunter is a mobile application, that provides user with AR Experience

The app is available for [_**Android**_](https://play.google.com/store/apps/details?id=com.Yav.ARHunter&hl=ru&gl=RU) and [_**IOS**_](https://apps.apple.com/ru/app/ar-hunter/id1533108113)

# This repository

My own, non-production, experimental code for AR Hunter. Some code, you can see here is going to be integrated in production version soon, so please tell me, if you have any ideas, on how to make it better.

Part of documentation to code is meant to be a guide for future employees, on how to work with systems of app.
Another part of it is my reasoning on details of implementation. If you see a flaw in it, please tell it.

# Code

The most interesting system here is Camera Screen system. I did it to try dependency injection and soft coupling in general. First design was too soft and unpractical, but now it seems good enough to integrate it to production version.
