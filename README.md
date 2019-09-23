# GOW-SDK-UNITY
Game Of Whales Unity SDK.

<p align=center>
<img src=http://www.gameofwhales.com/sites/default/files/logo.png>
</p>

Documentation is in the [wiki](https://github.com/Game-of-whales/GOW-SDK-UNITY/wiki).


Changelog
---------

**2.0.29 (Sep 23, 2019)**

ADDED

* Supporting of ["A/B Testing"](https://www.gameofwhales.com/documentation/ab-testing) was added. 



**2.0.27 (Jun 28, 2019)**

FIXED

**Android**

* Purchase's price was multiplied 100 times. The bug was fixed.


**2.0.26 (Jun 25, 2019)**

ADDED
* GDPR support: the non-personal mode was added. 

FIXED

**Android**

* SDK receiver doesn't handle a push notification if it has handled the push notification with the same id before.


**2.0.24 (Jun 19, 2019)**

ADDED

* `onInitialized` callback was added. It should be used to get information that the SDK has been initialized.
* `Purchase` method was added to register purchases without verification.


**2.0.23 (Feb 11, 2019)**

FIXED

**Android**

* Cross-promotion ads were shown incorrectly for a fixed portrait/landscape orientation.

**2.0.22 (Jan 25, 2019)**

ADDED

* The supporting of [future (anti-churn) special offers](https://www.gameofwhales.com/documentation/anti-churn-offers) were added.
* The possibility of getting a profile's properties was added.

FIXED

**iOS**:
* The issue with getting server time on 32-bit devices was fixed.


**2.0.21 (Dec 17, 2018)**

MODIFIED

* Calls by using `GameOfWhales.Instance` were changed to static methods.


FIXED

**Android**:
* In some cases, the SDK sent events with the sdk’s platform _android_ instead of _unity_.
* _GameOfWhalesDependencies.xml_ was fixed for working with _GCM_.
* The handling of errors was improved.

**iOS**:

* The game didn’t pause when the cross-promotion ad was showing.
* Ads bundle was not added to _XCODE_ project when using _NotificationServiceExtension_.
* The selection of advertising (cross-promotion) images depending on the orientation of the device was fixed.
* The repeating of cross-promotion ads after some minutes was fixed.
* The handling of errors was improved.


**2.0.20 (Nov 20, 2018)**

ADDED

* The supporting of cross promotion ads was added.

FIXED

**iOS**:

* Names collisions with some plugins were fixed.


**2.0.19 (Oct 29, 2018)**

FIXED

**Android**:
* Sometimes events (for example, ```pushDelivered```) were not sent to **GOW server**. The issue was fixed.

**2.0.18 (Sep 04, 2018)**

ADDED

* ``GetServerTime`` method was added to get GOW server time.
* Server time is used in special offers to check the time for the activation.

**2.0.17 (Jul 25, 2018)**

FIXED

**iOS**

* The error of calling of `consume`/`acquire` methods on some devices was fixed. 


**Android**
* Usage of `Store` parameter was fixed.


**2.0.16 (Jul 16, 2018)**

ADDED

* An option for generating of _Notification Service Extension_  extension (for iOS) was added. It allows to use push notifications with images on iOS devices. There are more details [in documentation](https://github.com/Game-of-whales/GOW-SDK-UNITY/wiki/SDK-implementation#step-12-rich-notifications-on-ios-devices-optional).
The functionality works only with _Unity 2017_.


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
