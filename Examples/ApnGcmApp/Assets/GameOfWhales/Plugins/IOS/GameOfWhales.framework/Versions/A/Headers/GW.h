//
// Created by Dmitry Burlakov on 14/06/2017.
// Copyright (c) 2017 GameOfWhales. All rights reserved.
//

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

+ (nonnull instancetype)shared;

+ (void)initializeWithGameKey : (nonnull NSString *)gameKey : (nullable NSDictionary *)launchOptions : (BOOL) debug;

+ (void)initialize : (nullable NSDictionary *)launchOptions : (BOOL) debug;

- (void)setDebug:(BOOL)debug;

- (void)addDelegate:(nonnull id <GWDelegate>)delegate;

- (void)removeDelegate:(nonnull id <GWDelegate>)delegate;

- (nullable GWSpecialOffer *)specialOfferFor:(nonnull NSString *)productIdentifier;

- (BOOL)inSegment:(nonnull NSString *)segment;

- (void)registerDeviceTokenWithData:(nonnull NSData *)deviceToken provider:(nonnull NSString *)provider;

- (void)registerDeviceTokenWithString:(nonnull NSString *)deviceToken provider:(nonnull NSString *)provider;

- (void)purchaseTransaction:(nonnull SKPaymentTransaction *)transaction product:(nonnull SKProduct *)product;

- (void)converting:(nullable NSDictionary<NSString *, NSNumber*> *)resources
             place:(nonnull NSString*)place;

- (void)convertingWithString:(nonnull NSString*)resources
             place:(nonnull NSString*)place;


- (void)consumeCurrency:(nonnull NSString *)currency number:(nonnull NSNumber *)number sink:(nonnull NSString *)sink amount:(nonnull NSNumber*)amount place:(nonnull NSString*)place;

- (void)acquireCurrency:(nonnull NSString *)currency amount:(nonnull NSNumber *)amount source:(nonnull NSString *)source number:(nonnull NSNumber*)number place:(nonnull NSString*)place;

- (nullable GWSpecialOffer*) getSpecialOffer:(nonnull NSString*)productID;

- (void)profile:(nullable NSDictionary<NSString *, id> *)params;
- (void)profileWithString:(nonnull NSString*) params;

//(const char* sku, float price, const char* price, const char* currency, const char* transactionID, const char* receipt)

-(void)reportError:(nonnull NSString *)message :(nonnull NSString*) stacktrace;

-(void)inAppPurchased:(nonnull NSString*) sku :(float) price :(nonnull NSString*) currency :(nonnull NSString*) transactionID :(nonnull NSString*) receipt;
/*!
 @brief Method must be called from ApplicationDelegate::application:didReceiveRemoteNotification:fetchCompletionHandler: This method are processing remote notification from GameOfWhales when application is in background mode
 @param application UIApplication
 @param notification NSDictionary userData
 @param handler fetchCompletionHandler
 */
- (void)receivedRemoteNotification:(nonnull NSDictionary *)notification withApplication:(UIApplication *_Nonnull)application fetchCompletionHandler:(void (^ _Nullable)(UIBackgroundFetchResult result))handler;

/*!
@brief send information that user reacted to push
*/
- (void)reactedRemoteNotification:(nonnull NSDictionary *)notification;
- (void)reactedRemoteNotificationWithCampaign:(nonnull NSString *)camp;

//- (void)launchWithOptions:(nullable NSDictionary *)launchOptions;
@end
