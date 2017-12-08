//
// Created by Dmitry Burlakov on 14/06/2017.
// Copyright (c) 2017 GameOfWhales. All rights reserved.
//

#ifndef GWDelegate_h
#define GWDelegate_h

#import <Foundation/Foundation.h>
#import "GWSpecialOffer.h"

@class GWSpecialOffer;

@protocol GWDelegate <NSObject>
- (void)specialOfferAppeared:(nonnull GWSpecialOffer *)specialOffer;

- (void)specialOfferDisappeared:(nonnull GWSpecialOffer *)specialOffer;

- (void)onPushDelivered:(nullable GWSpecialOffer*) offer camp:(nonnull NSString *)camp title:(nonnull NSString*)title message:(nonnull NSString*)message;

- (void)onPurchaseVerified:(nonnull NSString*)transactionID state:(nonnull NSString*)state;
@end

#endif
