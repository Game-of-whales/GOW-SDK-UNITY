//
// Created by Dmitry Burlakov on 14/06/2017.
// Copyright (c) 2017 GameOfWhales. All rights reserved.
//

#ifndef GW_h
#define GW_h

#import <Foundation/Foundation.h>
#import <StoreKit/StoreKit.h>
#import "GWDelegate.h"
#import "GWSpecialOffer.h"

FOUNDATION_EXPORT NSString *_Nonnull const GW_PROVIDER_APN;
FOUNDATION_EXPORT NSString *_Nonnull const GW_PROVIDER_FCM;
FOUNDATION_EXPORT NSString *_Nonnull const GW_PROVIDER_GCM;

FOUNDATION_EXPORT NSString *_Nonnull const GW_VERIFY_STATE_LEGAL;
FOUNDATION_EXPORT NSString *_Nonnull const GW_VERIFY_STATE_ILLEGAL;
FOUNDATION_EXPORT NSString *_Nonnull const GW_VERIFY_STATE_UNDEFINED;

FOUNDATION_EXPORT NSString *_Nonnull GW_PLATFORM;
FOUNDATION_EXPORT NSString *_Nonnull GW_VERSION;

@interface GW : NSObject

+ (BOOL) IsInitialized;

+ (void)InitializeWithGameKey : (nonnull NSString *)gameKey : (nullable NSDictionary *)launchOptions : (BOOL) debug;

+ (void)Initialize : (nullable NSDictionary *)launchOptions : (BOOL) debug;

+ (void)SetDebug:(BOOL)debug;

+ (void)AddDelegate:(nonnull id <GWDelegate>)delegate;

+ (void)RemoveDelegate:(nonnull id <GWDelegate>)delegate;

+ (nullable GWSpecialOffer *)GetSpecialOffer:(nonnull NSString *)productID;

+ (void)RegisterDeviceTokenWithData:(nonnull NSData *)deviceToken provider:(nonnull NSString *)provider;

+ (void)RegisterDeviceTokenWithString:(nonnull NSString *)deviceToken provider:(nonnull NSString *)provider;

+ (void)PurchaseTransaction:(nonnull SKPaymentTransaction *)transaction product:(nonnull SKProduct *)product;

+ (void)Converting:(nullable NSDictionary<NSString *, NSNumber*> *)resources
             place:(nonnull NSString*)place;

+ (void)ConvertingWithString:(nonnull NSString*)resources
             place:(nonnull NSString*)place;

+ (void)SetPushNotificationsEnable:(bool)value;
+ (bool)IsPushNotificationsEnabled;

+ (void)ConsumeCurrency:(nonnull NSString *)currency number:(nonnull NSNumber *)number sink:(nonnull NSString *)sink amount:(nonnull NSNumber*)amount place:(nonnull NSString*)place;

+ (void)AcquireCurrency:(nonnull NSString *)currency amount:(nonnull NSNumber *)amount source:(nonnull NSString *)source number:(nonnull NSNumber*)number place:(nonnull NSString*)place;

+ (void)Profile:(nullable NSDictionary<NSString *, id> *)params;
+ (void)ProfileWithString:(nonnull NSString*) params;

+(void)ReportError:(nonnull NSString *)message :(nonnull NSString*) stacktrace;

+(void)InAppPurchased:(nonnull NSString*) sku :(double) price :(nonnull NSString*) currency :(nonnull NSString*) transactionID :(nonnull NSString*) receipt;
/*!
 @brief Method must be called from ApplicationDelegate::application:didReceiveRemoteNotification:fetchCompletionHandler: This method are processing remote notification from GameOfWhales when application is in background mode
 @param application UIApplication
 @param notification NSDictionary userData
 @param handler fetchCompletionHandler
 */
+ (void)ReceivedRemoteNotification:(nonnull NSDictionary *)notification withApplication:(UIApplication *_Nonnull)application fetchCompletionHandler:(void (^ _Nullable)(UIBackgroundFetchResult result))handler;

/*!
@brief send information that user reacted to push
*/
+ (void)ReactedRemoteNotification:(nonnull NSDictionary *)notification;
+ (void)ReactedRemoteNotificationWithCampaign:(nonnull NSString *)camp;
@end
#endif
