# GOW-SDK-UNITY
Game Of Whales Unity SDK.

<p align=center>
<img src=http://gameofwhales.com/static/images/landing/logo-right.png>
</p>

Documentation is in the [wiki](https://github.com/Game-of-whales/GOW-SDK-UNITY/wiki).
> :information_source:<br>
> Currently, Unity SDK can only be used with Unity IAP Services

Changelog
---------
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
