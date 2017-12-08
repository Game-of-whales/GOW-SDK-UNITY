# GOW-SDK-UNITY
Game Of Whales Unity SDK.

<p align=center>
<img src=http://www.gameofwhales.com/sites/default/files/logo.png>
</p>

Documentation is in the [wiki](https://github.com/Game-of-whales/GOW-SDK-UNITY/wiki).
> Currently, Unity SDK can only be used with Unity IAP Services

Changelog
---------

**2.0.10**

MODIFIED

* Push notification about special offer comes at the same time with the special offer (new parameter _offer_ was added): <br/>
``void onPushDelivered(SpecialOffer offer, String campID, String title, String message);``

* ``SetPushNotificationsEnable`` method was added to allow user to turn off the push notifications.

**2.0.9**

FIXED
* bug with push notifications receiving (for iOS).

**2.0.8**

MODIFIED
* _store_ parameter was added to initializing.

**2.0.7**

FIXED for iOS:
* bug with _OnPushDelivered_ callback for empty push notification campaign.
* bug with redeemable once special offer: they could be used many times.

**2.0.6**
* New sdk redesign.

**1.0.14**
* Minor bugs were fixed.

**1.0.13**
* Full sdk redesing: basic sdk methods were changed.

**1.0.12**
* Compatible fix for previous versions of _Unity 5_.

**1.0.11**
* Fixed bug: if SDK could not get the player's device's advertising ID, system could use non-unique user identifier for the player.
* Minor bugs were fixed.

**1.0.10**
* Fixed bug: sdk had not worked with other plugins that use push notifications.
* Minor bugs were fixed.

**1.0.9**
* [_Gow.Init_ method](https://github.com/Game-of-whales/GOW-SDK-UNITY/wiki/Init) without parameters is supported.
* Fixed bug: there were some problems, if device's advertisement info was empty. 

**1.0.8**
* Compatible fix for 5.4 or less versions of _Unity 5_.

**1.0.7**
* [Notifications events](https://github.com/Game-of-whales/GOW-SDK-UNITY/wiki/Subscribe-to-push-notifications) were changed.

**1.0.6**
* [Postponed subscription](https://github.com/Game-of-whales/GOW-SDK-UNITY/wiki/Subscribe-to-push-notifications) to push notification is supported.

**1.0.5**
* Minor bugs fixed.

**1.0.4**
* Notifications' sound was added.
* _Unity Cloud Build_ is supported.
* Fixed bug: game settings wasn't saved in the Unity project. 
* Minor bugs fixed.

**1.0.3**
* Integration process was improved.
* Fixed incorrect display of game's android notification icon for push notifications on players' devices.
* Minor bugs fixed.

**1.0.2**
* Custom IStoreListener to Gow.Init method was added which made easier integration if you are already using In-App Purchasing service

**1.0.1**
* Added iOS Support

**1.0.0**
* Unity SDK with Andoid support only

## License

The Game of Whales Unity SDK is licensed under the MIT License.

Copyright (c) 2016 Game of Whales, http://www.gameofwhales.com

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
