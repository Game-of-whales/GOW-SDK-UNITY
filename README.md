# GOW-SDK-UNITY
Game Of Whales Unity SDK.

<p align=center>
<img src=http://www.gameofwhales.com/sites/default/files/logo.png>
</p>

Documentation is in the [wiki](https://github.com/Game-of-whales/GOW-SDK-UNITY/wiki).


Changelog
---------


**2.0.15 (Jun 13, 2018)**

FIXED

* Push notifications were not supported for Android 8 +.


**2.0.14 (Jun 13, 2018)**

ADDED

* ```redeemable``` parameter was added to ```SpecialOffer``` class.



**2.0.13.2 (May 14, 2018)**

FIXED

* Usage of *Store* parameter on *Android* devices was fixed.

**2.0.13 (May 10, 2018)**

ADDED

* Custom data is supported for special offers.

FIXED

* Sometimes events from *Android* apps could not be sent to **Game of Whales** server.


**2.0.12 (May 10, 2018)**

ADDED

* The information about device's locale is sent to **Game of Whales**.


**2.0.11 (Jan 30, 2018)**

FIXED

* parameters for ``acquire`` and ``consume`` methods for Android;
* ``isExpired`` method that used local time instead of utc.

**2.0.10 (Dec 15, 2017)**

MODIFIED

* Push notification about special offer comes at the same time with the special offer (new parameter _offer_ was added): <br/>
``void onPushDelivered(SpecialOffer offer, String campID, String title, String message);``

* ``SetPushNotificationsEnable`` method was added to allow user to turn off the push notifications.

**2.0.9 (Nov 21, 2017)**

FIXED
* bug with push notifications receiving (for iOS).

**2.0.8 (Nov 21, 2017)**

MODIFIED
* _store_ parameter was added to initializing.

**2.0.7 (Oct 20, 2017)**

FIXED for iOS:
* bug with _OnPushDelivered_ callback for empty push notification campaign.
* bug with redeemable once special offer: they could be used many times.

**2.0.6 (Aug 25, 2017)**
* New sdk redesign.

**1.0.13 (May 26, 2017)**
* Full sdk redesing: basic sdk methods were changed.

**1.0.12 (Apr 3, 2017)**
* Compatible fix for previous versions of _Unity 5_.

**1.0.11 (Mar 27, 2017)**
* Fixed bug: if SDK could not get the player's device's advertising ID, system could use non-unique user identifier for the player.
* Minor bugs were fixed.

**1.0.10 (Mar 03, 2017)**
* Fixed bug: sdk had not worked with other plugins that use push notifications.
* Minor bugs were fixed.

**1.0.9 (Feb 17, 2017)**
* [_Gow.Init_ method](https://github.com/Game-of-whales/GOW-SDK-UNITY/wiki/Init) without parameters is supported.
* Fixed bug: there were some problems, if device's advertisement info was empty. 

**1.0.8 (Feb 09, 2017)**
* Compatible fix for 5.4 or less versions of _Unity 5_.

**1.0.7 (Feb 08, 2017)**
* [Notifications events](https://github.com/Game-of-whales/GOW-SDK-UNITY/wiki/Subscribe-to-push-notifications) were changed.

**1.0.6 (Feb 07, 2017)**
* [Postponed subscription](https://github.com/Game-of-whales/GOW-SDK-UNITY/wiki/Subscribe-to-push-notifications) to push notification is supported.

**1.0.5 (Jan 23, 2017)**
* Minor bugs fixed.

**1.0.4 (Jan 20, 2017)**
* Notifications' sound was added.
* _Unity Cloud Build_ is supported.
* Fixed bug: game settings wasn't saved in the Unity project. 
* Minor bugs fixed.

**1.0.3 (Dec 09, 2016)**
* Integration process was improved.
* Fixed incorrect display of game's android notification icon for push notifications on players' devices.
* Minor bugs fixed.

**1.0.2 (Oct 14, 2016)**
* Custom IStoreListener to Gow.Init method was added which made easier integration if you are already using In-App Purchasing service

**1.0.1 (Oct 07, 2016)**
* Added iOS Support

**1.0.0 (Sep 15, 2016)**
* Unity SDK with Andoid support only

## License

The Game of Whales Unity SDK is licensed under the MIT License.

Copyright (c) 2016 Game of Whales, http://www.gameofwhales.com

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
