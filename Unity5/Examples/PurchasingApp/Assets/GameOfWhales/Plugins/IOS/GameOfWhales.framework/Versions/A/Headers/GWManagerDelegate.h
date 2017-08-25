//
//  GWManagerDelegate.h
//  gow
//
//  Created by Dmitry Burlakov on 07.04.17.
//  Copyright © 2017 GameOfWhales. All rights reserved.
//

#import <Foundation/Foundation.h>
#import <StoreKit/StoreKit.h>
#import "GWReplacement.h"

/*!
 @brief Protocol to control Game of whales SDK events
 */
@protocol GWManagerDelegate <NSObject>

@optional
    /*!
     @brief When Game of whales SDK initialized
     */
    - (void)gameOfWhalesLoaded;

    /*!
     @brief When user bought special offer
     @param replacement GWReplacement
     @param transaction SKPaymentTransaction
     */
    - (void)purchasedReplacement:(nonnull GWReplacement *)replacement transaction:(nonnull SKPaymentTransaction *)transaction;

    /*!
     @brief When new replacement appeared in system.
     @param replacement GWReplacement
     */
    - (void)appearedReplacement:(nonnull GWReplacement *)replacement;

    /*!
     @brief When current replacement expired or disappeared.
     @param replacement GWReplacement
     */
    - (void)disappearedReplacement:(nonnull GWReplacement *)replacement;

@end

