//
//  GWManager.h
//  gow
//
//  Created by Dmitry Burlakov on 26.09.16.
//  Copyright © 2016 GameOfWhales. All rights reserved.
//

#import <Foundation/Foundation.h>


#import "GWManagerDelegate.h"

#define GW_VERSION @"1.0.0"
#define GW_APN @"apn"
#define GW_FCM @"fcm"
/*!
 @brief Entry point for Game of whales SDK
 */
@interface GWManager : NSObject

    /*!
     @brief Enablge/Disable debug log
     */
    + (void) setDebug:(bool)value;

    /*!
     @brief Access to single instance GowManager
     */
    + (nonnull instancetype)sharedManager;

    /*!
     @brief Add delegate to process event
     @param delegate GWManagerDelegate to add
     */
    - (void)addDelegate:(nonnull id <GWManagerDelegate>)delegate;

    /*!
     @brief Remove delegate
     @param delegate GWManagerDelegate to remove
     */
    - (void)removeDelegate:(nonnull id <GWManagerDelegate>)delegate;

    /*!
     @brief Does Game of whales has any specials offers for user
     @return Returns YES, if system has replacements for regular SKProducts
     */
    - (BOOL)hasReplacements;

    /*!
     @brief List of replacements
     @return Returns all replacements.
     */
    - (nonnull NSArray<GWReplacement *> *)replacements;

    /*!
     @brief Try to find replacement for product
     @param product SKProduct
     @return GWReplacement if replacement is found
     */
    - (nullable GWReplacement *)replacementForProduct:(nonnull SKProduct *)product;

    - (nonnull NSString*)getVersion;
    /*!
     @brief Try to find replacement for selected productIdentifier
     @param productIdentifier NSString
     @return GWReplacement if replacement is found
     */
    - (nullable GWReplacement *)replacementForProductIdentifier:(nonnull NSString *)productIdentifier;

    - (void)launchWithOptions:(NSDictionary *_Nullable)launchOptions;

    /*!
     @brief Method must be called from ApplicationDelegate::application:didReceiveRemoteNotification:fetchCompletionHandler: This method are processing remote notification from GameOfWhales when application is in background mode
     @param application UIApplication
     @param notification NSDictionary userData
     @param handler fetchCompletionHandler
     */
    - (void)receivedRemoteNotification: (nonnull NSDictionary *)notification withApplication:(UIApplication *_Nonnull)application fetchCompletionHandler:(void (^ _Nullable)(UIBackgroundFetchResult result))handler;


    -(void) setStringParameter:(NSString * _Nonnull) key withValue:(NSString* _Nonnull) value;
    -(void) setIntParameter:(NSString * _Nonnull) key withValue:(int) value;
    -(void) setBoolParameter:(NSString * _Nonnull) key withValue:(BOOL) value;


     /*
     @brief send information that user reacted to push
     */
    - (void) pushReacted:(nonnull NSString*)pushID;

    /*
     @brief Get push id from usefInfo.
     */
    - (NSString*_Nullable)getPushID:(nonnull NSDictionary *) userInfo;

     /*!
     @brief Is current user contained by segment
     @param segmentName Segment name, case sensitive
     @return YES, if user contained by segment
     */
    - (BOOL)inSegment:(nonnull NSString *)segmentName;

    - (void)updateDeviceToken:(nullable NSString *)deviceToken type:(NSString*)type;

    - (void)updateDeviceTokenForNSData:(nullable NSData*)deviceToken type:(NSString*)type;
@end
